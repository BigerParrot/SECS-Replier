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
    public partial class Controller_UC1 : UserControl
    {
        private delegate void DoClientsChange_Del(EventArgs_Client client);

        private DataGridViewRow row_Receive;
        private DataGridViewRow row_Send;
        private DataGridViewRow row_Clients;
        private SECSItem currentSECSItem_Rec = null;
        private Dictionary<int, SECSItem> RecList = new Dictionary<int, SECSItem>();
        private Dictionary<int, EventArgs_Client> ClientsList = new Dictionary<int, EventArgs_Client>();

        NonServer nonServer = new NonServer();



        public Controller_UC1() //TODO:異常排除
        {
            InitializeComponent();

            nonServer.Dock = DockStyle.Fill;
            tp_server.Controls.Add(nonServer);

            InitDGV_Receive();
            InitDGV_Send();
            InitDGV_Clients();

            LinkTableCenter.DoDGVListChangeEvent += LinkTableCenter_DoDGVListChangeEvent;
            LinkTableCenter.ReNewLinkTableDGVEvent += LinkTableCenter_ReNewLinkTableDGVEvent;
            LinkTableCenter.ReNewLinkTableDGV_SendEvent += LinkTableCenter_ReNewLinkTableDGV_SendEvent;

            SECSsystem.DoRoleChangeEvent += SECSsystem_DoRoleChangeEvent; //順序
            SECSsystemConnectionConfigure.ServerModeChangeEvent += SECSsystemConnectionConfigure_ServerModeChangeEvent;
            SECSsystem_DoRoleChangeEvent(new object(), new EventArgs());
        }

        #region --Link Table--

        void LinkTableCenter_ReNewLinkTableDGVEvent(object sender, EventArgs e)
        {
            Reset_LinkTable();
        }

        void LinkTableCenter_DoDGVListChangeEvent(object sender, EventArgs e)
        {
            Reset_LinkTable();
        }

        public void Reset_LinkTable()
        {
            cbx_Receive.Items.Clear();
            cbx_Send.Items.Clear();

            RecList.Clear();

            foreach (SECSItem item in LinkTableCenter.RecList_SetGet.Values)
            {
                if (item.IsUsed)
                {
                    RecList.Add(RecList.Count, item);
                    cbx_Receive.Items.Add(item);
                }
                else
                {
                    if (item.Equals(currentSECSItem_Rec))
                    {
                        currentSECSItem_Rec = null;
                    }
                }
            }
            foreach (SECSItem item in LinkTableCenter.SenList_SetGet.Values)
            {
                if (item.IsUsed)
                {
                    cbx_Send.Items.Add(item);
                }
            }

            dgv_Receive.Rows.Clear();
            dgv_Send.Rows.Clear();

            DoAddRows_Receive();
            DoAddRows_Send();

            RefreshNum_Receive();
            RefreshNum_Send();
        }

        private void InitDGV_Receive()
        {
            dgv_Receive.ColumnCount = 0;

            //第2行
            DataGridViewTextBoxColumn buttonColumn2 = new DataGridViewTextBoxColumn();
            buttonColumn2.Name = "tbx_column2";
            buttonColumn2.HeaderText = "Name";
            int columnIndex2 = 0;
            if (dgv_Receive.Columns["tbx_column2"] == null)
            {
                dgv_Receive.Columns.Insert(columnIndex2, buttonColumn2);
            }
            buttonColumn2.ReadOnly = true;

            //第1行
            DataGridViewTextBoxColumn buttonColumn1 = new DataGridViewTextBoxColumn();
            buttonColumn1.Name = "tbx_column1";
            buttonColumn1.HeaderText = "SF";
            int columnIndex1 = 0;
            if (dgv_Receive.Columns["tbx_column1"] == null)
            {
                dgv_Receive.Columns.Insert(columnIndex1, buttonColumn1);
            }
            buttonColumn1.ReadOnly = true;

            //第0行
            DataGridViewButtonColumn buttonColumn0 = new DataGridViewButtonColumn();
            buttonColumn0.Name = "button_column0";
            buttonColumn0.HeaderText = "#No";
            //buttonColumn0.Text = "#No";
            int columnIndex0 = 0;
            if (dgv_Receive.Columns["button_column0"] == null)
            {
                dgv_Receive.Columns.Insert(columnIndex0, buttonColumn0);
            }

            dgv_Receive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_Receive.Columns[0].Width = 40;
            dgv_Receive.Columns[1].Width = 40;
            dgv_Receive.Columns[2].Width = 70;

            row_Receive = (DataGridViewRow)dgv_Receive.Rows[0].Clone();

            dgv_Receive.AllowUserToAddRows = false;
        }

        private void DoAddRows_Receive()
        {
            for (int x = 0; x < RecList.Count; x++)
            {
                DataGridViewRow row0 = (DataGridViewRow)row_Receive.Clone();

                row0.Tag = (object)RecList[x];
                row0.Cells[1].Value = RecList[x].GetSF_string;
                row0.Cells[2].Value = RecList[x].Name;

                dgv_Receive.Rows.Add(row0);
                dgv_Receive.FirstDisplayedScrollingRowIndex = dgv_Receive.RowCount - 1;
            }
        }

        private void RefreshNum_Receive()
        {
            int i = 1;
            int visibleCount = 0;
            foreach (DataGridViewRow r in dgv_Receive.Rows)
            {
                if (r.Visible)
                {
                    visibleCount++;
                }
            }
            foreach (DataGridViewRow r in dgv_Receive.Rows)
            {
                if (r.Visible && visibleCount >= i)
                {
                    r.Cells[0].Value = i.ToString();
                    i++;
                }
            }
        }

        private void dgv_Receive_MouseEnter(object sender, EventArgs e)
        {
            dgv_Receive.Focus();
        }

        private void bS1_Add_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            if (cbx_Send.SelectedItem != null && currentSECSItem_Rec != null)
            {
                LinkTableCenter.AddSend_to_Receive(currentSECSItem_Rec, (SECSItem)cbx_Send.SelectedItem);
            }
            cbx_Send.SelectedItem = null;
        }

        private void cbx_Receive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_Receive.SelectedItem != null)
            {
                currentSECSItem_Rec = (SECSItem)cbx_Receive.SelectedItem;
                LinkTableCenter.ReNewLinkTableDGV_Send();
            }
        }

        private void dgv_Receive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.RowIndex >= 0)
                {
                    if (currentSECSItem_Rec != RecList[e.RowIndex])
                    {
                        currentSECSItem_Rec = RecList[e.RowIndex];
                        if (cbx_Receive.Items.Contains(RecList[e.RowIndex])) { cbx_Receive.SelectedItem = RecList[e.RowIndex]; }
                        LinkTableCenter.ReNewLinkTableDGV_Send();
                    }
                }
            }
        }

        #region --Send DGV--
        void LinkTableCenter_ReNewLinkTableDGV_SendEvent(object sender, EventArgs e)
        {
            dgv_Send.Rows.Clear();
            if (currentSECSItem_Rec != null)
            {
                DoAddRows_Send();
            }
            RefreshNum_Send();
        }

        private void DoAddRows_Send()
        {
            if (currentSECSItem_Rec == null || !LinkTableCenter.LinkTable_Get.ContainsKey(currentSECSItem_Rec)) { return; }
            foreach (SECSItem item in LinkTableCenter.LinkTable_Get[currentSECSItem_Rec])
            {
                if (!item.IsUsed) { continue; }
                DataGridViewRow row0 = (DataGridViewRow)row_Send.Clone();

                row0.Tag = (object)item;
                row0.Cells[1].Value = string.Format("{0}: {1}", item.GetSF_string, item.Name);

                dgv_Send.Rows.Add(row0);
                dgv_Send.FirstDisplayedScrollingRowIndex = dgv_Send.RowCount - 1;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = this.imageList1.Images[2];
            }
        }

        private void InitDGV_Send()
        {
            dgv_Send.ColumnCount = 0;

            //第2行
            DataGridViewImageColumn buttonColumn2 = new DataGridViewImageColumn();
            buttonColumn2.Name = "img_column2";
            buttonColumn2.HeaderText = "";
            int columnIndex2 = 0;
            if (dgv_Send.Columns["img_column2"] == null)
            {
                dgv_Send.Columns.Insert(columnIndex2, buttonColumn2);
            }

            //第1行
            DataGridViewTextBoxColumn buttonColumn1 = new DataGridViewTextBoxColumn();
            buttonColumn1.Name = "tbx_column1";
            buttonColumn1.HeaderText = "Name";
            int columnIndex1 = 0;
            if (dgv_Send.Columns["tbx_column1"] == null)
            {
                dgv_Send.Columns.Insert(columnIndex1, buttonColumn1);
            }
            buttonColumn1.ReadOnly = true;

            //第0行
            DataGridViewTextBoxColumn buttonColumn0 = new DataGridViewTextBoxColumn();
            buttonColumn0.Name = "tbx_column0";
            buttonColumn0.HeaderText = "#No";
            //buttonColumn0.Text = "#No";
            int columnIndex0 = 0;
            if (dgv_Send.Columns["tbx_column0"] == null)
            {
                dgv_Send.Columns.Insert(columnIndex0, buttonColumn0);
            }
            buttonColumn0.ReadOnly = true;

            dgv_Send.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_Send.Columns[0].Width = 40;
            dgv_Send.Columns[1].Width = 85;
            dgv_Send.Columns[2].Width = 25;

            row_Send = (DataGridViewRow)dgv_Send.Rows[0].Clone();

            dgv_Send.AllowUserToAddRows = false;
            
        }

        private void RefreshNum_Send()
        {
            int i = 1;
            int visibleCount = 0;
            foreach (DataGridViewRow r in dgv_Send.Rows)
            {
                if (r.Visible)
                {
                    visibleCount++;
                }
            }
            foreach (DataGridViewRow r in dgv_Send.Rows)
            {
                if (r.Visible && visibleCount >= i)
                {
                    r.Cells[0].Value = i.ToString();
                    i++;
                }
            }
        }

        #endregion --Send DGV--

        private void dgv_Send_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                if (e.RowIndex >= 0)
                {
                    LinkTableCenter.RemoveSend_from_Receive(currentSECSItem_Rec, (SECSItem)dgv_Send.Rows[e.RowIndex].Tag);
                }
            }
        }

        #endregion --Link Table--

        #region --Server Table--

        public void DoClientsChange(EventArgs_Client client)
        {
            if (this.InvokeRequired)
            {
                DoClientsChange_Del del = new DoClientsChange_Del(DoClientsChange);
                this.Invoke(del, client);
            }
            else
            {
                if (client.onoff)
                {
                    if (!ClientsList.ContainsValue(client))
                    {
                        ClientsList.Add(ClientsList.Count, client);
                        DoClientsDGV_Renew();
                    }
                }
                else
                {
                    int toBeRemove = -1;
                    foreach (EventArgs_Client item in ClientsList.Values)
                    {
                        if (item.ID.Equals(client.ID))
                        {
                            toBeRemove = ClientsList.FirstOrDefault(x => x.Value == item).Key;
                            break;
                        }
                    }
                    if (toBeRemove != -1)
                    {
                        ClientsList.Remove(toBeRemove);

                        Dictionary<int, EventArgs_Client> temp = new Dictionary<int, EventArgs_Client>(ClientsList);

                        ClientsList.Clear();

                        foreach (EventArgs_Client item in temp.Values)
                        {
                            ClientsList.Add(ClientsList.Count, item);
                        }
                        DoClientsDGV_Renew();
                    }
                }

                lb_ClientsNum.Text = ClientsList.Count.ToString();
            }
        }

        private void DoClientsDGV_Renew()
        {
            dgv_Clients.Rows.Clear();

            for (int x = 0; x < ClientsList.Count; x++)
            {
                if (!ClientsList.ContainsKey(x)) { continue; }

                DataGridViewRow row0 = (DataGridViewRow)row_Clients.Clone();

                row0.Tag = (object)ClientsList[x];

                row0.Cells[0].Value = (x + 1).ToString();
                row0.Cells[1].Value = string.Format("{0}", ClientsList[x].Name);
                row0.Cells[2].Value = string.Format("{0}", ClientsList[x].ID);
                row0.Cells[3].Value = this.imageList1.Images[2];

                dgv_Clients.Rows.Add(row0);
                dgv_Clients.FirstDisplayedScrollingRowIndex = dgv_Clients.RowCount - 1;
            }
        }

        private void InitDGV_Clients()
        {
            dgv_Clients.ColumnCount = 0;

            //第3行
            DataGridViewImageColumn buttonColumn3 = new DataGridViewImageColumn();
            buttonColumn3.Name = "img_column3";
            buttonColumn3.HeaderText = "";
            int columnIndex3 = 0;
            if (dgv_Clients.Columns["img_column3"] == null)
            {
                dgv_Clients.Columns.Insert(columnIndex3, buttonColumn3);
            }

            //第2行
            DataGridViewTextBoxColumn buttonColumn2 = new DataGridViewTextBoxColumn();
            buttonColumn2.Name = "tbx_column2";
            buttonColumn2.HeaderText = "ID";
            int columnIndex2 = 0;
            if (dgv_Clients.Columns["tbx_column2"] == null)
            {
                dgv_Clients.Columns.Insert(columnIndex2, buttonColumn2);
            }
            buttonColumn2.ReadOnly = true;

            //第1行
            DataGridViewTextBoxColumn buttonColumn1 = new DataGridViewTextBoxColumn();
            buttonColumn1.Name = "tbx_column1";
            buttonColumn1.HeaderText = "Name";
            int columnIndex1 = 0;
            if (dgv_Clients.Columns["tbx_column1"] == null)
            {
                dgv_Clients.Columns.Insert(columnIndex1, buttonColumn1);
            }

            //第0行
            DataGridViewButtonColumn buttonColumn0 = new DataGridViewButtonColumn();
            buttonColumn0.Name = "button_column0";
            buttonColumn0.HeaderText = "#No";
            //buttonColumn0.Text = "#No";
            int columnIndex0 = 0;
            if (dgv_Clients.Columns["button_column0"] == null)
            {
                dgv_Clients.Columns.Insert(columnIndex0, buttonColumn0);
            }

            dgv_Clients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_Clients.Columns[0].Width = 50;
            dgv_Clients.Columns[1].Width = 70;
            dgv_Clients.Columns[2].Width = 150;
            dgv_Clients.Columns[3].Width = 50;

            row_Clients = (DataGridViewRow)dgv_Clients.Rows[0].Clone();

            dgv_Clients.AllowUserToAddRows = false;
            
        }

        void SECSsystem_DoRoleChangeEvent(object sender, EventArgs e)
        {
            if (SECSsystem.SECSRole == ESECSRole.Server)
            {
                tableLayoutPanel3.Visible = true;
                nonServer.Visible = false;
            }
            else
            {
                tableLayoutPanel3.Visible = false;
                nonServer.Visible = true;
            }
        }

        void SECSsystemConnectionConfigure_ServerModeChangeEvent(object sender, EventArgs e)
        {
            switch (SECSsystemConnectionConfigure.ServerMode)
            {
                case EServerAllowMode.Single_First:
                    lb_Mode.Text = string.Format("First");
                    break;
                case EServerAllowMode.Single_Latest:
                    lb_Mode.Text = string.Format("Last");
                    break;
                case EServerAllowMode.Multi:
                    lb_Mode.Text = string.Format("Multi");
                    break;
            }
        }

        #endregion --Server Table--
    }
}
