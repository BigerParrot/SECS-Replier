using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SECSLibs;

namespace SECSTry.UControl.MainPages
{
    public partial class Tabs : UserControl
    {
        public event EventHandler<EventArgs_TheMessage> SendMsg_Event;

        private Timer loggerTimer = new Timer();
        private int nowSelect = -1;
        private int clearNum = 200;

        public EventArgs_TheMessage SetNewMessage { set { DoSetNewMsg(value); } }
        public EventArgs_TheMessage SetNewSECSMessage { set { DoSetNewSECSMsg(value); } }

        Dictionary<int, TheMessage> msgDic = new Dictionary<int,TheMessage>();

        Queue<int> SFbeenAdd = new Queue<int>();

        object ob = new object();

        private bool LoggerSpread
        {
            get
            {
                if (bS_lift.BtnImageIndex == 0) { return false; }
                else if (bS_lift.BtnImageIndex == 1) { return true; }
                return false;
            }
        }
        public Tabs()
        {
            InitializeComponent();

            loggerTimer.Interval = 1;
            loggerTimer.Tick += loggerTimer_Tick;

            loggers_Ctrl11.SFChoose_Event += loggers_Ctrl11_SFChoose_Event;
            loggers_Ctrl21.DoCopyIndex_Event += loggers_Ctrl21_DoCopyIndex_Event;

            page1_UCtrl1.SendMsg_Event += page1_UCtrl1_SendMsg_Event;

            SECSsystem.DoRenewChangeEvent += SECSsystem_DoRenewChangeEvent;
        }

        void SECSsystem_DoRenewChangeEvent(object sender, EventArgs e)
        {
            clearNum = SECSsystem.LogRenewNum;
        }

        void page1_UCtrl1_SendMsg_Event(object sender, EventArgs_TheMessage e)
        {
            if (SendMsg_Event != null)
            {
                SendMsg_Event.Invoke(sender, e);
            }
        }

        public bool DoOpenFile(string path)
        {
            return page1_UCtrl1.OpenFileByPath(path, false);
        }

        public void DoTimeoutWriteIn(string txt)
        {
            lock (ob)
            {
                EventArg_SF sf = new EventArg_SF();
                sf.SF = string.Format("-Out-");

                loggers_Ctrl11.Add_SF = sf;
                loggers_Ctrl21.AddText_MsgBase(txt, sf.SF);
            }
            
        }

        public void ClientArg(EventArgs_Client client)
        {
            controller_UC11.DoClientsChange(client);
        }

        void loggers_Ctrl21_DoCopyIndex_Event(object sender, EventArgs_SingleInt e)
        {
            if (msgDic.ContainsKey(nowSelect - 1))
            {
                SECSsystem.SECS_Clipboard = msgDic[nowSelect - 1].SECS_Msg;
            }
        }

        void loggers_Ctrl11_SFChoose_Event(object sender, EventArg_SF e)
        {
            loggers_Ctrl21.Select_MsgBase(e.num);
            nowSelect = e.num;
            loggers_Ctrl21.Select_Msg(e.num);
        }

        private void DoSetNewMsg(EventArgs_TheMessage msg)
        {
            lock (ob)
            {
                EventArg_SF sf = new EventArg_SF();
                sf.SF = msg.themsg.SF;
                if (msg.themsg.SECS_Msg.Stream != 0 && msg.themsg.SECS_Msg.Function != 0)
                {
                    SFbeenAdd.Enqueue(loggers_Ctrl21.Records_MsgBase.Count);
                }
                sf.isReceive = msg.IsReceive;
                sf.isSend = msg.IsSend;

                loggers_Ctrl11.Add_SF = sf;
                loggers_Ctrl21.AddText_MsgBase(msg.themsg.Msg, msg.themsg.SF);
            }
        }

        private void DoSetNewSECSMsg(EventArgs_TheMessage msg)
        {
            if (msgDic.Count > clearNum) { DoClearDic(); }
            if (SFbeenAdd.Count > 0)
            {
                loggers_Ctrl21.AddText_Msg(msg.themsg.Msg, msg.themsg.SF);
                msgDic.Add(SFbeenAdd.Dequeue(), msg.themsg);
            }
            else
            {
                loggers_Ctrl21.AddText_Msg(msg.themsg.Msg, msg.themsg.SF);
                int x = loggers_Ctrl21.Records_MsgBase.Count - 1;
                while (x < loggers_Ctrl21.Records_MsgBase.Count + 10)
                {
                    if (!msgDic.ContainsKey(x))
                    {
                        msgDic.Add(x, msg.themsg);
                        break;
                    }
                    x++;
                }
            }
            
        }

        void loggerTimer_Tick(object sender, EventArgs e)
        {
            TableLayoutColumnStyleCollection cStyle = tlp_Logger.ColumnStyles;
            if (LoggerSpread && tlp_Logger.ColumnStyles[0].Width > 0)
            {
                if(tlp_Logger.ColumnStyles[0].Width - 10 < 0) { tlp_Logger.ColumnStyles[0].Width = 0; } else { tlp_Logger.ColumnStyles[0].Width -= 10; }
                if (tlp_Logger.ColumnStyles[0].Width <= 0) { loggers_Ctrl11.ResumeLayout(); loggerTimer.Stop(); }
            }
            else
            {
                tlp_Logger.ColumnStyles[0].Width += 10;
                if (tlp_Logger.ColumnStyles[0].Width >= 100) { loggers_Ctrl11.ResumeLayout(); loggerTimer.Stop(); }
            }
        }

        private void bS_lift_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {   
            loggers_Ctrl11.SuspendLayout();
            if (LoggerSpread)
            {
                bS_lift.BtnImageIndex = 0;
            }
            else
            {
                bS_lift.BtnImageIndex = 1;
            }
            if (!loggerTimer.Enabled) { loggerTimer.Start(); }
        }

        private void DoClearDic()
        {
            msgDic.Clear();
            SFbeenAdd.Clear();
            nowSelect = -1;
            loggers_Ctrl11.DoClear();
            loggers_Ctrl21.DoClear();
        }
    }
}
