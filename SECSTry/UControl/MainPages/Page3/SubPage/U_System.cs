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
using System.Net;

namespace SECSTry
{
    public partial class U_System : UserControl
    {
        private EventArgs_SystemParas systemArg = new EventArgs_SystemParas();
        private int tempKeepDays = 0;
        public U_System()
        {
            InitializeComponent();

            SECSsystem.SECSsystem_SystemParas_Event += SECSsystem_SECSsystem_SystemParas_Event;
            SECSsystem.DoRoleChangeEvent += SECSsystem_DoRoleChangeEvent;
            SECSsystem.InitSystemParameter();

            InitCbx();

            SECSsystem.DoBeforeCloseAppEvent_1 += SECSsystem_DoBeforeCloseAppEvent_1;
        }

        void SECSsystem_DoRoleChangeEvent(object sender, EventArgs e)
        {
            if (SECSsystem.SECSRole == ESECSRole.Server) { ck_AsServer.Checked = true; ck_AsClient.Checked = false; } else { ck_AsClient.Checked = true; ck_AsServer.Checked = false; }
        }

        void SECSsystem_DoBeforeCloseAppEvent_1(object sender, EventArgs e)
        {
            DoSaveSystemChange();
        }

        private void SECSsystem_SECSsystem_SystemParas_Event(object sender, EventArgs_SystemParas e)
        {
            ck_AutoConnect.Checked = e.isAutoConnect;

            cbx_IP.Text = e.ip;

            tb_Port.Text = e.port.ToString();

            ck_AsServer.Checked = e.asServer;
            ck_AsClient.Checked = e.asClient;

            if (e.asServer) { SECSsystem.SECSRole = ESECSRole.Server; } else { SECSsystem.SECSRole = ESECSRole.Client; }

            ck_Preset1.Checked = e.isPreset1;
            if (!ck_Preset1.Checked)
            {
                tb_FolderPath1.Text = e.folderPath1;
            }
            ck_ReadLatest.Checked = e.isReadLatestFile;
            ck_AutoSaveFile.Checked = e.isAutoSave;

            ck_Preset2.Checked = e.isPreset2;
            if (!ck_Preset2.Checked)
            {
                tb_FolderPath2.Text = e.folderPath2;
            }

            tempKeepDays = e.keepDays;

            systemArg = e;
        }

        private void InitCbx()
        {
            cbx_KeepDays.Items.Clear();

            cbx_KeepDays.Items.Add("10");
            cbx_KeepDays.Items.Add("30");
            cbx_KeepDays.Items.Add("90");
            cbx_KeepDays.Items.Add("180");

            cbx_KeepDays.SelectedIndex = cbx_KeepDays.FindString(tempKeepDays.ToString());

        }

        /// <summary>
        /// 取得所有IP資訊
        /// </summary>
        /// <returns>回傳IPs</returns>
        private IPAddress[] GetAddress()
        {
            string name = Dns.GetHostName();
            return Dns.GetHostAddresses(name);
        }

        private void ck_AsServer_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_AsServer.Checked) 
            {
                if (SECSsystem.SystemConnectState_TCPIP != EConnectState.Disconnect)
                {
                    DialogResult r = MessageBox.Show("If changing the role, you should reconnect manually", "Warnning", MessageBoxButtons.YesNo);
                    if (r != DialogResult.Yes) { ck_AsServer.Checked = false; return; } else { SECSsystem.DoDisconnect(); }
                }
                ck_AsClient.Checked = false; 
            }
            else { ck_AsClient.Checked = true; SECSsystem.SECSRole = ESECSRole.Client; }
            
