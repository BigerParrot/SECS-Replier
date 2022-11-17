using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SECSLibs;

namespace SECSCtrlLibs
{
    public partial class ConnectionForm : Form
    {
        public event EventHandler<EventArg_IPPort> ConnectionEvent;
        private IPAddress ipChoose;
        private int port;
        private int errorCase = -1;

        EConnectState nowState = EConnectState.None;

        public EConnectState State { set { nowState = value; setButtons(); } }

        //public 
        public ConnectionForm()
        {
            InitializeComponent();

        }

        public bool SetIPPort(IPAddress ip, int po)
        {
            cbx_IP.Text = ip.ToString();
            tb_Port.Text = po.ToString();

            CheckAble();
            return true;
        }

        private void setButtons()
        {
            if (nowState == EConnectState.Disconnect)
            {
                bS_Connect.Text_Button = string.Format("Connect");
                bS_Connect.BackColor = Color.FromKnownColor(KnownColor.GreenYellow);

                cbx_IP.Enabled = true;
                tb_Port.Enabled = true;
                tb_Name.Enabled = true;

                bS_Connect.bS_Style = EButtonStyle1.locked;
                CheckAble();
            }
            else if (nowState == EConnectState.Connecting)
            {
                bS_Connect.Text_Button = string.Format("Stop Connecting");
                bS_Connect.BackColor = Color.FromKnownColor(KnownColor.Gold);

                cbx_IP.Enabled = false;
                tb_Port.Enabled = false;
                tb_Name.Enabled = false;

                bS_Connect.bS_Style = EButtonStyle1.None;
            }
        }

        private void CheckAble()
        {
            //判斷1
            errorCase = 1;
            bool isIP = IPAddress.TryParse(cbx_IP.Text, out ipChoose);
            if (!isIP) { bS_Connect.bS_Style = EButtonStyle1.locked; bS_Question.Visible = true; return; }

            //判斷2
            errorCase = 2;
            if (string.IsNullOrEmpty(tb_Port.Text)) { port = 0; } else { port = int.Parse(tb_Port.Text); }
            if (port < 0 || port > 65536) { bS_Connect.bS_Style = EButtonStyle1.locked; bS_Question.Visible = true; return; }

            //判斷3
            errorCase = 3;
            if (string.IsNullOrEmpty(tb_Name.Text)) { bS_Connect.bS_Style = EButtonStyle1.locked; bS_Question.Visible = true; return; }

            errorCase = -1;
            bS_Question.Visible = false;
            bS_Connect.bS_Style = EButtonStyle1.None;
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

        /// <summary>
        /// 取得所有IP資訊
        /// </summary>
        /// <returns>回傳IPs</returns>
        private IPAddress[] GetAddress()
        {
            string name = Dns.GetHostName();
            return Dns.GetHostAddresses(name);
        }

        private void cbx_IP_TextChanged(object sender, EventArgs e)
        {
            CheckAble();
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            CheckAble();
        }

        private void tb_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (!((int)e.KeyChar == 8 || (int)e.KeyChar == 13)) { e.Handled = true; }
            }
        }

        private void bS_Leave_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void bS_Refresh_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            cbx_IP.Text = string.Empty;
        }

        private void bS_Question_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            switch (errorCase)
            {
                case 1:
                    MessageBox.Show("The IP parameter was in wrong form.");
                    break;
                case 2:
                    MessageBox.Show("The Port parameter was out of range.");
                    break;
                case 3:
                    MessageBox.Show("The NickName field should not be empty.");
                    break;
            }
        }

        private void bS_Connect_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            EventArg_IPPort arg = new EventArg_IPPort();
            arg.IP = ipChoose;
            arg.Port = port;

            if (ConnectionEvent != null)
            {
                ConnectionEvent.Invoke(this, arg);
            }

            this.Hide();
        }

    }

    public class EventArg_IPPort : EventArgs
    {
        public IPAddress IP = null;
        public int Port = 0;
    }
}
