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
    public partial class BoolValueSet_UCtrl : UserControl
    {
        public event EventHandler<EventArgs_Checked> Bool_DoCheckEvent;

        public bool Bool_Value { get { return (bool)cbx_Bool.SelectedItem; } }

        public BoolValueSet_UCtrl()
        {
            InitializeComponent();

            InitCbx();
        }

        private void InitCbx()
        {
            cbx_Bool.Items.Clear();

            cbx_Bool.Items.Add(true);
            cbx_Bool.Items.Add(false);
        }

        private void cbx_Bool_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoCheckBackEvent();
        }

        public void DoCheckBackEvent()
        {
            EventArgs_Checked arg = new EventArgs_Checked();
            if (cbx_Bool.SelectedItem == null)
            {
                arg.Checked = false;
            }
            else
            {
                arg.Checked = true;
            }

            if (Bool_DoCheckEvent != null)
            {
                Bool_DoCheckEvent.Invoke(this, arg);
            }
        }
    }
}