            systemArg.asServer = ck_AsServer.Checked;
        }

        private void ck_AsClient_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_AsClient.Checked) 
            {
                if (SECSsystem.SystemConnectState_TCPIP != EConnectState.Disconnect)
                {
                    DialogResult r = MessageBox.Show("If changing the role, you should reconnect manually", "Warnning", MessageBoxButtons.YesNo);
                    if (r != DialogResult.Yes) { ck_AsClient.Checked = false; return; } else { SECSsystem.DoDisconnect(); }
                }
                ck_AsServer.Checked = false; 
            } 
            else { ck_AsServer.Checked = true; SECSsystem.SECSRole = ESECSRole.Server; }
            systemArg.asClient = ck_AsClient.Checked;
        }

        private void bS1_FolderDatas_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            FileOpenForm nForm = new FileOpenForm(EFileFormType.Folders);
            nForm.StartPosition = FormStartPosition.CenterParent;
            nForm.ShowDialog();

            if (!string.IsNullOrEmpty(nForm.PathSelect))
            {
                tb_FolderPath1.Text = nForm.PathSelect;
                SECSsystem.SecsDGVfileFolder = nForm.PathSelect;
                ck_Preset1.Checked = false;
                ck_Preset1.Enabled = true;

                systemArg.isPreset1 = false;
                systemArg.folderPath1 = nForm.PathSelect;
            }
            else
            {
                SECSsystem.SecsDGVfileFolder = string.Empty;
            }
            
            nForm.Dispose();
        }

        private void bS1_FolderLogger_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            FileOpenForm nForm = new FileOpenForm(EFileFormType.Folders);
            nForm.StartPosition = FormStartPosition.CenterParent;
            nForm.ShowDialog();

            if (!string.IsNullOrEmpty(nForm.PathSelect))
            {
                tb_FolderPath2.Text = nForm.PathSelect;
                ck_Preset2.Checked = false;
                ck_Preset2.Enabled = true;

                systemArg.isPreset2 = false;
                systemArg.folderPath2 = nForm.PathSelect;
            }
            
            nForm.Dispose();
        }

        private void ck_Preset1_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Preset1.Checked)
            {
                tb_FolderPath1.Text = string.Format("(Preset folder path...)");
                ck_Preset1.Enabled = false;

                systemArg.isPreset1 = true;
                systemArg.folderPath1 = string.Empty;

                label2.Focus();
            }
        }

        private void ck_Preset2_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Preset2.Checked)
            {
                tb_FolderPath2.Text = string.Format("(Preset folder path...)");
                ck_Preset2.Enabled = false;

                systemArg.isPreset2 = true;
                systemArg.folderPath2 = string.Empty;

                label3.Focus();
            }
        }

        private void ck_ReadLatest_CheckedChanged(object sender, EventArgs e)
        {
            systemArg.isReadLatestFile = ck_ReadLatest.Checked;
        }

        private void cbx_KeepDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            systemArg.keepDays = int.Parse(cbx_KeepDays.Text);
        }

        private void tb_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (!((int)e.KeyChar == 8 || (int)e.KeyChar == 13))
                {
                    e.Handled = true;
                }
            }
            else if (tb_Port.TextLength >= 5)
            {
                e.Handled = true;
            }
        }

        private void tb_Port_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Port.Text)) { systemArg.port = 0; } else { systemArg.port = int.Parse(tb_Port.Text);}
        }

        private void ck_AutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            systemArg.isAutoConnect = ck_AutoConnect.Checked;
        }

        private void cbx_IP_TextChanged(object sender, EventArgs e)
        {
            systemArg.ip = cbx_IP.Text;
        }


        private void DoSaveSystemChange()
        {
            SECSsystem.BuildSysInitFile(systemArg, false);
        }

        private void connect_Leave(object sender, EventArgs e)
        {
            //DoSaveSystemChange();
        }

        private void datas_logger_Leave(object sender, EventArgs e)
        {
            //DoSaveSystemChange();
        }

        private void cbx_IP_DropDown(object sender, EventArgs e)
        {
            cbx_IP.Items.Clear();
            foreach (IPAddress cel in GetAddress())
            {
                cbx_IP.Items.Add(cel);
            }
            cbx_IP.Items.Add(IPAddress.Parse("127.0.0.1"));
        }

        private void ck_AutoSaveFile_CheckedChanged(object sender, EventArgs e)
        {
            systemArg.isAutoSave = ck_AutoSaveFile.Checked;
            SECSsystem.IsAutoSaveDGVfile = ck_AutoSaveFile.Checked;
        }

        private void bS1_Que_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            MessageBox.Show(
                "As Server (Passive - Should be Equipment) \n" +
                "As Client (Active - Should be Host)"
            );
        }

    }
    public class EventArgs_SystemParas : EventArgs
    {
        public bool isAutoConnect = false;
        public string ip = string.Empty;
        public int port = 0;
        public bool asServer = false;
        public bool asClient = false;

        public bool isPreset1 = false;
        public string folderPath1 = string.Empty;
        public bool isReadLatestFile = false;
        public bool isAutoSave = false;

        public bool isPreset2 = false;
        public string folderPath2 = string.Empty;
        public int keepDays = 0;
    }
}
