using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SECSCtrlLibs;
using SECSLibs;
using System.Threading;
using System.IO;

namespace SECSTry.UControl
{
    public partial class Tittle : UserControl
    {
        
        public event EventHandler DoConnectTryEvent;
        public event EventHandler DoOfflineEvent;
        public event EventHandler<EventArgs_SingleString> DoOpenPathEvent;

        private delegate void DoChangeConnectionState();
        private delegate void DoChangeConnectionState2( bool lo);
        private delegate void CloseMethod(object sender, EventArgs e);

        private bool resizeState = false;
        private ConnectionForm connectionForm = new ConnectionForm();
        public Tittle()
        {
            InitializeComponent();

            SECSsystem.SECSsystem_SystemParas_Event += SECSsystem_SECSsystem_SystemParas_Event;
            SECSsystem.DoRoleChangeEvent += SECSsystem_DoRoleChangeEvent;
            connectionForm.ConnectionEvent += connectionForm_ConnectionEvent;
        }

        public void DoLockRoleChanger(bool locking)
        {
            if (this.InvokeRequired)
            {
                DoChangeConnectionState2 del = new DoChangeConnectionState2(DoLockRoleChanger);
                this.Invoke(del, locking);
            }
            else
            {
                if (locking) { bS1_systemType.bS_Style = EButtonStyle1.locked; } else { bS1_systemType.bS_Style = EButtonStyle1.None; }
            }
            
        }

        void SECSsystem_DoRoleChangeEvent(object sender, EventArgs e)
        {
            DoRoleChange();
        }

        void SECSsystem_SECSsystem_SystemParas_Event(object sender, EventArgs_SystemParas e)
        {
            //啟動時，自動連線功能
            connectionForm.SetIPPort(SECSsystem.HostIP, SECSsystem.Port);
            if (e.isAutoConnect)
            {
                EventArg_IPPort arg = new EventArg_IPPort();
                arg.IP = SECSsystem.HostIP;
                arg.Port = SECSsystem.Port;
                Task.Factory.StartNew(()=>{
                    Thread.Sleep(500);
                    connectionForm_ConnectionEvent(new object(), arg);
                });
                
            }

            //設定Server或Client
            DoRoleChange();
        }

        private void DoRoleChange()
        {
            if (SECSsystem.SECSRole == ESECSRole.Server) { bS1_systemType.Text_Button = "Server"; } else { bS1_systemType.Text_Button = "Client"; }
        }

        public void DoConnectionStateChange()
        {
            if (this.InvokeRequired)
            {
                DoChangeConnectionState del = new DoChangeConnectionState(DoConnectionStateChange);
                this.BeginInvoke(del);
            }
            else
            {
                switch (SECSsystem.SystemConnectState_TCPIP)
                {
                    case EConnectState.Connecting:
                        bS_Connection.bS_Style = EButtonStyle1.Warrning;
                        bS_Connection.BtnImageIndex = 1;
                        bS_Connection.ButtonWarnningColor1_KnownColor = Color.FromKnownColor(KnownColor.Yellow);
                        bS_Connection.ButtonWarnningColor2_KnownColor = Color.FromKnownColor(KnownColor.LightYellow);
                        break;
                    case EConnectState.Connected:
                        bS_Connection.bS_Style = EButtonStyle1.None;
                        bS_Connection.BtnImageIndex = 0;
                        bS_Connection.ButtonNoneColor_KnownColor = Color.FromKnownColor(KnownColor.LightGreen);
                        break;
                    default:
                        bS_Connection.bS_Style = EButtonStyle1.Warrning;
                        bS_Connection.BtnImageIndex = 1;
                        bS_Connection.ButtonWarnningColor1_KnownColor = Color.FromKnownColor(KnownColor.Red);
                        bS_Connection.ButtonWarnningColor2_KnownColor = Color.FromKnownColor(KnownColor.MistyRose);
                        break;
                }
            }
        }

        private void connectionForm_ConnectionEvent(object sender, EventArg_IPPort e)
        {
            SECSsystem.HostIP = e.IP;
            SECSsystem.Port = e.Port;

            if (DoConnectTryEvent != null)
            {
                DoConnectTryEvent.Invoke(sender, new EventArgs());
            }
        }

        private void bS_Close_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            Form f = this.ParentForm;
            if (!f.IsDisposed)
            {
                if (f.InvokeRequired)
                {
                    CloseMethod method = new CloseMethod(bS_Close_ButtonStyle1_OnclickEvent);
                    f.Invoke(method, new object[] { sender, e });
                }
                else
                {
                    SECSsystem.DoBeforeCloseAppEvent(); //再關閉應用程式前，完成所有事件
                    f.Close();
                }
            }
        }

        private void bS_Resize_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            resizeState = !resizeState;

