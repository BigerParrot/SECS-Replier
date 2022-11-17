using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SECSCtrlLibs;
using SECSLibs;
using System.Threading;

namespace SECSTry
{
    public partial class SECSReplier : Form
    {
        private delegate void lb_Msg_Change(object sender, EventArgs_FormLabelMessage e);
        private delegate void lb_MsgState_Change(object sender, EventArgs_EMsgState e);
        private delegate void tab1_Change(object sender, EventArgs_SingleString e);
        private ConnectionCenter connectionCenter = new ConnectionCenter();

        object linkTable_multiThread_lock = new object();

        public SECSReplier()
        {
            InitializeComponent();

            SECSsystemEventBind();
            ConnectionCenterEventBind();
            TittleEventBind();
            TabsEventBind();
        }

        private void SECSsystemEventBind()
        {
            SECSsystem.DoMessageBoxShowEvent += SECSsystem_DoMessageBoxShowEvent;
            SECSsystem.DoDisconnectEvent += _DoOfflineEvent;

            SECSReplierMessage.DoLabel1Message_Event += SECSReplierMessage_DoLabel1Message_Event;
            SECSReplierMessage.DoLabel2Message_Event += SECSReplierMessage_DoLabel2Message_Event;
            SECSReplierMessage.DoLabelState_Event += SECSReplierMessage_DoLabelState_Event;
        }

        void SECSReplierMessage_DoLabelState_Event(object sender, EventArgs_FormLabelMessage e)
        {
            if (this.InvokeRequired)
            {
                lb_Msg_Change del = new lb_Msg_Change(SECSReplierMessage_DoLabelState_Event);
                this.Invoke(del, new object[] { sender, e });
            }
            else
            {
                switch (e.state)
                {
                    case EMessageState.None:
                    case EMessageState.Normal:
                        lb_MsgState.BackColor = Color.FromKnownColor(KnownColor.Control);
                        lb_MsgState.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        break;
                    case EMessageState.Error:
                        lb_MsgState.BackColor = Color.FromKnownColor(KnownColor.Red);
                        lb_MsgState.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        Task.Factory.StartNew(()=>{
                            Thread.Sleep(3000);
                            EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                            arg.message = string.Empty;
                            arg.state = EMessageState.None;
                            SECSReplierMessage_DoLabelState_Event(sender, arg);
                        });
                        break;
                    case EMessageState.Succeed:
                        lb_MsgState.BackColor = Color.FromKnownColor(KnownColor.GreenYellow);
                        lb_MsgState.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(1000);
                            EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                            arg.message = e.message;
                            arg.state = EMessageState.None;
                            SECSReplierMessage_DoLabelState_Event(sender, arg);
                        });
                        break; 
                }

