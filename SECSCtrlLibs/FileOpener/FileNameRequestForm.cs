using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECSCtrlLibs
{
    public partial class FileNameRequestForm : Form
    {
        private string filename = string.Empty;
        private bool isEnter = false;

        public string FileName
        {
            get
            {
                if (isEnter) { return filename; } else { return string.Empty; }
            }
        }

        public FileNameRequestForm()
        {
            InitializeComponent();

            isEnter = false;
            DoCheck();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filename = textBox1.Text;
            DoCheck();
        }

        private void DoCheck()
        {
            if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) <= 0 && !string.IsNullOrEmpty(filename))
            {
                bS1_Enter.bS_Style = EButtonStyle1.Warrning;
            }
            else
            {
                bS1_Enter.bS_Style = EButtonStyle1.locked;
            }
        }

        private void bS1_Enter_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            isEnter = true;
            this.Dispose();
        }
    }
}
