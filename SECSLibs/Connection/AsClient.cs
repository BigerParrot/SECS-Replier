using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SECSLibs
{
    public class AsClient
    {
        public event EventHandler<EventArgs_EConnectState> ConnectState_Event;
        public event EventHandler<EventArgs_EMsgState> MsgState_Event;
        public event EventHandler<EventArgs_TheMessage> MsgBase_Event;
        public event EventHandler<EventArgs_TheMessage> ReceiveSECSMsg_Event;
        public event EventHandler<EventArgs_TheMessage> SendSECSMsg_Event;

        public event EventHandler<EventArgs_SingleString> Timeout_Event;

        Socket clientSocket = null;
        ESType GetMsgType = ESType.None;
        private UInt32 lengthOfRead = 14;
        byte[] SessionID = new byte[2];
        byte[] ReqGet = new byte[4];
        byte[] myReqGet = new byte[4];

        SECSTimer clientTimer = new SECSTimer();
        Dictionary<int, int> timerList = new Dictionary<int, int>();
        List<byte[]> List_T3 = new List<byte[]>();

        private Queue<SECSmsg> sendMsg = new Queue<SECSmsg>();
        Dictionary<int, byte[]> dataTemp = new Dictionary<int, byte[]>();
        Dictionary<int, int> dataCount = new Dictionary<int, int>();
        private int dataTemp_Total = 0;

        private bool isMessageByte = false;
        private bool isSECS_LinkStep = false;
        private bool isSECS_SelectStep = false;
        private bool isSeparate = true;
        private bool isTryingConnect = false;
        private bool hereTotalclose = true;

        private int lastStream = 0;
        private int lastFunction = 0;

        private IPAddress ip = null;
        private int port = 0;

        public bool IsTryingConnect { get { return isTryingConnect; } }

        object isconnectlock = new object();

        public bool IsConnect
        {
            /*
            get
            {
                if (clientSocket == null) { return false; }
                return clientSocket.IsBound;
            }
            */
            get
            {
                if (clientSocket == null) { return false; }
                if (!clientSocket.IsBound) { return false;}
                try
                {
                    bool part1 = clientSocket.Poll(10, SelectMode.SelectRead);
                    bool part2 = (clientSocket.Available == 0);
                    if (part1 && part2)
                        return false;
                    else
                        return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public TheMessage SendMessage
        {
            set
            {
                sendMsg.Enqueue(value.SECS_Msg);
            }
        }

        public AsClient()
        {
            SessionID = new byte[] { 0xFF, 0xFF };
            ReqGet = new byte[] { 0x00, 0x00, 0x09, 0x00 };
            myReqGet = new byte[] { 0x00, 0x01, 0x09, 0x00 };

            clientTimer.DoTimeoutEvent += AsClient_DoTimeoutEvent;
        }

        void AsClient_DoTimeoutEvent(object sender, EventArgs_Timeout e)
        {
            if (e.style == ETimeout.T5) { if (ip != null && isTryingConnect && !hereTotalclose) { DoConnect(ip, port); } else if (!isTryingConnect) { return; } }
            if ((clientSocket == null || !clientSocket.IsBound) && e.style != ETimeout.T5) { return; }
            if (e.style == ETimeout.T6) { Close(); if (clientTimer.T5s.Count<1) {clientTimer.AddTimer(ETimeout.T5); } }

            if (Timeout_Event != null)
            {
                EventArgs_SingleString arg = new EventArgs_SingleString();
                arg.theString = string.Format("[{0}] {1} = {2} is timeout... \n", DateTime.Now.ToString("HH:mm:ss.fff"), e.style.ToString(), e.tims);
                Timeout_Event.Invoke(sender, arg);
            }
        }

        private void DoResetConnection()
        {
            if (!hereTotalclose && isTryingConnect)
            {
                Close();
                if (clientTimer.T5s.Count < 1) { clientTimer.AddTimer(ETimeout.T5); }
            }
            
        }

        public void DoConnect(IPAddress ip, int port, bool istrying = false)
        {
            if (istrying) { isTryingConnect = true; hereTotalclose = false; }

            IPEndPoint ipe = null;

            this.ip = ip;
            this.port = port;

            try
            {
                ipe = new IPEndPoint(ip, port);
                clientSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception err)
            {
                BackState1(EConnectState.Error, err.ToString());
                return;
            }

            if (clientSocket == null) { BackState1(EConnectState.Error); return; }

            Task.Factory.StartNew(()=>{
                ClientConnect(ipe);
            });
        }

        private void ClientConnect(IPEndPoint ipe)
        {
            try
            {
                if (!clientSocket.IsBound)
                {
                    if (!isTryingConnect) { return; }
                    if (!IsConnect) 
                    { 
                        clientSocket.Connect(ipe);

                        hereTotalclose = false;
                        isSECS_LinkStep = false;
                        isSECS_SelectStep = false;
                        isSeparate = false;

                        Task.Factory.StartNew(() => { ClientReceive(); });
                        Task.Factory.StartNew(() => { ClientSend(); });
                    }
                    else
                    {
                        DoResetConnection();
                    }
                    
                }
                else
                {
                    return;
                }
            }
            catch(Exception err)
            {
                Thread.Sleep(5);
                if (clientTimer.T5s.Count<1) { clientTimer.AddTimer(ETimeout.T5); }
                if (isTryingConnect) { BackState1(EConnectState.Connecting); }
                BackState2(EMsgState.Error, "Link Error");
                return;
            }
        }

        public void DoSetUpTimerList(Dictionary<int, int> tList)
        {
            timerList = new Dictionary<int, int>(tList);

            clientTimer.TimeList = new Dictionary<int, int>(timerList);
        }

        private void ClientSend()
        {
            if (hereTotalclose) { return; }
            if (!isSECS_LinkStep || !isSECS_SelectStep)
            {
                myReqGet = new byte[] { 0x00, 0x01, 0x09, 0x00 };

                bool isContinue = false;
                int times = 0;
                Task.Factory.StartNew(() => { Thread.Sleep(timerList[4] * 1000); isContinue = true; });
                Task.Factory.StartNew(() => { if (!isSECS_SelectStep && isTryingConnect && !isSeparate) { SendBothReq(ESType.Select_Req); } });
                Task.Factory.StartNew(() => { while (!isSECS_SelectStep && clientSocket.IsBound) { Thread.Sleep(10); } DoReqGetNextValue(ref myReqGet); SendBothReq(ESType.LinkTest_Req); });

                while (!isContinue && !isSECS_LinkStep)
                {
                    if (IsConnect)
                    {
                        Thread.Sleep(10);
                    }
                    else 
                    {
                        DoResetConnection();
                        return;
                    }
                }
                Task.Factory.StartNew(() => { ClientSend(); });
                return;
            }

            if (GetMsgType != ESType.None && GetMsgType != ESType.DataMessage && (int)GetMsgType % 2 == 1)
            {
                byte[] sendByte = SECSstruct.BuildSendSECSmsg(GetMsgType + 1, SessionID, ReqGet);
                try
                {
                    clientSocket.Send(sendByte);
                    BackState2(EMsgState.Sent);
                    GetMsgType = ESType.None;
                }
                catch
                {
                    if (!hereTotalclose)
                    {
                        DoResetConnection();
                        BackState2(EMsgState.Error, "Send Down");
                        return;
                    }
                }
            }

            while (sendMsg.Count > 0)
            {
                ///向客戶端傳送一條訊息
                try
                {
                    DoReqGetNextValue(ref myReqGet);
                    byte[] t3Array = new byte[4];
                    Array.Copy(myReqGet, t3Array, myReqGet.Length);
                    SECSmsg toSend = sendMsg.Dequeue();
                    byte[] date = SECSstruct.BuildSendSECSmsg(ESType.DataMessage, SessionID, t3Array, toSend);//轉換成為bytes陣列
                    if (date != null) 
                    { 
                        clientSocket.Send(date); 
                        
                        if (toSend.AsPrimaryMessage)
                        {
                            clientTimer.AddTimer(ETimeout.T3, t3Array);
                            List_T3.Add(t3Array);
                        }

                        if (MsgBase_Event != null)
                        {
                            BackState2(EMsgState.Received);
                            EventArgs_TheMessage arg = new EventArgs_TheMessage();

                            TheMessage msg = new TheMessage();
                            
                            msg.Msg = SECSshowBuilder.SECSmsg_Base_ToString(ESECSMsgState.Send, date.Length, ESType.DataMessage, toSend.Stream, toSend.Function);
                            msg.SF = toSend.GetSF_string;

                            arg.themsg = msg;
                            arg.IsSend = true;
                            MsgBase_Event.Invoke(new object(), arg);
                        }

                        if (SendSECSMsg_Event != null)
                        {
                            EventArgs_TheMessage arg = new EventArgs_TheMessage();

                            TheMessage msg = new TheMessage();
                            msg.SF = toSend.GetSF_string;
                            msg.SECS_Msg = toSend.Clone();

                            msg.Msg = SECSshowBuilder.SECSmsg_Struct_ToString(ESECSMsgState.Send, toSend);
                            arg.themsg = msg;
                            arg.IsSend = true;
                            SendSECSMsg_Event.Invoke(new object(), arg);
                        } 
                        
                    }
                    BackState2(EMsgState.Sent);
                }
                catch
                {
                    if (!hereTotalclose)
                    {
                        DoResetConnection();
                        BackState2(EMsgState.Error, "Send Down");
                        return;
                    }
                }
            }

            Thread.Sleep(1);
            Task.Factory.StartNew(() => { ClientSend(); });
        }

        private void ClientReceive()
        {
            lock (isconnectlock){ if (!IsConnect) { lengthOfRead = 14; return; } }

            byte[] dateBuffer = new byte[lengthOfRead];
            int count = 0;

            //Method 2
            dataTemp_Total = 0;
            dataTemp.Clear();
            dataCount.Clear();
            while (lengthOfRead > dataTemp_Total)
            {
                if (hereTotalclose) { break; }
                try
                {
                    if (clientSocket != null)
                    {
                        count = clientSocket.Receive(dateBuffer);
                    }
                }
                catch
                {
                    if (!hereTotalclose)
                    {
                        DoResetConnection();
                        BackState2(EMsgState.Error, "Receive Down");
                        return;
                    }
                }

                if (count == 0) { continue; }

                dataTemp_Total += count;
                dataTemp.Add(dataTemp.Count, (byte[])dateBuffer.Clone());
                dataCount.Add(dataCount.Count, count);

                int c = 0;
                for (int x = 0; x < dataTemp.Count; x++)
                {
                    for (int y = 0; y < dataTemp[x].Length; y++)
                    {
                        if (y > dataCount[x] - 1 || c + y >= dateBuffer.Length) { break; }
                        dateBuffer[c + y] = dataTemp[x][y];
                    }
                    c += dataCount[x];
                }
            }
            //End

            string allmsg = string.Empty;
            TheMessage Themsg = new TheMessage();

            if (!IsConnect) { lengthOfRead = 14; return; }

            if (isMessageByte)
            {
                SECSmsg msg = new SECSmsg();
                if (SECSstruct.BuildSECSmsg(dateBuffer, ref msg))
                {
                    msg.SetSF(lastStream, lastFunction);

                    Themsg.SF = msg.GetSF_string;
                    Themsg.Msg = SECSshowBuilder.SECSmsg_Struct_ToString(ESECSMsgState.Receive, msg);
                }
                else
                {
                    Themsg.Msg = string.Format("[Error message] with {0} length message", dateBuffer.Length.ToString());
                }

                Themsg.SECS_Msg = msg;
                lengthOfRead = 14;
                isMessageByte = false;
            }
            else
            {
                if (count >= 14)
                {
                    GetMsgType = (ESType)GetTitleofByteArray(dateBuffer, 10, 10);
                    for (int y = 4; y < 6; y++)
                    {
                        SessionID[y - 4] = dateBuffer[y];
                    }

                    lastStream = GetTitleofByteArray(dateBuffer, 7, 7);
                    lastFunction = GetTitleofByteArray(dateBuffer, 8, 8);

                    for (int y = 10; y < 14; y++)
                    {
                        ReqGet[y - 10] = dateBuffer[y];
                    }

                    //T3解除
                    byte[] toRemove = null;
                    foreach (byte[] its in List_T3)
                    {
                        if (its.SequenceEqual(ReqGet) && lastFunction % 2 == 0)
                        {
                            clientTimer.FinishTimer(ETimeout.T3, its);
                            toRemove = its;
                        }
                    }
                    if (toRemove != null) { List_T3.Remove(toRemove); }

                    //T6解除
                    if ((int)GetMsgType % 2 == 0 && (int)GetMsgType != 0)
                    {
                        foreach (Timeouts its in clientTimer.T6s)
                        {
                            if (its.ByteID_4.SequenceEqual(ReqGet))
                            {
                                clientTimer.FinishTimer(ETimeout.T6, ReqGet);
                            }
                        }
                    }

                    if (GetMsgType == ESType.Select_Rsp) { isSECS_SelectStep = true; BackState1(EConnectState.Connected); }
                    if (GetMsgType == ESType.LinkTest_Rsp) { isSECS_LinkStep = true; }
                    if (GetMsgType == ESType.Separate_Req) 
                    { 
                        Close(); 
                        if (clientTimer.T5s.Count < 1) 
                        { 
                            clientTimer.AddTimer(ETimeout.T5); 
                        } 
                        return; 
                    }

                    if (lastStream >= 128) { lastStream -= 128; }

                }

                if (GetTitleofByteArray_Uint(dateBuffer, 1, 4) != 10)
                {
                    lengthOfRead = GetTitleofByteArray_Uint(dateBuffer, 1, 4) - 10;
                    isMessageByte = true;
                }

                Themsg.Msg = SECSshowBuilder.SECSmsg_Base_ToString(ESECSMsgState.Receive, (int)GetTitleofByteArray_Uint(dateBuffer, 1, 4), GetMsgType, lastStream, lastFunction);
                Themsg.SF = "S" + lastStream.ToString() + "F" + lastFunction.ToString();
            }

            if (Themsg.SECS_Msg.GetSF_string.Equals("S0F0") && MsgBase_Event != null)
            {
                BackState2(EMsgState.Received);
                EventArgs_TheMessage arg = new EventArgs_TheMessage();
                arg.themsg = Themsg;
                arg.IsReceive = true;
                MsgBase_Event.Invoke(new object(), arg);
            }
            else if (!Themsg.SECS_Msg.GetSF_string.Equals("S0F0") && ReceiveSECSMsg_Event != null)
            {
                BackState2(EMsgState.Received);
                EventArgs_TheMessage arg = new EventArgs_TheMessage();
                arg.themsg = Themsg;
                arg.IsReceive = true;
                ReceiveSECSMsg_Event.Invoke(new object(), arg);
            }

            Thread.Sleep(1);
            Task.Factory.StartNew(() => { if(clientSocket != null && !hereTotalclose) { ClientReceive(); } });
        }

        private void SendBothReq(ESType typr)
        {
            if (!(typr == ESType.LinkTest_Req || typr == ESType.Select_Req)) { return; }

            byte[] sendByte1 = SECSstruct.Send_SelectReq(myReqGet);
            byte[] sendByte2 = SECSstruct.Send_LinkTest(myReqGet);

            try
            {
                
                if (clientSocket != null)
                {
                    if (typr == ESType.Select_Req)
                    {
                        clientSocket.Send(sendByte1);
                        clientTimer.AddTimer(ETimeout.T6, myReqGet);

                    }
                    else
                    {
                        clientSocket.Send(sendByte2);
                        /*clientTimer.AddTimer(ETimeout.T6, myReqGet);*/
                    }

                    if (MsgBase_Event != null)
                    {
                        TheMessage Themsg = new TheMessage();
                        EventArgs_TheMessage arg = new EventArgs_TheMessage();

                        if (typr == ESType.Select_Req) { Themsg.SF = string.Format("S_req"); } else { Themsg.SF = string.Format("L_req"); }
                        
                        if(typr == ESType.Select_Req)
                        {
                            Themsg.Msg = SECSshowBuilder.SECSmsg_Base_ToString(ESECSMsgState.Send, sendByte1.Length, typr);
                        }
                        else
                        {
                            Themsg.Msg = SECSshowBuilder.SECSmsg_Base_ToString(ESECSMsgState.Send, sendByte2.Length, typr);
                        }
                        

                        arg.themsg = Themsg;
                        arg.IsSend = true;
                        MsgBase_Event.Invoke(new object(), arg);
                    }

                    BackState2(EMsgState.Sent);
                }

                return;
            }
            catch(Exception err)
            {
                Close();
                BackState2(EMsgState.Error, "Send Down");
                return;
            }
        }

        private void SendSeparate()
        {
            ESType typr = ESType.Separate_Req;

            byte[] sendByte1 = SECSstruct.BuildSendSECSmsg(ESType.Separate_Req, SessionID, myReqGet);

            try
            {
                if (clientSocket != null)
                {
                    if (MsgBase_Event != null)
                    {
                        TheMessage Themsg = new TheMessage();
                        EventArgs_TheMessage arg = new EventArgs_TheMessage();
                        Themsg.SF = string.Format("Separate");
                        Themsg.Msg = SECSshowBuilder.SECSmsg_Base_ToString(ESECSMsgState.Send, sendByte1.Length, typr);

                        arg.themsg = Themsg;
                        arg.IsSend = true;
                        MsgBase_Event.Invoke(new object(), arg);
                    }
                    clientSocket.Send(sendByte1);
                    BackState2(EMsgState.Sent);
                }
                
                return;
            }
            catch
            {
                Close();
                BackState2(EMsgState.Error, "Send Down");
                return;
            }
        }
        
        private void DoReqGetNextValue(ref byte[] sourceArray)
        {
            if (sourceArray[3] != 0xFF)
            {
                sourceArray[3] = Convert.ToByte((int)sourceArray[3] + 1);
            }
            else
            {
                sourceArray[3] = 0x00;
                if (sourceArray[2] != 0xFF)
                {
                    sourceArray[2] = Convert.ToByte((int)sourceArray[2] + 1);
                }
                else
                {
                    sourceArray[2] = 0x00;
                }
            }
        }

        private int GetTitleofByteArray(byte[] arr, int fromNum, int toNum)
        {
            int x = 0;
            byte[] top = new byte[toNum - fromNum + 1];
            for (int y = 0; y < top.Length; y++)
            {
                top[y] = arr[toNum - y - 1];
            }
            if (top.Length == 4)
            {
                x = BitConverter.ToInt32(top, 0);
            }
            else if (top.Length == 1)
            {
                x = Convert.ToInt32(top[0]);
            }

            return x;
        }

        private UInt32 GetTitleofByteArray_Uint(byte[] arr, int fromNum, int toNum)
        {
            UInt32 x = 0;
            byte[] top = new byte[toNum - fromNum + 1];
            string bin_S = string.Empty;

            for (int y = fromNum - 1; y < toNum; y++)
            {
                top[y] = arr[y];
            }

            for (int y = 0; y < top.Length; y++)
            {
                bin_S += Convert.ToString((byte)top[y], 2).PadLeft(8, '0');
            }

            if (top.Length == 4)
            {
                //x = BitConverter.ToUInt32(top, 0);
                x = Convert.ToUInt32(bin_S, 2);
            }
            else if (top.Length == 1)
            {
                //x = Convert.ToUInt32(top[0]);
                x = Convert.ToUInt32(bin_S, 2);
            }

            return x;
        }

        private void BackState1(EConnectState state, string error = "")
        {
            if (ConnectState_Event != null)
            {
                object ob = new object();
                EventArgs_EConnectState arg = new EventArgs_EConnectState();
                arg.nowState = state;
                arg.errorCode = error;
                ConnectState_Event.Invoke(ob, arg);
            }
        }

        private void BackState2(EMsgState state, string error = "")
        {
            if (MsgState_Event != null)
            {
                object ob = new object();
                EventArgs_EMsgState arg = new EventArgs_EMsgState();
                arg.nowState = state;
                arg.errorCode = error;
                MsgState_Event.Invoke(ob, arg);
            }
        }

        public void Close(bool totalClose = false)
        {
            if (totalClose)
            {
                hereTotalclose = true;
                isMessageByte = false;
                SendSeparate();
                isSeparate = true;
            }
            if (clientSocket != null)
            {
                try 
                { 
                    clientSocket.Shutdown(SocketShutdown.Both); 
                }
                catch { }
                clientSocket.Close();
                clientSocket.Dispose();
                isSECS_LinkStep = false;
                isSECS_SelectStep = false;

                if (totalClose)
                {
                    isTryingConnect = false;
                    BackState1(EConnectState.Disconnect);
                }
                else
                {
                    BackState1(EConnectState.Connecting);
                }
                
            }
            else
            {
                isTryingConnect = false;
                BackState1(EConnectState.Disconnect);
            }

            lengthOfRead = 14;
            if (sendMsg.Count > 0) { sendMsg.Clear(); }
        }
    }

    public class EventClientArgs : EventArgs
    {
        public string Messaging = "";
    }
}
