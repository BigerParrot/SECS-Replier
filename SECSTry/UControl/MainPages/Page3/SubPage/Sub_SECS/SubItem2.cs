using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECSTry
{
    public partial class SubItem2 : UserControl
    {
        public event EventHandler DoCheckChange;
        public bool IsSECSIchecked { get { return rbtn_SECSI.Checked; } }

        public bool IsHSMSchecked { get { return rbtn_HSMS.Checked; } }

        public SubItem2()
        {
            InitializeComponent();
        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (DoCheckChange != null)
            {
                DoCheckChange.Invoke(this, e);
            }
        }
    }
}
