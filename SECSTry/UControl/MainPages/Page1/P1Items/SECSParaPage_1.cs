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
using SECSCtrlLibs;

namespace SECSTry
{
    public partial class SECSParaPage_1 : UserControl
    {
        public event EventHandler<EventArgs_SECSParaPage> BackSECSmsg_Event;
        public event EventHandler Delete_Event; 

        private SECSmsg nowMsg = new SECSmsg();
        private SECSsingleLine nowLine = new SECSsingleLine();
        private bool isAllowSpareLine = true;

        private bool SetChecked
        {
            set
            {
                if (value)
                {
                    bS1_Checked.bS_Style = EButtonStyle1.locked;
                    bS1_Checked.BtnImageIndex = 0;
                }
                else
                {
                    bS1_Checked.bS_Style = EButtonStyle1.Warrning;
                    bS1_Checked.BtnImageIndex = 1;
                }
            }
        }

        ValueForm vForm = null;

        public bool IsAllowSpareLine { get { return isAllowSpareLine; } set { isAllowSpareLine = value; InitAll(); } }

        public SECSParaPage_1()
        {
            InitializeComponent();

            InitAll();
            vForm = new ValueForm((ESECSsingleType)cbx_Type.SelectedItem);
            vForm.ValueBackEvent += vForm_ValueBackEvent;
            vForm.IsAllowSpareLine = isAllowSpareLine;
        }

        public void SetSECSmsg(SECSItem itSECS)
        {
            nowMsg = ((SECSmsg)itSECS).Clone();

            tbx_Stream.Text = nowMsg.Stream.ToString();
            tbx_Function.Text = nowMsg.Function.ToString();

            RefreshRTB();
        }

        void vForm_ValueBackEvent(object sender, EventArgs_TypeValue e)
        {
            if (cbx_Type.SelectedItem != (object)e.type) { cbx_Type.SelectedItem = (object)e.type; }
            nowLine.Type = e.type;
            
            switch (e.type)
            {
                case ESECSsingleType.Bi:
                    tbx_ValueNow.Text = e.binary_Value.ToString();
                    break;
                case ESECSsingleType.Bo:
                    tbx_ValueNow.Text = e.bool_Value.ToString();
                    break;
                case ESECSsingleType.A:
                case ESECSsingleType.J:
                    tbx_ValueNow.Text = e.string_Value.ToString();
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
                    tbx_ValueNow.Text = e.int_Value.ToString();
                    break;
                default:
                    tbx_ValueNow.Text = string.Empty;
                    break;
            }

            SetChecked = true;

            switch (nowLine.Type)
            {
                case ESECSsingleType.Bi:
                    nowLine.AsBi = e.binary_Value;
                    break;
                case ESECSsingleType.Bo:
                    nowLine.AsBo = e.bool_Value;
                    break;
                case ESECSsingleType.A:
                    nowLine.AsA = e.string_Value;
                    break;
                case ESECSsingleType.J:
                    nowLine.AsA = e.string_Value;
                    break;
                case ESECSsingleType.L:
                    nowLine.AsList = e.int_Value;
                    break;
                case ESECSsingleType.I1:
                    nowLine.AsI1 = e.int_Value;
                    break;
                case ESECSsingleType.I2:
                    nowLine.AsI2 = e.int_Value;
                    break;
                case ESECSsingleType.I4:
                    nowLine.AsI4 = e.int_Value;
                    break;
                case ESECSsingleType.I8:
                    nowLine.AsI8 = e.int_Value;
                    break;
                case ESECSsingleType.F4:    //待改善
                    nowLine.AsF4 = e.int_Value;
                    break;
                case ESECSsingleType.F8:    //待改善
                    nowLine.AsF8 = e.int_Value;
                    break;
                case ESECSsingleType.U1:
                    nowLine.AsU1 = e.uint_Value;
                    break;
                case ESECSsingleType.U2:
                    nowLine.AsU2 = e.uint_Value;
                    break;
                case ESECSsingleType.U4:
                    nowLine.AsU4 = e.uint_Value;
                    break;
                case ESECSsingleType.U8:
                    nowLine.AsU8 = e.uint_Value;
                    break;
                case ESECSsingleType.Spare:
                    break;
                default:
                    SetChecked = false;
                    break;
            }
        }


        private void InitAll()
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
            if (vForm != null) { vForm.IsAllowSpareLine = isAllowSpareLine; }
            
