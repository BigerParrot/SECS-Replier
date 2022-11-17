using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SECSLibs;
using System.Threading;

namespace SECSTry
{
    public class ConnectionCenter
    {
        #region --公開事件--
        public event EventHandler<EventArgs_EConnectState> ConnectState_Event;
        public event EventHandler<EventArgs_TheMessage> MsgBase_Event;
        public event EventHandler<EventArgs_TheMessage> ReceiveSECSMsg_Event;
        public event EventHandler<EventArgs_TheMessage> SendSECSMsg_Event;
        public event EventHandler<EventArgs_Client> Client_Event;

        public event EventHandler<EventArgs_SingleString> Timeout_Event;
        #endregion --公開事件--

        private bool isTryConnect = false;

        public bool IsSystemServer { get { return server.IsConnect; } }
        public bool IsSystemClient { get { return client.IsConnect; } }

        AsServer server = new AsServer();
        AsClient client = new AsClient();

        public TheMessage SendMessage
        {
            set
            {
                if (IsSystemServer)
                {
                    server.SendMessage = value;
                }
                if (IsSystemClient)
                {
                    client.SendMessage = value;
                }
            }
        }

        public ConnectionCenter()
        {
            server.ConnectState_Event += server_ConnectState_Event;
            server.MsgState_Event += server_MsgState_Event;
            server.MsgBase_Event += server_MsgBase_Event;
            server.ReceiveSECSMsg_Event += server_ReceiveSECSMsg_Event;
            server.SendSECSMsg_Event += server_SendSECSMsg_Event;
            server.Client_Event += server_Client_Event;
            server.Timeout_Event += server_Timeout_Event;

            client.ConnectState_Event += client_ConnectState_Event;
            client.MsgState_Event += client_MsgState_Event;
            client.MsgBase_Event += client_MsgBase_Event;
            client.ReceiveSECSMsg_Event += client_ReceiveSECSMsg_Event;
            client.SendSECSMsg_Event += client_SendSECSMsg_Event;
            client.Timeout_Event += server_Timeout_Event;

            TimeoutSystem.DoTimerListChangeEvent += TimeoutSystem_DoTimerListChangeEvent;
            SECSsystem.DoBeforeCloseAppEvent_1 += SECSsystem_DoBeforeCloseAppEvent_1;
            SECSsystemConnectionConfigure.ServerModeChangeEvent += SECSsystemConnectionConfigure_ServerModeChangeEvent;
        }

        void SECSsystemConnectionConfigure_ServerModeChangeEvent(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Mode = SECSsystemConnectionConfigure.ServerMode;
            }
        }

        void SECSsystem_DoBeforeCloseAppEvent_1(object sender, EventArgs e)
        {
            Disconnect();
        }

        void server_SendSECSMsg_Event(object sender, EventArgs_TheMessage e)
        {
            if (IsSystemServer)
            {
                if (SendSECSMsg_Event != null)
                {
                    SendSECSMsg_Event.Invoke(sender, e);
                }
            }
        }

        void client_SendSECSMsg_Event(object sender, EventArgs_TheMessage e)
        {
            if (IsSystemClient)
            {
                if (SendSECSMsg_Event != null)
                {
                    SendSECSMsg_Event.Invoke(sender, e);
                }
            }
        }

    

        void server_Timeout_Event(object sender, EventArgs_SingleString e)
        {
            if (Timeout_Event != null)
            {
                Timeout_Event.Invoke(sender, e);
            }
        }

        void TimeoutSystem_DoTimerListChangeEvent(object sender, EventArgs e)
        {
            server.DoSetUpTimerList(TimeoutSystem.TimerList);
            client.DoSetUpTimerList(TimeoutSystem.TimerList);
        }

        void server_ReceiveSECSMsg_Event(object sender, EventArgs_TheMessage e)
        {
            if (IsSystemServer)
            {
                if (ReceiveSECSMsg_Event != null)
                {
                    ReceiveSECSMsg_Event.Invoke(sender, e);
                }
            }
        }

