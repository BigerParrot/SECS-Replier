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
    public partial class IntValueSet_UCtrl : UserControl
    {
        public event EventHandler<EventArgs_Checked> Int_DoCheckEvent;

        public int Int_Value { get { return int.Parse(tbx_Value.Text); } }

        public IntValueSet_UCtrl()
        {
            InitializeComponent();
        }

        private void tbx_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (!((int)e.KeyChar == 8 || (int)e.KeyChar == 13)) { e.Handled = true; }
            }
        }

        private void tbx_Value_TextChanged(object sender, EventArgs e)
        {
            DoCheckBackEvent();
        }

        public void DoCheckBackEvent()
        {
            EventArgs_Checked arg = new EventArgs_Checked();

            if (string.IsNullOrEmpty(tbx_Value.Text)) { arg.Checked = false; } else { arg.Checked = true; }
            if (Int_DoCheckEvent != null)
            {
                Int_DoCheckEvent.Invoke(this, arg);
            }
        }
    }
}
