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
    public partial class Loggers_Ctrl1 : UserControl
    {
        private delegate void AddRow_del(EventArg_SF sf);
        public event EventHandler<EventArg_SF> SFChoose_Event;
        private delegate void DoClear_Del();

        private Dictionary<int, EventArg_SF> records = new Dictionary<int,EventArg_SF>();
        List<DataGridViewRow> S0F0List = new List<DataGridViewRow>();
        List<DataGridViewRow> SendList = new List<DataGridViewRow>();
        List<DataGridViewRow> ReceiveList = new List<DataGridViewRow>();
        List<DataGridViewRow> OtherList = new List<DataGridViewRow>();

        public EventArg_SF Add_SF
        {
            set
            {
                records.Add(records.Count, value);
                DoAddRow(value);
            }
        }

        public Loggers_Ctrl1()
        {
            InitializeComponent();

            InitDGV();
        }

        private void DoAddRow(EventArg_SF newRow)
        {
            if (this.InvokeRequired)
            {
                AddRow_del del = new AddRow_del(DoAddRow);
                this.Invoke(del, (object)newRow);
            }
            else
            {
                DataGridViewRow row = (DataGridViewRow)dgv1.Rows[0].Clone();

                if(!records.ContainsKey(records.Count - 1)) { return; }
                records[records.Count - 1].num = records.Count;
                if (newRow.SF.Equals("S0F0"))
                {
                    if (s0F0Show_check.Checked) { ShowDGVRow(row); } else { HideDGVRow(row); }
                    row.Cells[1].Style.BackColor = Color.FromKnownColor(KnownColor.Silver);
                    S0F0List.Add(row);
                }
                else
                {
                    if (newRow.isReceive && receive_check.Checked) { ShowDGVRow(row); ReceiveList.Add(row); }
                    else if (newRow.isSend && send_check.Checked) { ShowDGVRow(row); SendList.Add(row); }
                    else if(timeout_check.Checked) { ShowDGVRow(row); OtherList.Add(row); }

                    ShowDGVRow(row);
                    row.Cells[1].Style.BackColor = Color.FromKnownColor(KnownColor.White);
                }
                row.Cells[1].Value = newRow.SF;

                dgv1.Rows.Add(row);
                dgv1.FirstDisplayedScrollingRowIndex = dgv1.RowCount - 1;
                RefreshNum();
            }
        }

        private void InitDGV()
        {
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.ColumnCount = 1;
            
            dgv1.Columns[0].HeaderText = "Type";

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "button_column";
            buttonColumn.HeaderText = "#No";
            buttonColumn.Text = "#No";
            int columnIndex = 0;
            if (dgv1.Columns["button_column"] == null)
            {
                dgv1.Columns.Insert(columnIndex, buttonColumn);
            }
            dgv1.Columns[0].Width = 40;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.RowIndex!=records.Count)
            {
                if (SFChoose_Event != null) 
                { 
                    SFChoose_Event.Invoke(this, records[e.RowIndex]); 
                }
            }
        }

        private void tlp_Base_Paint(object sender, PaintEventArgs e)
        {

        }

        private void s0F0Show_check_CheckedChanged(object sender, EventArgs e)
        {
            if (s0F0Show_check.Checked)
            {
                foreach (DataGridViewRow r in S0F0List)
                {
                    ShowDGVRow(r);
                }
            }
            else
            {
                foreach (DataGridViewRow r in S0F0List)
                {
                    HideDGVRow(r);
                }
            }
            RefreshNum();
        }

        private void send_check_CheckedChanged(object sender, EventArgs e)
        {
            if (send_check.Checked)
            {
                foreach (DataGridViewRow r in SendList)
                {
                    ShowDGVRow(r);
                }
            }
            else
            {
                foreach (DataGridViewRow r in SendList)
                {
                    HideDGVRow(r);
                }
            }
            RefreshNum();
        }

        private void receive_check_CheckedChanged(object sender, EventArgs e)
        {
            if (receive_check.Checked)
            {
                foreach (DataGridViewRow r in ReceiveList)
                {
                    ShowDGVRow(r);
                }
            }
            else
            {
                foreach (DataGridViewRow r in ReceiveList)
                {
                    HideDGVRow(r);
                }
            }
            RefreshNum();
        }

        private void timeout_check_CheckedChanged(object sender, EventArgs e)
        {
            if (timeout_check.Checked)
            {
                foreach (DataGridViewRow r in OtherList)
                {
                    ShowDGVRow(r);
                }
            }
            else
            {
                foreach (DataGridViewRow r in OtherList)
                {
                    HideDGVRow(r);
                }
            }
            RefreshNum();
        }

        private void RefreshNum()
        {
            int i = 1;
            int visibleCount = 0;
            foreach (DataGridViewRow r in dgv1.Rows)
            {
                if (r.Visible)
                {
                    visibleCount++;
                }
            }
            foreach (DataGridViewRow r in dgv1.Rows)
            {
                if (r.Visible && visibleCount > i)
                {
                    r.Cells[0].Value = i.ToString();
                    i++;
                }
            }
        }

        private void HideDGVRow(DataGridViewRow row)
        {
            row.Visible = false;
        }

        private void ShowDGVRow(DataGridViewRow row)
        {
            row.Visible = true;
        }

        private void unselectItem_btn_Click(object sender, EventArgs e)
        {
            EventArg_SF arg = new EventArg_SF();
            arg.num = -1;

            if (SFChoose_Event != null)
            {
                SFChoose_Event.Invoke(this, arg);
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
                dgv1.Rows.Clear();
                records.Clear();
                S0F0List.Clear();
                SendList.Clear();
                ReceiveList.Clear();
                OtherList.Clear();
            }
            
        }


    }

    public class EventArg_SF : EventArgs
    {
        public int num = -1;
        public string SF = "S0F0";

        public bool isSend = false;
        public bool isReceive = false;
    }
}