                lb_MsgState.Text = e.message;
            }
        }

        void SECSReplierMessage_DoLabel2Message_Event(object sender, EventArgs_FormLabelMessage e)
        {
            if (this.InvokeRequired)
            {
                lb_Msg_Change del = new lb_Msg_Change(SECSReplierMessage_DoLabel2Message_Event);
                this.Invoke(del, new object[] { sender, e });
            }
            else
            {
                switch (e.state)
                {
                    case EMessageState.None:
                    case EMessageState.Normal:
                        tb_msg2.BackColor = Color.FromKnownColor(KnownColor.Control);
                        tb_msg2.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        break;
                    case EMessageState.Error:
                        tb_msg2.BackColor = Color.FromKnownColor(KnownColor.Red);
                        tb_msg2.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(1000);
                            EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                            arg.message = e.message;
                            arg.state = EMessageState.None;
                            SECSReplierMessage_DoLabel2Message_Event(sender, arg);
                        });
                        break;
                    case EMessageState.Succeed:
                        tb_msg2.BackColor = Color.FromKnownColor(KnownColor.GreenYellow);
                        tb_msg2.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(1000);
                            EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                            arg.message = e.message;
                            arg.state = EMessageState.None;
                            SECSReplierMessage_DoLabel2Message_Event(sender, arg);
                        });
                        break;
                }

                tb_msg2.Text = e.message;
            }
        }

        void SECSReplierMessage_DoLabel1Message_Event(object sender, EventArgs_FormLabelMessage e)
        {
            if (this.InvokeRequired)
            {
                lb_Msg_Change del = new lb_Msg_Change(SECSReplierMessage_DoLabel1Message_Event);
                this.Invoke(del, new object[] { sender, e });
            }
            else
            {
                switch (e.state)
                {
                    case EMessageState.None:
                    case EMessageState.Normal:
                        tb_msg1.BackColor = Color.FromKnownColor(KnownColor.Control);
                        tb_msg1.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        break;
                    case EMessageState.Error:
                        tb_msg1.BackColor = Color.FromKnownColor(KnownColor.Red);
                        tb_msg1.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(1000);
                            EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                            arg.message = e.message;
                            arg.state = EMessageState.None;
                            SECSReplierMessage_DoLabel1Message_Event(sender, arg);
                        });
                        break;
                    case EMessageState.Succeed:
                        tb_msg1.BackColor = Color.FromKnownColor(KnownColor.GreenYellow);
                        tb_msg1.ForeColor = Color.FromKnownColor(KnownColor.Black);
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(1000);
                            EventArgs_FormLabelMessage arg = new EventArgs_FormLabelMessage();
                            arg.message = e.message;
                            arg.state = EMessageState.None;
                            SECSReplierMessage_DoLabel1Message_Event(sender, arg);
                        });
                        break;
                }

                tb_msg1.Text = e.message;
            }
        }

        private void ConnectionCenterEventBind()
        {
            connectionCenter.ConnectState_Event += connectionCenter_ConnectState_Event;
            connectionCenter.Client_Event += connectionCenter_Client_Event;
            connectionCenter.MsgBase_Event += connectionCenter_MsgBase_Event;
            connectionCenter.ReceiveSECSMsg_Event += connectionCenter_ReceiveSECSMsg_Event;
            connectionCenter.SendSECSMsg_Event += connectionCenter_SendSECSMsg_Event;

            connectionCenter.Timeout_Event += connectionCenter_Timeout_Event;
        }



        void connectionCenter_Timeout_Event(object sender, EventArgs_SingleString e)
        {
            tabs1.DoTimeoutWriteIn(e.theString);
        }

        private void TittleEventBind()
        {
            tittle1.DoOpenPathEvent += tittle1_DoOpenPathEvent;
        }

        private void TabsEventBind()
        {
            tabs1.SendMsg_Event += tabs1_SendMsg_Event;
        }

        private void SECSsystem_DoMessageBoxShowEvent(object sender, EventArgs_SingleMessage e)
        {
            if (string.IsNullOrEmpty(e.tittle))
            {
                System.Windows.Forms.MessageBox.Show(e.message);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(e.message, e.tittle);
            }
        }

        void tabs1_SendMsg_Event(object sender, EventArgs_TheMessage e)
        {
            connectionCenter.SendMessage = e.themsg;
        }

        private void tittle1_DoOpenPathEvent(object sender, EventArgs_SingleString e)
        {
            tabs1.DoOpenFile(e.theString);
        }

        void connectionCenter_SendSECSMsg_Event(object sender, EventArgs_TheMessage e)
        {
            tabs1.SetNewSECSMessage = e;
        }

        void connectionCenter_ReceiveSECSMsg_Event(object sender, EventArgs_TheMessage e)
        {
            tabs1.SetNewSECSMessage = e;

            lock (linkTable_multiThread_lock)
            {
                List<SECSmsg> shouldbeSend = LinkTableCenter.GetDatasSend_By_ReceivedMsg(e.themsg.SECS_Msg);
                foreach (SECSmsg msg in shouldbeSend)
                {
                    TheMessage beSend = new TheMessage();
                    beSend.SF = msg.GetSF_string;
                    beSend.ID = e.themsg.ID;
                    beSend.SECS_Msg = msg;
                    beSend.Msg = msg.ToString();
                    connectionCenter.SendMessage = beSend;
                }
            }
        }

        void connectionCenter_MsgBase_Event(object sender, EventArgs_TheMessage e)
        {
            tabs1.SetNewMessage = e;
        }

        void connectionCenter_Client_Event(object sender, EventArgs_Client e)
        {
            tabs1.ClientArg(e);
        }

        void connectionCenter_ConnectState_Event(object sender, EventArgs_EConnectState e)
        {
            SECSsystem.SystemConnectState_TCPIP = e.nowState;
            if (e.nowState != EConnectState.Disconnect) { tittle1.DoLockRoleChanger(true); } else { tittle1.DoLockRoleChanger(false); }
            if (e.nowState == EConnectState.Error && !string.IsNullOrEmpty(e.errorCode))
            {
                //MessageBox.Show(e.errorCode,"Connect Error");
                SECSReplierMessage.LabelStateMessage(e.nowState.ToString(), EMessageState.Error);
            }
            else
            {
                switch (e.nowState)
                {
                    case EConnectState.Connected:
                        SECSReplierMessage.LabelStateMessage(e.nowState.ToString(), EMessageState.Succeed);
                        break;
                    default:
                        SECSReplierMessage.LabelStateMessage(e.nowState.ToString());
                        break;
                
                }

                SECSReplierMessage.Label2Message(string.Format(
                    "{0} to IP[{1}], Port[{2}] as {3}"
                    ,SECSsystem.SystemConnectState_TCPIP
                    ,SECSsystem.HostIP
                    ,SECSsystem.Port
                    ,SECSsystem.SECSRole.ToString()
                ), EMessageState.Succeed);
            }

            tittle1.DoConnectionStateChange();
        }

        private void tittle1_DoConnectTryEvent(object sender, EventArgs e)
        {
            if (SECSsystem.SECSRole == ESECSRole.Server)
            {
                if (SECSsystem.SystemConnectState_TCPIP == EConnectState.Connecting)
                {
                    connectionCenter.Disconnect();
                }
                else
                {
                    connectionCenter.DoConnectAsServer(SECSsystem.HostIP, SECSsystem.Port);
                }
            }
            else if (SECSsystem.SECSRole == ESECSRole.Client)
            {
                if (SECSsystem.SystemConnectState_TCPIP == EConnectState.Connecting)
                {
                    connectionCenter.Disconnect();
                }
                else
                {
                    connectionCenter.DoConnectAsClient(SECSsystem.HostIP, SECSsystem.Port);
                }
            }
            
        }

        private void _DoOfflineEvent(object sender, EventArgs e)
        {
            connectionCenter.Disconnect();
        }

        private void SECSReplier_Load(object sender, EventArgs e)
        {
            SECSsystem.DoWhileOpenAppEvent_1 += SECSsystem_DoWhileOpenAppEvent_1;
        }

        void SECSsystem_DoWhileOpenAppEvent_1(object sender, EventArgs_SingleString e)
        {
            if (this.InvokeRequired)
            {
                tab1_Change del = new tab1_Change(SECSsystem_DoWhileOpenAppEvent_1);
                this.Invoke(del, new object[] { sender, e });
            }
            else
            {
                tabs1.DoOpenFile(e.theString);
            }
        }

        private void tittle1_DoOfflineEvent(object sender, EventArgs e)
        {

        }
    }

}