            if (resizeState)
            {
                this.ParentForm.MaximumSize = new Size(0, 0);
                this.ParentForm.SuspendLayout();
                this.ParentForm.FormBorderStyle = FormBorderStyle.None;
                this.ParentForm.WindowState = FormWindowState.Maximized;
                //this.ParentForm.TopMost = true; (將視窗顯示在最上層)
                this.ParentForm.ResumeLayout();
            }
            else
            {
                this.ParentForm.MaximumSize = this.ParentForm.MinimumSize;
                this.ParentForm.SuspendLayout();
                this.ParentForm.FormBorderStyle = FormBorderStyle.Sizable;
                this.ParentForm.WindowState = FormWindowState.Normal;
                this.ParentForm.TopMost = false;
                this.ParentForm.ResumeLayout();
            }
        }

        private void bS_min_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }

        private void bS_Connection_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            if (SECSsystem.SystemConnectState_TCPIP != EConnectState.Connected)
            {
                connectionForm.State = SECSsystem.SystemConnectState_TCPIP;
                connectionForm.StartPosition = FormStartPosition.CenterParent;
                connectionForm.ShowDialog();
            }
            else
            {
                DialogResult r = MessageBox.Show("Are you sure to offline?", "Warn", MessageBoxButtons.YesNo);
                if (r.Equals(DialogResult.Yes) && DoOfflineEvent != null)
                {
                    DoOfflineEvent.Invoke(sender, new EventArgs());
                }
            }
            
        }

        private void OpenFile_MI_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            FileOpenForm opForm = new FileOpenForm( EFileFormType.Files);
            opForm.StartPosition = FormStartPosition.CenterParent;
            opForm.ShowDialog();

            if (!string.IsNullOrEmpty(opForm.PathSelect) && DoOpenPathEvent != null)
            {
                SECSsystem.IsFileBeenWorked = false;
                SECSsystem.IsFileBeenWorked = true;
                EventArgs_SingleString arg = new EventArgs_SingleString();
                arg.theString = opForm.PathSelect;
                SECSsystem.SystemInitOpenFile = opForm.PathSelect;
                DoOpenPathEvent.Invoke(this, arg);

                SECSReplierMessage.Label1Message(string.Format("Opened the File: {0}", opForm.PathSelect), EMessageState.Succeed);
            }

            opForm.Dispose();
        }

        private void bS1_systemType_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            if (SECSsystem.SECSRole == ESECSRole.Server)
            {
                SECSsystem.SECSRole = ESECSRole.Client;
                bS1_systemType.Text_Button = "Client";
            }
            else
            {
                SECSsystem.SECSRole = ESECSRole.Server;
                bS1_systemType.Text_Button = "Server";
            }
        }

        private void NewFile_MI_Click(object sender, EventArgs e)
        {
            if (SECSsystem.IsFileBeenWorked)
            {
                DialogResult r = MessageBox.Show("Are you sure to close current project, first?", "Warnning", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    SECSsystem.SystemInitOpenFile = string.Empty;
                    SECSsystem.IsFileBeenWorked = false;
                }
                else
                {
                    return;
                }
            }
            SECSsystem.IsFileBeenWorked = true;
            SECSReplierMessage.Label1Message(string.Format("New File has been create"), EMessageState.Succeed);
        }

        private void CloseFile_MI_Click(object sender, EventArgs e)
        {
            if (SECSsystem.IsFileBeenWorked)
            {
                DialogResult r = MessageBox.Show("Are you sure to close current project?", "Warnning", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    SECSsystem.SystemInitOpenFile = string.Empty;
                    SECSsystem.IsFileBeenWorked = false;

                    SECSReplierMessage.Label1Message(string.Format("File has been closed"), EMessageState.Normal);
                }
                else
                {
                    return;
                }
            }
        }

        private void save_MI_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SECSsystem.SystemInitOpenFile))
            {
                FileNameRequestForm f = new FileNameRequestForm();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();

                if (string.IsNullOrEmpty(f.FileName)) { return; }
                SECSsystem.SystemInitOpenFile = string.Format("{0}\\{1}.xml", SECSsystem.SecsDGVfileFolder, f.FileName);
            }
            SECSsystem.DoSaveDGVFile();
            SECSReplierMessage.Label1Message(string.Format("File saved: {0}", SECSsystem.SystemInitOpenFile), EMessageState.Succeed);
        }

        private void File_MI_DropDownOpening(object sender, EventArgs e)
        {
            if (SECSsystem.IsFileBeenWorked)
            {
                save_MI.Enabled = true;
                saveAs_MI.Enabled = true;
            }
            else
            {
                save_MI.Enabled = false;
                saveAs_MI.Enabled = false;
            }
        }

        private void saveAs_MI_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Can use saveFileDialog1.FileName
                using (Stream stream = saveFileDialog1.OpenFile())
                {
                    SECSsystem.SystemInitOpenFile = saveFileDialog1.FileName;
                }
                SECSsystem.DoSaveDGVFile();
                SECSReplierMessage.Label1Message(string.Format("File saved: {0}", SECSsystem.SystemInitOpenFile), EMessageState.Succeed);
            }
        }

        private void ServerState3_MI_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) { return; }

            int tag = int.Parse(item.Tag.ToString());

            switch (tag)
            {
                case 1:
                    ServerState1_MI.Checked = true;
                    ServerState2_MI.Checked = false;
                    ServerState3_MI.Checked = false;
                    SECSsystemConnectionConfigure.ServerMode = EServerAllowMode.Multi;
                    break;
                case 2:
                    ServerState1_MI.Checked = false;
                    ServerState2_MI.Checked = true;
                    ServerState3_MI.Checked = false;
                    SECSsystemConnectionConfigure.ServerMode = EServerAllowMode.Single_First;
                    break;
                case 3:
                    ServerState1_MI.Checked = false;
                    ServerState2_MI.Checked = false;
                    ServerState3_MI.Checked = true;
                    SECSsystemConnectionConfigure.ServerMode = EServerAllowMode.Single_Latest;
                    break;
                default:
                    return;
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            int num = 200;
            if (string.IsNullOrEmpty(toolStripTextBox1.Text)) { return; }
            if (!int.TryParse(toolStripTextBox1.Text, out num))
            {
                toolStripTextBox1.Text = "200";
            }
        }

        private void toolStripTextBox1_MouseLeave(object sender, EventArgs e)
        {
            int num = 200;
            if (!string.IsNullOrEmpty(toolStripTextBox1.Text))
            {
                int.TryParse(toolStripTextBox1.Text, out num);
            }
            if (num > 1000 || num < 100) { num = 200; toolStripTextBox1.Text = "200"; }

            SECSsystem.LogRenewNum = num;
        }

    }
}