        #region --AsClient Event--
        void client_ReceiveSECSMsg_Event(object sender, EventArgs_TheMessage e)
        {
            if (IsSystemClient)
            {
                if (ReceiveSECSMsg_Event != null)
                {
                    ReceiveSECSMsg_Event.Invoke(sender, e);
                }
            }
        }

        void client_MsgBase_Event(object sender, EventArgs_TheMessage e)
        {
            if (IsSystemClient)
            {
                if (MsgBase_Event != null)
                {
                    MsgBase_Event.Invoke(sender, e);
                }
            }
        }

        void client_MsgState_Event(object sender, EventArgs_EMsgState e)
        {
            if (IsSystemClient)
            {
                switch (e.nowState)
                {
                    case EMsgState.Error:
                        SECSReplierMessage.LabelStateMessage(e.nowState.ToString(), EMessageState.Error);
                        break;
                    default:
                        SECSReplierMessage.LabelStateMessage(e.nowState.ToString());
                        break;
                }
            }
        }

        void client_ConnectState_Event(object sender, EventArgs_EConnectState e)
        {
            if (ConnectState_Event != null && isTryConnect)
            {
                ConnectState_Event.Invoke(sender, e);
            }
        }
        #endregion --AsClient Event--

        #region --AsServer Event--
        void server_Client_Event(object sender, EventArgs_Client e)
        {
            if (IsSystemServer)
            {
                if (Client_Event != null)
                {
                    Client_Event.Invoke(sender, e);
                }
            }
        }

        void server_MsgBase_Event(object sender, EventArgs_TheMessage e)
        {
            if (IsSystemServer)
            {
                if (MsgBase_Event != null)
                {
                    MsgBase_Event.Invoke(sender, e);
                }
            }
        }

        void server_MsgState_Event(object sender, EventArgs_EMsgState e)
        {
            if (IsSystemServer)
            {
                switch (e.nowState)
                {
                    case EMsgState.Error:
                        SECSReplierMessage.LabelStateMessage(e.nowState.ToString(), EMessageState.Error);
                        break;
                    default:
                        SECSReplierMessage.LabelStateMessage(e.nowState.ToString());
                        break;
                }
            }
        }

        void server_ConnectState_Event(object sender, EventArgs_EConnectState e)
        {
            if (IsSystemServer)
            {
                if (ConnectState_Event != null)
                {
                    ConnectState_Event.Invoke(sender, e);
                }
            }
        }
        #endregion --AsServer Event--

        public void DoConnectAsServer(IPAddress ip, int port)
        {
            server.Close();
            if (client.IsConnect) { client.Close(true); }

            server.DoConnect(ip, port, SECSsystemConnectionConfigure.ServerMode);
        }

        public void DoConnectAsClient(IPAddress ip, int port)
        {
            server.Close();
            if(client.IsConnect){ client.Close(true); }
            

            isTryConnect = true;
            client.DoConnect(ip, port, true);
        }

        #region --嘗試先以server連線，再以client連線--
        public void DoConnectAsTryBoth(IPAddress ip, int port)
        {
            server.Close();
            client.Close(true);

            server.DoConnect(ip, port, SECSsystemConnectionConfigure.ServerMode);
            Task.Factory.StartNew(() => { DoTryConnectAsClient(ip, port); });
        }

        private void DoTryConnectAsClient(IPAddress ip, int port)
        {
            Thread.Sleep(500);
            if (server.IsConnect) { return; }
            client.DoConnect(ip, port, true);
        }
        #endregion --嘗試先以server連線，再以client連線--

        #region --關閉連線方法(公開)--

        public void Disconnect()
        {
            if (server.IsConnect)
            {
                server.Close();
            }
            if (client.IsConnect || client.IsTryingConnect)
            {
            /*
                if (SECSsystem.SystemConnectState_TCPIP == EConnectState.Connected || SECSsystem.SystemConnectState_TCPIP == EConnectState.Connecting)
                {
                    client.Close(true);
                }
                else
                {
                    client.Close();
                }
            */
                client.Close(true);
            }
        }

        #endregion --關閉連線方法(公開)--
    }
}
