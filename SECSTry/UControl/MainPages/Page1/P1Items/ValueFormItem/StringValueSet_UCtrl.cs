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
    public partial class StringValueSet_UCtrl : UserControl
    {
        public event EventHandler<EventArgs_Checked> String_DoCheckEvent;

        public string String_Value { get { return rtb_String.Text; } }

        public StringValueSet_UCtrl()
        {
            InitializeComponent();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_String.SelectionStart = 0;
            rtb_String.SelectionLength = rtb_String.TextLength;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtb_String.Text);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_String.Text = string.Empty;
        }

        private void rtb_String_TextChanged(object sender, EventArgs e)
        {
            DoCheckBackEvent();
        }

        public void DoCheckBackEvent()
        {
            EventArgs_Checked arg = new EventArgs_Checked();
            arg.Checked = true;
            if (String_DoCheckEvent != null)
            {
                String_DoCheckEvent.Invoke(this, arg);
            }
        }
    }
}
