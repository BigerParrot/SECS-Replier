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
    public partial class Loggers_Ctrl2 : UserControl
    {
        public event EventHandler<EventArgs_SingleInt> DoCopyIndex_Event;
        private delegate void AddText_MsgBase_Del(string txt, string sf);
        private delegate void Select_Del(int num);
        private delegate void DoClear_Del();

        private Dictionary<int, EventArg_RTB_Range> records_MsgBase = new Dictionary<int,EventArg_RTB_Range>();
        private Dictionary<int, EventArg_RTB_Range> records_Msg = new Dictionary<int, EventArg_RTB_Range>();
        private int thelastone_MsgBase = -1;
        private int thelastone_Msg = -1;

        public Dictionary<int, EventArg_RTB_Range> Records_MsgBase { get { return records_MsgBase; } }
        public Dictionary<int, EventArg_RTB_Range> Records_Msg { get { return records_Msg; } }


        public Loggers_Ctrl2()
        {
            InitializeComponent();

            records_MsgBase.Clear();
            records_Msg.Clear();

            cms_Copy.Enabled = false;
        }

        public void AddText_MsgBase(string txt,string sf)
        {
            if (this.InvokeRequired)
            {
                AddText_MsgBase_Del del = new AddText_MsgBase_Del(AddText_MsgBase);
                this.Invoke(del, new object[] { txt, sf });
            }
            else
            {
                EventArg_RTB_Range newTxt = new EventArg_RTB_Range();
                int latestSelection = rtb_MsgBase.SelectionStart;

                newTxt.sf = sf;
                newTxt.startPlace = rtb_MsgBase.Text.Length;
                newTxt.context = txt;
                rtb_MsgBase.AppendText(txt + "\n");
                newTxt.endPlace = rtb_MsgBase.Text.Length;
                records_MsgBase.Add(records_MsgBase.Count, newTxt);

                rtb_MsgBase.SelectionStart = rtb_MsgBase.Text.Length;
                rtb_MsgBase.SelectionLength = 0;
                rtb_MsgBase.ScrollToCaret();
            }
            
        }

        public void AddText_Msg(string txt, string sf)
        {
            if (this.InvokeRequired)
            {
                AddText_MsgBase_Del del = new AddText_MsgBase_Del(AddText_Msg);
                this.Invoke(del, new object[]{txt, sf});
            }
            else
            {
                EventArg_RTB_Range newTxt = new EventArg_RTB_Range();
                int latestSelection = rtb_Msg.SelectionStart;

                newTxt.sf = sf;
                newTxt.startPlace = rtb_Msg.Text.Length;
                newTxt.context = txt;
                rtb_Msg.AppendText(txt + "\n");
                newTxt.endPlace = rtb_Msg.Text.Length;

                int x = records_MsgBase.Count - 1;
                while (x < records_MsgBase.Count + 10)
                {
                    if (!records_Msg.ContainsKey(x))
                    {
                        records_Msg.Add(x, newTxt);
                        break;
                    }
                    x++;
                }
                
                rtb_Msg.SelectionStart = rtb_Msg.Text.Length;
                rtb_Msg.SelectionLength = 0;
                rtb_Msg.ScrollToCaret();
            }

        }

        public void Select_MsgBase(int num)
        {
            if (this.InvokeRequired)
            {
                Select_Del del = new Select_Del(Select_MsgBase);
                this.Invoke(del,(object) num);
            }
            else
            {
                if (records_MsgBase.ContainsKey(thelastone_MsgBase))
                {
                    changeBackColor(rtb_MsgBase, records_MsgBase[thelastone_MsgBase]);
                }
                
                if (!records_MsgBase.Keys.Contains(num - 1)) { return; }

                EventArg_RTB_Range nowSelection = records_MsgBase[num - 1];
                thelastone_MsgBase = num - 1;
                rtb_MsgBase.SelectionStart = nowSelection.startPlace;
                rtb_MsgBase.SelectionLength = nowSelection.endPlace - nowSelection.startPlace;
                rtb_MsgBase.SelectionBackColor = Color.FromKnownColor(KnownColor.LightGreen);

                rtb_MsgBase.ScrollToCaret();
            }
        }

        public void Select_Msg(int num)
        {
            if (this.InvokeRequired)
            {
                Select_Del del = new Select_Del(Select_Msg);
                this.Invoke(del, (object)num);
            }
            else
            {
                if (records_Msg.ContainsKey(thelastone_Msg))
                {
                    changeBackColor(rtb_Msg, records_Msg[thelastone_Msg]);
                    thelastone_Msg = -1;
                }

                if (!records_Msg.Keys.Contains(num - 1)) { return; }
                EventArg_RTB_Range nowSelection = records_Msg[num - 1];
                thelastone_Msg = num - 1;
                rtb_Msg.SelectionStart = nowSelection.startPlace;
                rtb_Msg.SelectionLength = nowSelection.endPlace - nowSelection.startPlace;
                rtb_Msg.SelectionBackColor = Color.FromKnownColor(KnownColor.LightGreen);

                rtb_Msg.ScrollToCaret();
            }
        }

        private void changeBackColor(RichTextBox rtb, EventArg_RTB_Range lastSelection)
        {
            rtb.SelectionStart = lastSelection.startPlace;
            rtb.SelectionLength = lastSelection.endPlace - lastSelection.startPlace;
            rtb.SelectionBackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void unselectItem_btn_Click(object sender, EventArgs e)
        {
            Select_MsgBase(-1);
            Select_Msg(-1);
        }

        private void copyMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DoCopyIndex_Event != null && thelastone_Msg >= 0)
            {
                EventArgs_SingleInt arg = new EventArgs_SingleInt();
                arg.intValue = thelastone_Msg;
                DoCopyIndex_Event.Invoke(this, arg);
            }
        }

        private void tab_Base_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                cms_Copy.Enabled = false;
            }
            else
            {
                cms_Copy.Enabled = true;
            }
        }

        private void ctms1_Opening(object sender, CancelEventArgs e)
        {
            if (tab_Base.TabPages.IndexOf(tab_Base.SelectedTab) == 1)
            {
                if (thelastone_Msg >= 0)
                {
                    cms_Copy.Text = string.Format("Copy {0} Message", records_Msg[thelastone_Msg].sf);
                    cms_Copy.Enabled = true;
                }
                else
                {
                    cms_Copy.Text = string.Format("Copy Message");
                    cms_Copy.Enabled = false;
                }
            }
        }

        public void DoClear()
        {
            if (this.InvokeRequired)
            {
                DoClear_Del del = new DoClear_Del(DoClear);
                this.Invoke(del);
            }
            else
            {
                records_MsgBase.Clear();
                records_Msg.Clear();
                thelastone_MsgBase = -1;
                thelastone_Msg = -1;

                rtb_Msg.Clear();
                rtb_MsgBase.Clear();
            }
        }
    }

    public class EventArg_RTB_Range : EventArgs
    {
        public string sf = string.Empty;

        public int startPlace = 0;
        public int endPlace = 0;

        public string context = string.Empty;
    }

    public class EventArgs_SingleInt:EventArgs{
        public int intValue = 0;
    }
}
