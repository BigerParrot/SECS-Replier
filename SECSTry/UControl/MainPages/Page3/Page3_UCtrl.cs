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

namespace SECSTry
{
    public partial class Page3_UCtrl : UserControl
    {
        U_System systemPage = new U_System();
        U_SECS secsPage = new U_SECS();
        U_EPage ePage = new U_EPage();

        public Page3_UCtrl()
        {
            InitializeComponent();

            DoPanel();

            systemPage.Dock = DockStyle.Fill;
            secsPage.Dock = DockStyle.Fill;
            ePage.Dock = DockStyle.Fill;

            bS1_System.Tag = systemPage;
            bS1_SECSII.Tag = secsPage;
            bS1_Protocol.Tag = ePage;
        }

        private void DoPanel()
        {
            panel1.Controls.Clear();

            panel1.Controls.Add(systemPage);
        }

        private void bS1_System_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            ButtonStyle1 nowBtn = (ButtonStyle1)sender;
            foreach (Control c in tlp_Buttons.Controls)
            {
                if (c is ButtonStyle1)
                {
                    ((ButtonStyle1)c).ButtonNoneColor_KnownColor = Color.FromKnownColor(KnownColor.Azure);
                }
            }
            nowBtn.ButtonNoneColor_KnownColor = Color.FromKnownColor(KnownColor.Aqua);

            if (nowBtn.Tag != null)
            {
                if (nowBtn.Tag is Control)
                {
                    panel1.Controls.Clear();
                    panel1.Controls.Add((Control)nowBtn.Tag);
                }
            }
        }
    }

}
