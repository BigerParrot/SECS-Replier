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

namespace SECSTry
{
    public partial class BinaryValueSet_UCtrl : UserControl
    {
        public event EventHandler<EventArgs_Checked> Binary_DoCheckEvent;
        private byte bvalue = 0x00;

        public byte Byte_Value { get { return bvalue; } }

        public bool Checked
        {
            get
            {
                if (!string.IsNullOrEmpty(tbx_Value.Text) && tbx_Byte.TextLength == 2) { return true; } else { return false; }
            }
        }
        public BinaryValueSet_UCtrl()
        {
            InitializeComponent();
        }

        private void tbx_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (!((int)e.KeyChar == 8 || (int)e.KeyChar == 13)) { e.Handled = true; }
            }
            else
            {
                if (tbx_Value.TextLength >= 3) { e.Handled = true; }
            }
        }

        private void tbx_Byte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                char cUpper = Char.ToUpper(e.KeyChar);
                if (cUpper < 'A' || cUpper > 'F')
                {
                    if (!((int)e.KeyChar == 8 || (int)e.KeyChar == 13)) 
                    {
                        e.Handled = true; 
                    }
                }
                else
                {
                    if (tbx_Byte.TextLength >= 2) { e.Handled = true; }
                }
            }
            else
            {
                if (tbx_Byte.TextLength >= 2) { e.Handled = true; }
            }
        }

        private void tbx_Value_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbx_Value.Text)) { tbx_Byte.Text = "00"; bvalue = 0x00; DoCheckBackEvent(); return; }
            if (int.Parse(tbx_Value.Text) > 255) { tbx_Value.Text = "255"; }

            byte b = Convert.ToByte(int.Parse(tbx_Value.Text));
            bvalue = b;
            string t = b.ToString("X2").ToUpper();

            if (tbx_Byte.Text != t)
            {
                tbx_Byte.Text = t;
                DoCheckBackEvent();
            }
            
        }

        private void tbx_Byte_TextChanged(object sender, EventArgs e)
        {
            tbx_Byte.Text = tbx_Byte.Text.ToUpper();
            tbx_Byte.SelectionStart = tbx_Byte.TextLength;

            if (tbx_Byte.Text.Length != 2) { DoCheckBackEvent(); return; }
            byte[] bArray = StringToByteArray(tbx_Byte.Text);
            if (bArray.Length == 1)
            {
                bvalue = bArray[0];
                string t = ((int)bArray[0]).ToString();
                if (tbx_Value.Text != t)
                {
                    tbx_Value.Text = t;
                }
                DoCheckBackEvent();
            }
        }

        public void DoCheckBackEvent()
        {
            if (Binary_DoCheckEvent != null)
            {
                EventArgs_Checked arg = new EventArgs_Checked();
                arg.Checked = Checked;
                Binary_DoCheckEvent.Invoke(this, arg);
            }
        }

        public byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
