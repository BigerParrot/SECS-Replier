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
using System.Net;
using System.Threading;

namespace SECSTry
{
    public partial class U_SECS : UserControl
    {
        private delegate void MyDelegate(object sender, EventArgs e);
        System.Windows.Forms.Timer timerColor = new System.Windows.Forms.Timer();
        private int oneSecCount = 0;
        Dictionary<int, int> timeList = new Dictionary<int,int>();

        SubItem1 it1 = new SubItem1();
        SubItem2 it2 = new SubItem2();
        bool fixState = false;

        public bool IsSECSIchecked { get { return it2.IsSECSIchecked; } }

        public bool IsHSMSchecked { get { return it2.IsHSMSchecked; } }

        public U_SECS()
        {
            InitializeComponent();

            timerColor.Interval = 1;
            timerColor.Tick += timerColor_Tick;

            pl_Switch.Controls.Clear();
            it1.Dock = DockStyle.Fill;
            pl_Switch.Controls.Add(it1);

            it2.DoCheckChange += it2_DoCheckChange;
            DoVisibleChange();

            for (int i = 0; i < 8; i++) { timeList.Add(i, 0); }
            InitAllTimeoutValue();
            DoChangeValue();
            DoCheckValue();
            DoFixedState();
        }

        void it2_DoCheckChange(object sender, EventArgs e)
        {
            DoVisibleChange();
        }

        private void DoVisibleChange()
        {
            if (it2.IsSECSIchecked)
            {
                tb_T1.Visible = true;
                tb_T2.Visible = true;
                tb_T3.Visible = true;
                tb_T4.Visible = true;

                tb_T5.Visible = false;
                tb_T6.Visible = false;
                tb_T7.Visible = false;
                tb_T8.Visible = false;
            }
            else
            {
                tb_T1.Visible = false;
                tb_T2.Visible = false;
                tb_T4.Visible = false;

                tb_T3.Visible = true;
                tb_T5.Visible = true;
                tb_T6.Visible = true;
                tb_T7.Visible = true;
                tb_T8.Visible = true;
            }

            if (it2.IsSECSIchecked) { MessageBox.Show("SECSI function was unable to use.");}
        }

        void timerColor_Tick(object sender, EventArgs e)
        {
            oneSecCount ++;
            if (oneSecCount >= 50)
            {
                foreach (Control c in tlp_1.Controls)
                {
                    if (c is TextBox)
                    {
                        if (string.IsNullOrEmpty(((TextBox)c).Text))
                        {
                            ((TextBox)c).BackColor = Color.FromKnownColor(KnownColor.Window);
                        }
                    }
                }
                timerColor.Stop();
            }
        }

        private void InitAllTimeoutValue()
        {
            tb_T1.Text = string.Format("1");
            tb_T2.Text = string.Format("10");
            tb_T3.Text = string.Format("45");
            tb_T4.Text = string.Format("45");
            tb_T5.Text = string.Format("10");
            tb_T6.Text = string.Format("5");
            tb_T7.Text = string.Format("10");
            tb_T8.Text = string.Format("5");
        }

        private void DoCheckValue()
        {
            bool hasChange = false;
            foreach (Control c in tlp_1.Controls)
            {
                if (c is TextBox)
                {
                    int tag = int.Parse(((TextBox)c).Tag.ToString());
                    if (timeList.ContainsKey(tag))
                    {
                        int v = 0;
                        if (!string.IsNullOrEmpty(((TextBox)c).Text)) { v = int.Parse(((TextBox)c).Text); }
                        if (timeList[tag] != v)
                        {
                            hasChange = true;
                            ((TextBox)c).BackColor = Color.FromKnownColor(KnownColor.Honeydew);
                        }
                        else
                        {
                            ((TextBox)c).BackColor = Color.FromKnownColor(KnownColor.Window);
                        }
                    }
                }
            }

            if (hasChange) { bS1_Exect.bS_Style = EButtonStyle1.None; } else { bS1_Exect.bS_Style = EButtonStyle1.locked; }
        }

        private void DoChangeValue()
        {
            foreach (Control c in tlp_1.Controls)
            {
                if (c is TextBox)
                {
                    int tag = int.Parse(((TextBox)c).Tag.ToString());
                    if (timeList.ContainsKey(tag))
                    {
                        int v = 0;
                        if (!string.IsNullOrEmpty(((TextBox)c).Text)) { v = int.Parse(((TextBox)c).Text); }
                        timeList[tag] = v;
                        ((TextBox)c).BackColor = Color.FromKnownColor(KnownColor.Window);
                    }
                }
            }

            fixState = false;
            DoFixedState();

            TimeoutSystem.TimerList = timeList;
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (!((int)e.KeyChar == 8 || (int)e.KeyChar == 13)) { e.Handled = true; }
            }
        }

        private void bS1_TimerQues_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            MessageBox.Show(
                "T1 : Inter-Character Timeout--(SECS I) \n"+
                "T2 : Protocol Timeout--(SECS I) \n" +
                "T3 : Reply Timeout--(Both) \n" +
                "T4 : Inter-Block Timeout--(SECS I) \n" +
                "T5 : Connection Separation Timeout--(HSMS) \n" +
                "T6 : Control Transaction Timeout--(HSMS) \n" +
                "T7 : Not Selected Timeout--(HSMS) \n" +
                "T8 : Network Timeout--(HSMS)", "Info");
        }

        private void bS1_Recycle_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            InitAllTimeoutValue();
            DoCheckValue();
        }

        private void bS1_Exect_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            bool canSave = true;

            foreach (Control c in tlp_1.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty(((TextBox)c).Text))
                    {
                        ((TextBox)c).BackColor = Color.FromKnownColor(KnownColor.MistyRose);
                        canSave = false;
                    }
                }
            }

            if (canSave) { bS1_Exect.bS_Style = EButtonStyle1.locked; DoChangeValue(); } else { oneSecCount = 0; timerColor.Start(); }
        }

        private void tb_T1_TextChanged(object sender, EventArgs e)
        {
            DoCheckValue();
        }

        private void bS1_Setting_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            fixState = !fixState;

            DoFixedState();
        }


        private void DoFixedState()
        {
            foreach (Control c in tlp_1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Enabled = fixState;
                }
            }
        }

        private void bS1_ChangeComu_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                MyDelegate del = new MyDelegate(bS1_ChangeComu_ButtonStyle1_OnclickEvent);
                this.Invoke(del,new object[]{sender, e});
            }
            else
            {
                if (bS1_ChangeComu.BtnImageIndex == 0)
                {
                    bS1_ChangeComu.BtnImageIndex = 1;

                    pl_Switch.Controls.Clear();
                    it2.Dock = DockStyle.Fill;
                    pl_Switch.Controls.Add(it2);

                    Task.Factory.StartNew(()=>{
                        Thread.Sleep(5000);
                        if (bS1_ChangeComu.BtnImageIndex == 1) { bS1_ChangeComu_ButtonStyle1_OnclickEvent(sender, e); }
                    });

                }
                else
                {
                    bS1_ChangeComu.BtnImageIndex = 0;

                    pl_Switch.Controls.Clear();
                    it1.Dock = DockStyle.Fill;
                    pl_Switch.Controls.Add(it1);
                }
            }
        }
    }


}