            cbx_Type.SelectedItem = (object)ESECSsingleType.L;
            
        }

        
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (!((int)e.KeyChar == 8 || (int)e.KeyChar == 13)) { e.Handled = true; }
            }
        }

        private void tbx_Stream_TextChanged(object sender, EventArgs e)
        {
            int streamHere = 0;
            int functionHere = 0;

            if (!string.IsNullOrEmpty(tbx_Stream.Text)) { streamHere = int.Parse(tbx_Stream.Text); }
            if (!string.IsNullOrEmpty(tbx_Function.Text)) { functionHere = int.Parse(tbx_Function.Text); }

            if (nowMsg.Stream != streamHere || nowMsg.Function != functionHere)
            {
                bS1_SetSF.bS_Style = EButtonStyle1.Warrning;
            }
            else
            {
                bS1_SetSF.bS_Style = EButtonStyle1.locked;
            }
        }

        private void bS1_SetSF_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            int streamHere = 0;
            int functionHere = 0;

            if (!string.IsNullOrEmpty(tbx_Stream.Text)) { streamHere = int.Parse(tbx_Stream.Text); }
            if (!string.IsNullOrEmpty(tbx_Function.Text)) { functionHere = int.Parse(tbx_Function.Text); }

            if (streamHere == 0 || functionHere == 0)
            {
                DialogResult result = MessageBox.Show("At least one of the SF value is 0, make sure to change value?", "Warnning", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }
            }

            nowMsg.SetSF(int.Parse(tbx_Stream.Text), int.Parse(tbx_Function.Text));
            bS1_SetSF.bS_Style = EButtonStyle1.locked;

            RefreshRTB();
        }

        private void cbx_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_Type.SelectedItem != null)
            {
                nowLine.Type = (ESECSsingleType)cbx_Type.SelectedItem;
            }

            switch (nowLine.Type)
            {
                case ESECSsingleType.Bi:
                    tbx_ValueNow.Text = nowLine.AsBi.ToString();
                    break;
                case ESECSsingleType.Bo:
                    tbx_ValueNow.Text = nowLine.AsBo.ToString();
                    break;
                case ESECSsingleType.A:
                    tbx_ValueNow.Text = nowLine.AsA.ToString();
                    break;
                case ESECSsingleType.J:
                    tbx_ValueNow.Text = nowLine.AsJ.ToString();
                    break;
                case ESECSsingleType.L:
                    tbx_ValueNow.Text = nowLine.AsList.ToString();
                    break;
                case ESECSsingleType.I1:
                    tbx_ValueNow.Text = nowLine.AsI1.ToString();
                    break;
                case ESECSsingleType.I2:
                    tbx_ValueNow.Text = nowLine.AsI2.ToString();
                    break;
                case ESECSsingleType.I4:
                    tbx_ValueNow.Text = nowLine.AsI4.ToString();
                    break;
                case ESECSsingleType.I8:
                    tbx_ValueNow.Text = nowLine.AsI8.ToString();
                    break;
                case ESECSsingleType.F4:    //待改善
                    tbx_ValueNow.Text = nowLine.AsF4.ToString();
                    break;
                case ESECSsingleType.F8:    //待改善
                    tbx_ValueNow.Text = nowLine.AsF8.ToString();
                    break;
                case ESECSsingleType.U1:
                    tbx_ValueNow.Text = nowLine.AsU1.ToString();
                    break;
                case ESECSsingleType.U2:
                    tbx_ValueNow.Text = nowLine.AsU2.ToString();
                    break;
                case ESECSsingleType.U4:
                    tbx_ValueNow.Text = nowLine.AsU4.ToString();
                    break;
                case ESECSsingleType.U8:
                    tbx_ValueNow.Text = nowLine.AsU8.ToString();
                    break;
                default:
                    tbx_ValueNow.Text = "[None]";
                    break;
            }
        }

        private void bS1_ShowValue_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            vForm.State = (ESECSsingleType)cbx_Type.SelectedItem;
            vForm.StartPosition = FormStartPosition.CenterParent;
            vForm.ShowDialog();
        }

        private void RefreshRTB()
        {
            rtb_Msg.Clear();
            rtb_Msg.AppendText(nowMsg.GetSF_string + "\n");
            rtb_Msg.AppendText(nowMsg.ToString());

            if (nowMsg.IsEnd())
            {
                lb_IsEnd.Text = string.Format("Message Complete");
            }
            else
            {
                lb_IsEnd.Text = string.Empty;
            }
        }

        private void bS_Add_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            if (!nowMsg.SetLatestLine(nowLine))
            {
                MessageBox.Show("Message built done.");
            }
            else
            {
                RefreshRTB();
            }
        }

        private void bS1_Clear_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            if (nowMsg.ClearLatestLine())
            {
                RefreshRTB();
            }
        }

        private void bS1_Save_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            EventArgs_SECSParaPage arg = new EventArgs_SECSParaPage();

            arg.isEnd = nowMsg.IsEnd();
            arg.secsMsg = nowMsg.Clone();

            if (BackSECSmsg_Event != null)
            {
                BackSECSmsg_Event.Invoke(new object(), arg);
            }
        }

        private void buttonStyle11_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this message?","Warnning",MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) { return; }
            if (Delete_Event != null)
            {
                Delete_Event.Invoke(this, new EventArgs());
            }
        }
    }

    public class EventArgs_SECSParaPage : EventArgs
    {
        public bool isEnd = false;
        public SECSmsg secsMsg = new SECSmsg();
    }
}
