using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SECSLibs;
using SECSCtrlLibs;

namespace SECSTry
{
    public partial class ValueForm : Form
    {
        public event EventHandler<EventArgs_TypeValue> ValueBackEvent;

        BinaryValueSet_UCtrl U_binary = new BinaryValueSet_UCtrl();
        BoolValueSet_UCtrl U_bool = new BoolValueSet_UCtrl();
        IntValueSet_UCtrl U_int = new IntValueSet_UCtrl();
        StringValueSet_UCtrl U_string = new StringValueSet_UCtrl();

        private ESECSsingleType nowState = ESECSsingleType.None;
        private bool isAllowSpareLine = true;

        public ESECSsingleType State { get { return nowState; } set { nowState = value; cbx_Type.SelectedItem = (object)nowState; SetUctrl(); } }

        public bool IsAllowSpareLine { get { return isAllowSpareLine; } set { isAllowSpareLine = value; InitCbx(); } }

        private bool ValueChecked
        {
            set { DoLBcheckedChange(value); }
            get
            {
                if (lb_Checked.Tag.Equals("1")) { return true; } else { return false; }
            }
        }

        public ValueForm(ESECSsingleType state)
        {
            InitializeComponent();

            U_binary.Binary_DoCheckEvent += U_binary_Binary_DoCheckEvent;
            U_bool.Bool_DoCheckEvent += U_bool_Bool_DoCheckEvent;
            U_int.Int_DoCheckEvent += U_int_Int_DoCheckEvent;
            U_string.String_DoCheckEvent += U_string_String_DoCheckEvent;

            nowState = state;
            SetUctrl();

            InitCbx();
        }

        void U_string_String_DoCheckEvent(object sender, EventArgs_Checked e)
        {
            ValueChecked = e.Checked;
        }

        void U_int_Int_DoCheckEvent(object sender, EventArgs_Checked e)
        {
            ValueChecked = e.Checked;
        }

        void U_bool_Bool_DoCheckEvent(object sender, EventArgs_Checked e)
        {
            ValueChecked = e.Checked;
        }

        private void U_binary_Binary_DoCheckEvent(object sender, EventArgs_Checked e)
        {
            ValueChecked = e.Checked;
        }

        private void SetUctrl()
        {
            pl_base.Controls.Clear();
            this.MaximumSize = this.MinimumSize;
            DoLBcheckedChange(false);
            
            switch (nowState)
            {
                case ESECSsingleType.Bi:
                    pl_base.Controls.Add(U_binary);
                    U_binary.Dock = DockStyle.Fill;
                    U_binary.DoCheckBackEvent();
                    break;
                case ESECSsingleType.Bo:
                    pl_base.Controls.Add(U_bool);
                    U_bool.Dock = DockStyle.Fill;
                    U_bool.DoCheckBackEvent();
                    break;
                case ESECSsingleType.A:
                case ESECSsingleType.J:
                    this.MaximumSize = new System.Drawing.Size(0,0);
                    pl_base.Controls.Add(U_string);
                    U_string.Dock = DockStyle.Fill;
                    U_string.DoCheckBackEvent();
                    break;
                case ESECSsingleType.L:
                case ESECSsingleType.I1:
                case ESECSsingleType.I2:
                case ESECSsingleType.I4:
                case ESECSsingleType.I8:
                case ESECSsingleType.F4:
                case ESECSsingleType.F8:
                case ESECSsingleType.U1:
                case ESECSsingleType.U2:
                case ESECSsingleType.U4:
                case ESECSsingleType.U8:
                    pl_base.Controls.Add(U_int);
                    U_int.Dock = DockStyle.Fill;
                    U_int.DoCheckBackEvent();
                    break;
                default:
                    break;
            }
        }

        private void InitCbx()
        {
            cbx_Type.Items.Clear();

            foreach (ESECSsingleType item in Enum.GetValues(typeof(ESECSsingleType)))
            {
                if (isAllowSpareLine)
                {
                    if ((int)item >= 0)
                    {
                        cbx_Type.Items.Add((object)item);
                    }
                }
                else
                {
                    if ((int)item >= 0 && (int)item < 100)
                    {
                        cbx_Type.Items.Add((object)item);
                    }
                }
            }
        }

        private void DoLBcheckedChange(bool value)
        {
            if (value)
            {
                lb_Checked.Tag = 1;
                lb_Checked.BackColor = Color.FromKnownColor(KnownColor.GreenYellow);
                lb_Checked.ImageIndex = 0;
                bS1_Save.bS_Style = EButtonStyle1.None;
            }
            else
            {
                lb_Checked.Tag = 0;
                lb_Checked.BackColor = Color.FromKnownColor(KnownColor.Red);
                lb_Checked.ImageIndex = 1;
                bS1_Save.bS_Style = EButtonStyle1.locked;
            }
        }

        private void bS1_Leave_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbx_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_Type.SelectedItem != null) { nowState = (ESECSsingleType)cbx_Type.SelectedItem; }
            if (nowState == ESECSsingleType.Spare) { pl_base.Controls.Clear(); DoLBcheckedChange(true); return; }
            SetUctrl();
        }

        private void bS1_Save_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            EventArgs_TypeValue arg = new EventArgs_TypeValue();
            arg.type = nowState;
            switch (nowState)
            {
                case ESECSsingleType.Bi:
                    arg.binary_Value = U_binary.Byte_Value;
                    break;
                case ESECSsingleType.Bo:
                    arg.bool_Value = U_bool.Bool_Value;
                    break;
                case ESECSsingleType.A:
                case ESECSsingleType.J:
                    arg.string_Value = U_string.String_Value;
                    break;
                case ESECSsingleType.L:
                case ESECSsingleType.I1:
                case ESECSsingleType.I2:
                case ESECSsingleType.I4:
                case ESECSsingleType.I8:
                case ESECSsingleType.F4:
                case ESECSsingleType.F8:
                case ESECSsingleType.U1:
                case ESECSsingleType.U2:
                case ESECSsingleType.U4:
                case ESECSsingleType.U8:
                    arg.int_Value = U_int.Int_Value;
                    break;
                default:
                    break;
            }

            if (ValueBackEvent != null) { ValueBackEvent.Invoke(this, arg); this.Hide(); }
        }
    }
}
