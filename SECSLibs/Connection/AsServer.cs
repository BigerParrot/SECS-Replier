using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SECSLibs
{
    public class AsServer
    {
        public event EventHandler<EventArgs_EConnectState> ConnectState_Event;
        public event EventHandler<EventArgs_EMsgState> MsgState_Event;
        public event EventHandler<EventArgs_TheMessage> MsgBase_Event;
        public event EventHandler<EventArgs_TheMessage> ReceiveSECSMsg_Event;
        public event EventHandler<EventArgs_TheMessage> SendSECSMsg_Event;
        public event EventHandler<EventArgs_Client> Client_Event;

        public event EventHandler<EventArgs_SingleString> Timeout_Event;

        Socket serverSocket = null;
        EServerAllowMode mode = EServerAllowMode.Single_First;
        IPAddress ip = null;
        int port = 0;
        bool isServerDisconnect = true;

        byte[] T7_byte_server = new byte[] { 0x00, 0x00, 0x00, 0x00 }; //不確定

        Queue<ClientSocket> temp = new Queue<ClientSocket>();
        Dictionary<int, int> timerList = new Dictionary<int, int>();
        Dictionary<ClientSocket, SECSTimer> clients = new Dictionary<ClientSocket, SECSTimer>();

        //Queue<Timeouts> Que_T1 = new Queue<Timeouts>(); //T1
        Dictionary<string, UInt32> lengthOfRead = new Dictionary<string, uint>();
        Dictionary<string, byte[]> SessionID = new Dictionary<string, byte[]>();
        Dictionary<string, byte[]> ReqGet = new Dictionary<string, byte[]>();
        Dictionary<string, byte[]> myReqGet = new Dictionary<string, byte[]>();

        Dictionary<string, List<byte[]>> List_T3 = new Dictionary<string, List<byte[]>>();
        Dictionary<string, Queue<SECSmsg>> sendMsg = new Dictionary<string, Queue<SECSmsg>>();
        Dictionary<string, ESType> GetMsgType = new Dictionary<string, ESType>();
        Dictionary<ClientSocket, Dictionary<int, byte[]>> dataTemp = new Dictionary<ClientSocket, Dictionary<int, byte[]>>();
        Dictionary<string, Dictionary<int, int>> dataCount = new Dictionary<string, Dictionary<int, int>>();
        Dictionary<string, int> dataTemp_Total = new Dictionary<string, int>();
        Dictionary<string, int> lastStream = new Dictionary<string, int>();
        Dictionary<string, int> lastFunction = new Dictionary<string, int>();
        Dictionary<string, bool> isMessageByte = new Dictionary<string, bool>();

        Dictionary<string, bool> isSeperating = new Dictionary<string, bool>();
        Dictionary<string, bool> isReceiveEnd = new Dictionary<string, bool>();
        Dictionary<string, bool> isSendEnd = new Dictionary<string, bool>();
        object locker1 = new object();

        public bool IsConnect
        {

            get
            {
                if (serverSocket == null) { return false; }
                return serverSocket.IsBound;
            }
        }

        public EServerAllowMode Mode
        {
            get { return mode; }
            set
            {
                this.mode = value;
                if (IsConnect && !isServerDisconnect)
                {
                    if (ip != null && port != 0)
                    {
                        Close();
                        DoConnect(ip, port, mode);
                    }
                }
            }
        }

        public TheMessage SendMessage
        {
            set
            {
                if (string.IsNullOrEmpty(value.ID))
                {
                    foreach (var cel in sendMsg)
                    {
                        cel.Value.Enqueue(value.SECS_Msg);
                    }
                }
                else
                {
                    if (sendMsg.ContainsKey(value.ID)) { sendMsg[value.ID].Enqueue(value.SECS_Msg); }
                }
            }
        }

        public AsServer() { }
        public void DoConnect(IPAddress ip, int port, EServerAllowMode mode = EServerAllowMode.Single_First)
        {
            IPEndPoint ipe = null;
            this.mode = mode;
            this.ip = ip;
            this.port = port;

            try
            {
                ipe = new IPEndPoint(ip, port);
                serverSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception err)
            {
                BackState1(EConnectState.Error, err.ToString());
                return;
            }

            Task.Factory.StartNew(() => {
                BackState1(EConnectState.None);
                ServerBind(ipe);
            });
        }

        public void DoSetUpTimerList(Dictionary<int, int> tList)
        {
            timerList = new Dictionary<int, int>(tList);

            foreach (SECSTimer stimer in clients.Values)
            {
                stimer.TimeList = new Dictionary<int, int>(timerList);
            }
        }

        private void ServerBind(IPEndPoint ipe)
        {
            try
            {
                serverSocket.Bind(ipe);
                isServerDisconnect = false;
                serverSocket.Listen(0);
                BackState1(EConnectState.Connecting);
                Task.Factory.StartNew(() => { AcceptClient(); });
                Task.Factory.StartNew(() => { DoDequeue(); });
            }
            catch (Exception err)
            {
                BackState1(EConnectState.Error, err.ToString());
            }

        }

        private void AcceptClient()
        {
            if (!IsConnect) { return; }
            Task.Factory.StartNew(() => {
                ClientSocket cl = new ClientSocket();
                cl.ID = Guid.NewGuid().ToString("N");

                try
                {
                    while (mode == EServerAllowMode.Single_First && clients.Count >= 1) { Thread.Sleep(10); }
                    cl.C_socket = serverSocket.Accept();
                }
                catch { }
                if (cl.C_socket == null || !IsConnect) { return; }

                byte[] t7Array = new byte[4];
                Array.Copy(T7_byte_server, t7Array, T7_byte_server.Length);
                cl.T7_byte = t7Array;
                DoReqGetNextValue(ref T7_byte_server);

                switch (mode)
                {
                    case EServerAllowMode.Single_First:
                        if (clients.Count > 0) 
                        {
                            DoRemoveClientSocket(cl);
                        } 
                        else 
                        {
                            temp.Enqueue(cl);
                            Thread.Sleep(100);
                            AcceptClient();
                        }
                        break;
                    case EServerAllowMode.Single_Latest:
                        Queue<ClientSocket> cliens = new Queue<ClientSocket>();
                        foreach (ClientSocket cli in clients.Keys) { cliens.Enqueue(cli); }
                        while (cliens.Count > 0) { DoRemoveClientSocket(cliens.Dequeue()); }
                        temp.Enqueue(cl);
                        Thread.Sleep(100);
                        AcceptClient();
                        break;
                    default:
                        temp.Enqueue(cl);
                        Thread.Sleep(1);
                        AcceptClient();
                        break;
                }

            });
        }

        private void DoDequeue()
        {
            while (IsConnect && !isServerDisconnect)
            {
                while (temp.Count > 0)
                {
                    DoClientSocket(temp.Dequeue()); Thread.Sleep(1);
                }
                Thread.Sleep(100);
            }
        }

        private void DoClientSocket(ClientSocket socket)
        {
            if (!IsConnect || socket == null) { return; }

            lock (clients)
            {
                if (clients.ContainsKey(socket)) { return; }
                clients.Add(socket, new SECSTimer(timerList));
                clients[socket].AddTimer(ETimeout.T7, socket.T7_byte);
                clients[socket].DoTimeoutEvent += AsServer_DoTimeoutEvent;

                GetMsgType.Add(socket.ID, new ESType());
                sendMsg.Add(socket.ID, new Queue<SECSmsg>());
                List_T3.Add(socket.ID, new List<byte[]>());
                lengthOfRead.Add(socket.ID, 14);
                SessionID.Add(socket.ID, new byte[] { 0xFF, 0xFF });
                ReqGet.Add(socket.ID, new byte[] { 0x00, 0x00, 0x09, 0x00 });
                myReqGet.Add(socket.ID, new byte[] { 0x00, 0x01, 0x09, 0x00 });
                dataCount.Add(socket.ID, new Dictionary<int, int>());
                dataTemp.Add(socket, new Dictionary<int, byte[]>());
                dataTemp_Total.Add(socket.ID, 0);
                lastFunction.Add(socket.ID, 0);
                lastStream.Add(socket.ID, 0);
                isMessageByte.Add(socket.ID, false);

                isSeperating.Add(socket.ID, false);
                isSendEnd.Add(socket.ID, false);
                isReceiveEnd.Add(socket.ID, false);
            }

            Task.Factory.StartNew(() => { ServerSend(socket, clients[socket]); });
            Task.Factory.StartNew(() => { ServerReceive(socket, clients[socket]); });
            BackClient(true, socket.ID, socket.C_socket);
        }

        void AsServer_DoTimeoutEvent(object sender, EventArgs_Timeout e)
        {
            if (Timeout_Event != null)
            {
                if (e.style == ETimeout.T7)
                {
                    List<ClientSocket> ClosingClientSocket = new List<ClientSocket>();
                    foreach (ClientSocket cli in clients.Keys)
                    {
                        if (cli.T7_byte.SequenceEqual(e.T7_using))
                        {
                            ClosingClientSocket.Add(cli);
                            cli.C_socket.Close();
                            if(cli.C_socket != null) { cli.C_socket = null; }
                        }
                    }
                    foreach (ClientSocket cliClosing in ClosingClientSocket)
                    {
                        DoRemoveClientSocket(cliClosing);
                    }
                    ClosingClientSocket.Clear();

                    if (clients.Count <= 0) { BackState1(EConnectState.Connecting); }
                }

                EventArgs_SingleString arg = new EventArgs_SingleString();
                arg.theString = string.Format("[{0}] {1} = {2} is timeout... \n", DateTime.Now.ToString("HH:mm:ss.fff"), e.style.ToString(), e.tims);
                Timeout_Event.Invoke(sender, arg);
            }
        }

        private void DoRemoveClientSocket(ClientSocket socket)
        {
            if (isSeperating.ContainsKey(socket.ID))
            {
                isSeperating[socket.ID] = true;
            }
            lock (socket.socket_locker)
            {
                BackClient(false, socket.ID, socket.C_socket);
                ServerSend_Seperate(socket, null);

                if (clients.ContainsKey(socket)) { clients.Remove(socket); }
                if (dataTemp.ContainsKey(socket)) { dataTemp.Remove(socket); }
                if (List_T3.ContainsKey(socket.ID)) { List_T3.Remove(socket.ID); }
                if (sendMsg.ContainsKey(socket.ID)) { sendMsg.Remove(socket.ID); }
                if (GetMsgType.ContainsKey(socket.ID)) { GetMsgType.Remove(socket.ID); }
                if (lengthOfRead.ContainsKey(socket.ID)) { lengthOfRead.Remove(socket.ID); }
                if (SessionID.ContainsKey(socket.ID)) { SessionID.Remove(socket.ID); }
                if (ReqGet.ContainsKey(socket.ID)) { ReqGet.Remove(socket.ID); }
                if (myReqGet.ContainsKey(socket.ID)) { myReqGet.Remove(socket.ID); }
                if (dataCount.ContainsKey(socket.ID)) { dataCount.Remove(socket.ID); }
                if (dataTemp_Total.ContainsKey(socket.ID)) { dataTemp_Total.Remove(socket.ID); }
                if (lastStream.ContainsKey(socket.ID)) { lastStream.Remove(socket.ID); }
                if (lastFunction.ContainsKey(socket.ID)) { lastFunction.Remove(socket.ID); }
                if (isMessageByte.ContainsKey(socket.ID)) { isMessageByte.Remove(socket.ID); }

                if (isSendEnd.ContainsKey(socket.ID)) { isSendEnd.Remove(socket.ID); }
                if (isReceiveEnd.ContainsKey(socket.ID)) { isReceiveEnd.Remove(socket.ID); }
                if (isSeperating.ContainsKey(socket.ID)) { isSeperating.Remove(socket.ID); }
            }
            socket = null;
        }

        private void ServerSend(ClientSocket socket, SECSTimer stime)
        {
            if (!IsConnect || !clients.ContainsKey(socket)) { isSendEnd[socket.ID] = true; return; }

            if (socket == null) { isSendEnd[socket.ID] = true; return; }
            Socket s = socket.C_socket;

            lock (socket.socket_locker)
            {
                try
                {
                    ESType eSType = (ESType)((int)GetMsgType[socket.ID]);
                    if (eSType != ESType.None && eSType != ESType.DataMessage && (int)eSType % 2 == 1)
                    {
                        if (eSType + 1 == ESType.Select_Rsp) { stime.FinishTimer(ETimeout.T7, socket.T7_byte); BackState1(EConnectState.Connected); }
                        byte[] sendByte = SECSstruct.BuildSendSECSmsg(eSType + 1, SessionID[socket.ID], ReqGet[socket.ID]);

                        s.Send(sendByte);
                        BackState2(EMsgState.Sent);
                        if (MsgBase_Event != null)
                        {
                            TheMessage Themsg = new TheMessage();
                            EventArgs_TheMessage arg = new EventArgs_TheMessage();

                            Themsg.SF = string.Format("S0F0");
                            Themsg.ID = socket.ID;
                            Themsg.Msg = SECSshowBuilder.SECSmsg_Base_ToString(ESECSMsgState.Send, 10, (ESType)(eSType + 1));
                            arg.themsg = Themsg;
                            arg.IsSend = true;
                            MsgBase_Event.Invoke(new object(), arg);
                        }
                        if (eSType + 1 == ESType.Select_Rsp) { socket.isSECSconnected = true; }
                        if (eSType != ESType.None) { GetMsgType[socket.ID] = ESType.None; }
                    }
                }
                catch 
                {
                    BackState2(EMsgState.Error, "Send Down");
                    if (clients.ContainsKey(socket))
                    {
                        isSendEnd[socket.ID] = true;
                        DoRemoveClientSocket(socket);
                        if (clients.Count == 0) { BackState1(EConnectState.Connecting); }
                    }
                    return;
                }
                    
            
                if (sendMsg.ContainsKey(socket.ID))
                {
                    try
                    {
                        while (sendMsg[socket.ID].Count > 0)
                        {
                            ///向客戶端傳送一條訊息

                            byte[] t3Array = new byte[4];
                            Array.Copy(myReqGet[socket.ID], t3Array, myReqGet[socket.ID].Length);
                            SECSmsg toSend = sendMsg[socket.ID].Dequeue();
                            byte[] date = SECSstruct.BuildSendSECSmsg(ESType.DataMessage, SessionID[socket.ID], t3Array, toSend);//轉換成為bytes陣列
                            if (date != null)
                            {
                                s.Send(date);

                                if (toSend.AsPrimaryMessage)
                                {
                                    stime.AddTimer(ETimeout.T3, t3Array);
                                    if (List_T3.ContainsKey(socket.ID)) { List_T3[socket.ID].Add(t3Array); }
                                }

                                if (MsgBase_Event != null)
                                {
                                    BackState2(EMsgState.Received);
                                    EventArgs_TheMessage arg = new EventArgs_TheMessage();

                                    TheMessage msg = new TheMessage();
                                    string allmsg = SECSshowBuilder.SECSmsg_Base_ToString(ESECSMsgState.Send, GetTitleofByteArray(date, 1, 4), ESType.DataMessage, toSend.Stream, toSend.Function);

                                    msg.Msg = allmsg;
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

                                    string allmsg = SECSshowBuilder.SECSmsg_Struct_ToString(ESECSMsgState.Send, toSend);

                                    msg.Msg = allmsg;
                                    arg.themsg = msg;
                                    arg.IsSend = true;
                                    SendSECSMsg_Event.Invoke(new object(), arg);
                                }

                            }
                            byte[] r = myReqGet[socket.ID];
                            DoReqGetNextValue(ref r);
                            myReqGet[socket.ID] = r;
                            BackState2(EMsgState.Sent);
                        }
                    }
                    catch
                    {
                        BackState2(EMsgState.Error, "Send Down");
                        if (clients.ContainsKey(socket))
                        {
                            isSendEnd[socket.ID] = true;
                            DoRemoveClientSocket(socket);
                            if (clients.Count <= 0) { BackState1(EConnectState.Connecting); }
                        }
                        return;
                    }
                }
            }
            
            Thread.Sleep(1);
            Task.Factory.StartNew(() => {
                if (!isSeperating.ContainsKey(socket.ID)) { return; }
                if (isSeperating[socket.ID]) { isSendEnd[socket.ID] = true; return; }
                else
                {
                    ServerSend(socket, stime); 
                }
            } );
        }

        private void ServerSend_Seperate(ClientSocket socket, SECSTimer stime)
        {
            if (!IsConnect) { return; }
            Socket s = socket.C_socket;

            ///向客戶端傳送一條訊息
            try
            {
                byte[] r = myReqGet[socket.ID];
                DoReqGetNextValue(ref r);
                myReqGet[socket.ID] = r;

                byte[] t3Array = new byte[4];
                Array.Copy(myReqGet[socket.ID], t3Array, myReqGet[socket.ID].Length);
                byte[] date = SECSstruct.BuildSendSECSmsg(ESType.Separate_Req, SessionID[socket.ID], t3Array);//轉換成為bytes陣列
                if (date != null) { s.Send(date); }

                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(300);
                    s.Close();
                    s.Dispose();
                    
                });
                
                BackState2(EMsgState.Sent);
            }
            catch
            {
                return;
            }
        }

        private void ServerReceive(ClientSocket socket, SECSTimer stime)
        {
            if (!IsConnect || !clients.ContainsKey(socket)) { isReceiveEnd[socket.ID] = true; return; }

            TheMessage Themsg = new TheMessage();
            try
            {
                Socket s = socket.C_socket;

                int count = 0;
                int length = (int)lengthOfRead[socket.ID];
                byte[] dateBuffer = new byte[length];

                //Method 2
                //dataTemp_Total[socket.ID] = 0;
                int totals = 0;
                dataTemp[socket].Clear();

                dataCount[socket.ID].Clear();
                while (length > totals)
                {
                    if (s != null)
                    {
                        try
                        {
                            count = s.Receive(dateBuffer);
                        }
                        catch
                        {
                            if (socket == null) { isReceiveEnd[socket.ID] = true; return; }
                            BackState2(EMsgState.Error, "Receive Down");
                            if (clients.ContainsKey(socket))
                            {
                                isReceiveEnd[socket.ID] = true;
                                DoRemoveClientSocket(socket);
                                if (clients.Count <= 0) { BackState1(EConnectState.Connecting); }
                            }
                            return;
                        }
                        //if (!isMessageByte && count != 0) { Que_T1.Enqueue(stime.AddTimer(ETimeout.T1)); } //T1
                    }
                    if (count == 0) { continue; }

                    totals += count;
                    if (!dataTemp[socket].ContainsKey(dataTemp[socket].Count)) { dataTemp[socket].Add(dataTemp[socket].Count, (byte[])dateBuffer.Clone()); }
                    dataCount[socket.ID].Add(dataCount[socket.ID].Count, count);

                    int c = 0;
                    for (int x = 0; x < dataTemp[socket].Count; x++)
                    {
                        if (!dataTemp[socket].ContainsKey(x)) { continue; }
                        for (int y = 0; y < dataTemp[socket][x].Length; y++)
                        {
                            if (y > dataCount[socket.ID][x] - 1 || c + y >= dateBuffer.Length) { break; }
                            dateBuffer[c + y] = dataTemp[socket][x][y];
                        }
                        c += dataCount[socket.ID][x];
                    }
                }
                //End

                string allmsg = string.Empty;
                Themsg.ID = socket.ID;

                if (isMessageByte[socket.ID])
                {
                    SECSmsg msg = new SECSmsg();
                    if (SECSstruct.BuildSECSmsg(dateBuffer, ref msg))
                    {
                        msg.SetSF(lastStream[socket.ID], lastFunction[socket.ID]);

                        allmsg = SECSshowBuilder.SECSmsg_Struct_ToString(ESECSMsgState.Receive, msg);
                        Themsg.SF = msg.GetSF_string;
                        Themsg.Msg = allmsg;
                    }
                    else
                    {
                        Themsg.Msg = "[Error message]";
                    }

                    Themsg.SECS_Msg = msg;
                    lengthOfRead[socket.ID] = 14;
                    isMessageByte[socket.ID] = false;
                }
                else
                {
                    if (count >= 14)
                    {
                        ESType eSType = ESType.None;
                        eSType = (ESType)GetTitleofByteArray(dateBuffer, 10, 10);
                        //ESType eSType = (ESType)GetTitleofByteArray(dateBuffer, 10, 10);
                        for (int y = 4; y < 6; y++)
                        {
                            SessionID[socket.ID][y - 4] = dateBuffer[y];
                        }

                        lastStream[socket.ID] = GetTitleofByteArray(dateBuffer, 7, 7);
                        lastFunction[socket.ID] = GetTitleofByteArray(dateBuffer, 8, 8);

                        for (int y = 10; y < 14; y++)
                        {
                            ReqGet[socket.ID][y - 10] = dateBuffer[y];
                            myReqGet[socket.ID][y - 10] = dateBuffer[y];

                            byte[] toRemove = null;
                            if (List_T3.ContainsKey(socket.ID))
                            {
                                foreach (byte[] its in List_T3[socket.ID])
                                {
                                    if (its.SequenceEqual(ReqGet[socket.ID]) && lastFunction[socket.ID] % 2 == 0)
                                    {
                                        stime.FinishTimer(ETimeout.T3, its);
                                        toRemove = its;
                                    }
                                }
                                if (toRemove != null && List_T3[socket.ID].Contains(toRemove)) { List_T3[socket.ID].Remove(toRemove); }
                            }
                        }
                        if (eSType == ESType.Select_Req) { int a = 0; }
                        if (eSType == ESType.LinkTest_Rsp) { socket.isSECSconnected = true; }
                        if (eSType == ESType.Separate_Req)
                        {
                            s.Shutdown(SocketShutdown.Both);
                            s.Close();
                            DoRemoveClientSocket(socket);
                            if (clients.Count <= 0) { BackState1(EConnectState.Connecting); }
                        }
                        if (lastStream[socket.ID] >= 128) { lastStream[socket.ID] -= 128; }
                        lock (socket.socket_locker)
                        {
                            if (GetMsgType.ContainsKey(socket.ID)) { GetMsgType[socket.ID] = eSType; }
                        }

                    }

                    if (GetTitleofByteArray_Uint(dateBuffer, 1, 4) != 10)
                    {
                        lengthOfRead[socket.ID] = GetTitleofByteArray_Uint(dateBuffer, 1, 4) - 10;
                        isMessageByte[socket.ID] = true;
                    }
                    allmsg = SECSshowBuilder.SECSmsg_Base_ToString(ESECSMsgState.Receive, GetTitleofByteArray(dateBuffer, 1, 4), GetMsgType[socket.ID], lastStream[socket.ID], lastFunction[socket.ID]);
                    Themsg.Msg = allmsg;
                    Themsg.SF = "S" + lastStream[socket.ID].ToString() + "F" + lastFunction[socket.ID].ToString();
                }
            }
            catch
            {
                BackState2(EMsgState.Error, "Send Down");
                if (clients.ContainsKey(socket))
                {
                    isReceiveEnd[socket.ID] = true;
                    DoRemoveClientSocket(socket);
                    if (clients.Count <= 0) { BackState1(EConnectState.Connecting); }
                }
                return;
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
            Task.Factory.StartNew(() => { 
                try 
                {
                    if (isSeperating[socket.ID]) { isReceiveEnd[socket.ID] = true; return; }
                    else
                    {
                        ServerReceive(socket, stime);
                    }
                } 
                catch (Exception err) 
                {
                    BackState2(EMsgState.Error, "Receive Down");
                    if (clients.ContainsKey(socket))
                    {
                        isReceiveEnd[socket.ID] = true;
                        DoRemoveClientSocket(socket);
                        if (clients.Count <= 0) { BackState1(EConnectState.Connecting); }
                    }
                    return;
                } 
            });
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

        private void BackClient(bool onoff, string id, Socket clientsocket)
        {
            if (Client_Event != null)
            {
                EventArgs_Client arg = new EventArgs_Client();
                arg.onoff = onoff;
                arg.ID = id;
                arg.socket = clientsocket;
                Client_Event.Invoke(new object(), arg);
            }
        }

        public void Close()
        {
            if (clients.Count != 0)
            {
                Queue<ClientSocket> ToEnd = new Queue<ClientSocket>();
                foreach (ClientSocket s in clients.Keys)
                {
                    ToEnd.Enqueue(s);
                }
                clients.Clear();

                Task.Factory.StartNew(() =>
                {
                    while (ToEnd.Count > 0)
                    {
                        DoRemoveClientSocket(ToEnd.Dequeue());
                    }
                });
            }

            if (IsConnect && serverSocket != null) { serverSocket.Close(); serverSocket.Dispose();  }

            BackState1(EConnectState.Disconnect);

            if (sendMsg.Count != 0) { sendMsg.Clear(); }
            if(temp.Count > 0) { temp.Clear(); }

            isServerDisconnect = true;
        }
    }

}
