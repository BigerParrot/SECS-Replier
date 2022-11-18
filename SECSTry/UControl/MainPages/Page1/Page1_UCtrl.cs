using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SECSLibs;

namespace SECSTry
{
    public partial class Page1_UCtrl : UserControl
    {
        public event EventHandler<EventArgs_TheMessage> SendMsg_Event;

        private Timer DgvShowTimer = new Timer();

        private Dictionary<int, SECSItem> RecList = new Dictionary<int, SECSItem>();
        private Dictionary<int, SECSItem> SenList = new Dictionary<int, SECSItem>();

        private DataGridViewRow row = null;
        private SECSItem secsItemNow = new SECSItem();
        private DGVstruct str = new DGVstruct();

        private bool channel = true;
        private bool IsRec { set { if (channel != value) { channel = value; DoChanging(); } } get { return channel; } }
        private bool IsSen { set { if (channel == value) { channel = !value; DoChanging(); } } get { return !channel; } }

        private bool IsShowUsed { set { cms_ShowUsed.Checked = value; } get { return cms_ShowUsed.Checked; } }
        private bool IsShowUnUsed { set { cms_ShowUnUsed.Checked = value; } get { return cms_ShowUnUsed.Checked; } }

        private string NowShowSF //SxFx
        {
            set
            {
                char[] sp = { 'S', 'F', 's', 'f' };
                string[] cArray = value.Trim().Split(sp);
                if (cArray.Length >= 2)
                {
                    bool conti = true;
                    int n = 0;
                    foreach (string i in cArray)
                    {
                        if (!string.IsNullOrEmpty(i))
                        {
                            if (!int.TryParse(i, out n))
                            {
                                conti = false;
                            }
                        }
                    }
                    if (conti)
                    {
                        cms_tb_ShowStream.Text = cArray[1];
                        cms_tb_ShowFunction.Text = cArray[2];
                    }
                }
            }
            get
            {
                return string.Format("S{0}F{1}", cms_tb_ShowStream.Text, cms_tb_ShowFunction.Text);
            }
        }

        private bool DgvSpread
        {
            get
            {
                if (bS1_Show.BtnImageIndex == 4) { return false; }
                else if (bS1_Show.BtnImageIndex == 3) { return true; }
                return false;
            }
        }

        public Page1_UCtrl()
        {
            InitializeComponent();

            DgvShowTimer.Interval = 1;
            DgvShowTimer.Tick += loggerTimer_Tick;

            secsParaPage_11.BackSECSmsg_Event += secsParaPage_11_BackSECSmsg_Event;
            secsParaPage_11.Delete_Event += secsParaPage_11_Delete_Event;

            RecList.Clear();
            SenList.Clear();
            LinkTableCenter.RecList_SetGet = RecList;
            LinkTableCenter.SenList_SetGet = SenList;

            InitDGV();
            SECSsystem.IsFileBeenWorked_StateChange = true;

            SECSsystem.DoBeforeCloseAppEvent_1 += SECSsystem_DoBeforeCloseAppEvent_1;
            SECSsystem.DoSaveDGVFileEvent += SECSsystem_DoSaveDGVFileEvent;
            SECSsystem.DoOpenFileEvent += openNewOne;
            SECSsystem.DoCloseFileEvent += closeDGV;
        }

        private void SECSsystem_DoSaveDGVFileEvent(object sender, EventArgs e)
        {
            DoDGVrecord();
            SECSsystem.SecsDGVfileName = SECSsystem.SystemInitOpenFile;
            DGV_XML_Converter.DoSaveDGVDatas(str, LinkTableConverter.GetLinkTableStruct(LinkTableCenter.LinkTable_Get, RecList, SenList), true);
            SECSsystem.SecsDGVfileName = string.Empty;
        }

        public bool OpenFileByPath(string path, bool isEmptyFile = true)
        {
            SECSsystem.IsFileBeenWorked_StateChange = true;
            if (isEmptyFile)
            {
                RecList.Clear();
                SenList.Clear();

                dgv_Msgs.Rows.Clear();
                return true;
            }
            DGVstruct dgvs = DGV_XML_Converter.GetDGVDatasByFile(path);
            DoDGVset(dgvs);
            LinkTableCenter.OpenFileByPath_LinkTable(path);
            LinkTableCenter.DoDGVListChange();
            return true;
        }

        private void InitDGV()
        {
            dgv_Msgs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Msgs.ColumnCount = 0;

            //第4行
            DataGridViewTextBoxColumn buttonColumn4 = new DataGridViewTextBoxColumn();
            buttonColumn4.Name = "button_column4";
            buttonColumn4.HeaderText = "Description";
            int columnIndex4 = 0;
            if (dgv_Msgs.Columns["button_column4"] == null)
            {
                dgv_Msgs.Columns.Insert(columnIndex4, buttonColumn4);
            }

            //第3行
            DataGridViewCheckBoxColumn buttonColumn3 = new DataGridViewCheckBoxColumn();
            buttonColumn3.Name = "button_column3";
            buttonColumn3.HeaderText = "Use";
            int columnIndex3 = 0;
            if (dgv_Msgs.Columns["button_column3"] == null)
            {
                dgv_Msgs.Columns.Insert(columnIndex3, buttonColumn3);
            }

            //第2行
            DataGridViewTextBoxColumn buttonColumn2 = new DataGridViewTextBoxColumn();
            buttonColumn2.Name = "button_column2";
            buttonColumn2.HeaderText = "Name";
            int columnIndex2 = 0;
            if (dgv_Msgs.Columns["button_column2"] == null)
            {
                dgv_Msgs.Columns.Insert(columnIndex2, buttonColumn2);
            }

            //第1行
            DataGridViewTextBoxColumn buttonColumn1 = new DataGridViewTextBoxColumn();
            buttonColumn1.Name = "button_column1";
            buttonColumn1.HeaderText = "SF";
            int columnIndex1 = 0;
            if (dgv_Msgs.Columns["button_column1"] == null)
            {
                dgv_Msgs.Columns.Insert(columnIndex1, buttonColumn1);
            }
            buttonColumn1.ReadOnly = true;

            //第0行
            DataGridViewButtonColumn buttonColumn0 = new DataGridViewButtonColumn();
            buttonColumn0.Name = "button_column0";
            buttonColumn0.HeaderText = "#No";
            //buttonColumn0.Text = "#No";
            int columnIndex0 = 0;
            if (dgv_Msgs.Columns["button_column0"] == null)
            {
                dgv_Msgs.Columns.Insert(columnIndex0, buttonColumn0);
            }

            dgv_Msgs.Columns[0].Width = 50;
            dgv_Msgs.Columns[1].Width = 50;
            dgv_Msgs.Columns[2].Width = 100;
            dgv_Msgs.Columns[3].Width = 30;

            row = (DataGridViewRow)dgv_Msgs.Rows[0].Clone();

            dgv_Msgs.AllowUserToAddRows = false;
        }

        private void openNewOne(object sender, EventArgs e)
        {
            OpenFileByPath(string.Empty);
            lockALLitems(false);
        }

        private void closeDGV(object sender, EventArgs e)
        {
            OpenFileByPath(string.Empty);
            lockALLitems(true);
        }

        private void lockALLitems(bool locking)
        {
            DoOpenClose(false);
            if (locking)
            {
                dgv_Msgs.Enabled = false;
                cms_DGV.Enabled = false;
                bS1_Show.Enabled = false;
                tableLayoutPanel1.Enabled = false;
            }
            else
            {
                dgv_Msgs.Enabled = true;
                cms_DGV.Enabled = true;
                bS1_Show.Enabled = true;
                tableLayoutPanel1.Enabled = true;
            }
        }

        private void SECSsystem_DoBeforeCloseAppEvent_1(object sender, EventArgs e)
        {
            if (!SECSsystem.IsAutoSaveDGVfile)
            {
                DialogResult result = MessageBox.Show("Do you want to save DGV file?", "Ask", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) { return; }
            }
            DGV_XML_Converter.DoSaveDGVDatas(str, LinkTableConverter.GetLinkTableStruct(LinkTableCenter.LinkTable_Get, RecList, SenList));
        }

        private void DoDGVset(DGVstruct dgvs)
        {
            RecList.Clear();
            SenList.Clear();
            secsItemNow = new SECSItem();
            IsRec = true;
            cbx_Search.Text = string.Empty;
            DoOpenClose(false);

            str = dgvs;

            foreach (ROWstruct r in dgvs.AllDatas.Values)
            {
                if (r.Index >= 0)
                {
                    DoAddRow(r);
                }
            }
            DoChanging();

            LinkTableCenter.Init_LinkTable_Receives();
        }

        private void DoDGVrecord()
        {
            str.AllDatas.Clear();
            foreach (DataGridViewRow r in dgv_Msgs.Rows)
            {
                if (r.Index >= 0)
                {
                    ROWstruct newRow = new ROWstruct();

                    newRow.Index = r.Index;

                    if (RecList.ContainsValue((SECSItem)r.Tag))
                    {
                        newRow.IsReceive = true;
                        newRow.IsSend = false;

                        newRow.SECSMsg = ((SECSItem)r.Tag).Clone();

                        newRow.IsUse = ((SECSItem)r.Tag).IsUsed;
                        newRow.Stream = ((SECSItem)r.Tag).Stream;
                        newRow.Function = ((SECSItem)r.Tag).Function;
                        newRow.Name = ((SECSItem)r.Tag).Name;
                        newRow.Description = ((SECSItem)r.Tag).Description;

                        str.AllDatas.Add(str.AllDatas.Count, newRow);
                    }
                    else if (SenList.ContainsValue((SECSItem)r.Tag))
                    {
                        newRow.IsReceive = false;
                        newRow.IsSend = true;

                        newRow.SECSMsg = ((SECSItem)r.Tag).Clone();

                        newRow.IsUse = ((SECSItem)r.Tag).IsUsed;
                        newRow.Stream = ((SECSItem)r.Tag).Stream;
                        newRow.Function = ((SECSItem)r.Tag).Function;
                        newRow.Name = ((SECSItem)r.Tag).Name;
                        newRow.Description = ((SECSItem)r.Tag).Description;

                        str.AllDatas.Add(str.AllDatas.Count, newRow);
                    }
                }
            }
        }

        private void secsParaPage_11_Delete_Event(object sender, EventArgs e)
        {
            bool isRowFound = false;
            DataGridViewRow beDeleteRow = null;
            foreach (DataGridViewRow r in dgv_Msgs.Rows)
            {
                if (r.Tag.Equals(secsItemNow))
                {
                    beDeleteRow = r;
                    isRowFound = true;
                }
            }

            if (isRowFound)
            {
                if (RecList.Values.Contains(secsItemNow))
                {
                    int k = RecList.FirstOrDefault(x => x.Value == secsItemNow).Key;
                    RecList.Remove(k);
                    LinkTableCenter.DoDGVListChange();
                }
                if (SenList.Values.Contains(secsItemNow))
                {
                    int k = SenList.FirstOrDefault(x => x.Value == secsItemNow).Key;
                    SenList.Remove(k);
                    LinkTableCenter.DoDGVListChange();
                }
                dgv_Msgs.Rows.Remove(beDeleteRow);
                RefreshNum();
                DoOpenClose(false);
            }
            else
            {
                MessageBox.Show("Target SECS message was not found");
                DoOpenClose(false);
            }

            dgv_Msgs.Focus();
        }

        private void secsParaPage_11_BackSECSmsg_Event(object sender, EventArgs_SECSParaPage e)
        {
            secsItemNow.SetBase(e.secsMsg);
            DoOpenClose(false);

            foreach (DataGridViewRow r in dgv_Msgs.Rows)
            {
                if (r.Tag.Equals(secsItemNow))
                {
                    r.Cells[1].Value = e.secsMsg.GetSF_string;
                    if (e.isEnd)
                    {
                        r.Cells[1].Style.BackColor = Color.FromKnownColor(KnownColor.YellowGreen);
                        r.Cells[3].ReadOnly = false;
                        return;
                    }
                    else
                    {
                        r.Cells[1].Style.BackColor = Color.FromKnownColor(KnownColor.Red);
                        r.Cells[3].Value = false;
                        r.Cells[3].ReadOnly = true;

                        ((SECSItem)r.Tag).IsUsed = false;
                        return;
                    }
                }
            }

            MessageBox.Show("Target SECS message was not found");
            dgv_Msgs.Focus();
        }

        private void DoAddRow(ROWstruct rowst)
        {
            DataGridViewRow row0 = (DataGridViewRow)row.Clone();

            if (rowst.IsReceive) { RecList.Add(RecList.Count, new SECSItem()); } else { SenList.Add(SenList.Count, new SECSItem()); }
            if (rowst.IsReceive) { row0.Tag = (object)RecList[RecList.Count - 1]; } else { row0.Tag = (object)SenList[SenList.Count - 1]; }

            row0.Cells[1].Value = rowst.SECSMsg.GetSF_string;
            row0.Cells[2].Value = rowst.Name;
            if (rowst.IsUse)
            {
                ((DataGridViewCheckBoxCell)row0.Cells[3]).Value = true;
            }
            else
            {
                ((DataGridViewCheckBoxCell)row0.Cells[3]).Value = false;
            }
            row0.Cells[4].Value = rowst.Description;

            ((SECSItem)row0.Tag).Name = rowst.Name;
            ((SECSItem)row0.Tag).Description = rowst.Description;
            ((SECSItem)row0.Tag).IsUsed = rowst.IsUse;
            ((SECSItem)row0.Tag).SetBase(rowst.SECSMsg);

            if (rowst.SECSMsg.IsEnd())
            {
                row0.Cells[1].Style.BackColor = Color.FromKnownColor(KnownColor.YellowGreen);
                row0.Cells[3].ReadOnly = false;
            }
            else
            {
                row0.Cells[1].Style.BackColor = Color.FromKnownColor(KnownColor.Red);
                row0.Cells[3].Value = false;
                row0.Cells[3].ReadOnly = true;
            }

            dgv_Msgs.Rows.Add(row0);
            dgv_Msgs.FirstDisplayedScrollingRowIndex = dgv_Msgs.RowCount - 1;

            RefreshNum();
        }

        private void DoAddRow(SECSmsg msg = null)
        {
            DataGridViewRow row0 = (DataGridViewRow)row.Clone();

            SECSItem newone = new SECSItem();
            if (IsRec) { RecList.Add(RecList.Count, newone); } else { SenList.Add(SenList.Count, newone); }
            row0.Tag = (object)newone;

            row0.Cells[1].Value = "S0F0";
            if (msg != null)
            {
                row0.Cells[1].Value = msg.GetSF_string;
                SECSItem secsIt = (SECSItem)row0.Tag;
                secsIt.SetBase(msg);
                secsIt.Stream = msg.Stream;
                secsIt.Function = msg.Function;
                secsIt.Name = string.Format("(New Paste)");
            }
            dgv_Msgs.Rows.Add(row0);
            dgv_Msgs.FirstDisplayedScrollingRowIndex = dgv_Msgs.RowCount - 1;

            RefreshNum();

            if (msg != null)
            {
                DoOpenClose(true);
                secsItemNow = (SECSItem)row0.Tag;
                secsParaPage_11.SetSECSmsg((SECSItem)row0.Tag);
            }
        }

        private void RefreshNum()
        {
            int i = 1;
            int visibleCount = 0;
            foreach (DataGridViewRow r in dgv_Msgs.Rows)
            {
                if (r.Visible)
                {
                    visibleCount++;
                }
            }
            foreach (DataGridViewRow r in dgv_Msgs.Rows)
            {
                if (r.Visible && visibleCount >= i)
                {
                    r.Cells[0].Value = i.ToString();
                    i++;
                }
            }
        }

        private void DoShowOrNotShow()
        {
            if (!cms_ShowEnableSF.Checked)
            {
                if (IsRec)
                {
                    foreach (DataGridViewRow r in dgv_Msgs.Rows)
                    {
                        if (RecList.ContainsValue((SECSItem)r.Tag))
                        {
                            if (IsShowUsed && ((SECSItem)r.Tag).IsUsed)
                            {
                                r.Visible = true;
                            }
                            else if (IsShowUnUsed && !((SECSItem)r.Tag).IsUsed)
                            {
                                r.Visible = true;
                            }
                            else
                            {
                                r.Visible = false;
                            }
                        }
                        else
                        {
                            r.Visible = false;
                        }
                    }
                }
                if (IsSen)
                {
                    foreach (DataGridViewRow r in dgv_Msgs.Rows)
                    {
                        if (SenList.ContainsValue((SECSItem)r.Tag))
                        {
                            if (IsShowUsed && ((SECSItem)r.Tag).IsUsed)
                            {
                                r.Visible = true;
                            }
                            else if (IsShowUnUsed && !((SECSItem)r.Tag).IsUsed)
                            {
                                r.Visible = true;
                            }
                            else
                            {
                                r.Visible = false;
                            }
                        }
                        else
                        {
                            r.Visible = false;
                        }
                    }
                }
            }
            else
            {
                if (IsRec)
                {
                    foreach (DataGridViewRow r in dgv_Msgs.Rows)
                    {
                        if (RecList.ContainsValue((SECSItem)r.Tag))
                        {
                            if (NowShowSF.Contains(((SECSItem)r.Tag).GetSF_string))
                            {
                                if (RecList.ContainsValue((SECSItem)r.Tag))
                                {
                                    if (IsShowUsed && ((SECSItem)r.Tag).IsUsed)
                                    {
                                        r.Visible = true;
                                    }
                                    else if (IsShowUnUsed && !((SECSItem)r.Tag).IsUsed)
                                    {
                                        r.Visible = true;
                                    }
                                    else
                                    {
                                        r.Visible = false;
                                    }
                                }
                            }
                            else
                            {
                                r.Visible = false;
                            }
                        }
                    }
                }
                if (IsSen)
                {
                    foreach (DataGridViewRow r in dgv_Msgs.Rows)
                    {
                        if (SenList.ContainsValue((SECSItem)r.Tag))
                        {
                            if (NowShowSF.Contains(((SECSItem)r.Tag).GetSF_string))
                            {
                                if (SenList.ContainsValue((SECSItem)r.Tag))
                                {
                                    if (IsShowUsed && ((SECSItem)r.Tag).IsUsed)
                                    {
                                        r.Visible = true;
                                    }
                                    else if (IsShowUnUsed && !((SECSItem)r.Tag).IsUsed)
                                    {
                                        r.Visible = true;
                                    }
                                    else
                                    {
                                        r.Visible = false;
                                    }
                                }
                            }
                            else
                            {
                                r.Visible = false;
                            }
                        }
                    }
                }
            }
            RefreshNum();
        }

        private void loggerTimer_Tick(object sender, EventArgs e)
        {
            TableLayoutRowStyleCollection cStyle = tlp_Base.RowStyles;
            if (DgvSpread && tlp_Base.RowStyles[3].Height > 0)
            {
                tlp_Base.RowStyles[3].Height -= 10;
                if (tlp_Base.RowStyles[3].Height <= 0) { secsParaPage_11.ResumeLayout(); DgvShowTimer.Stop(); }
            }
            else
            {
                tlp_Base.RowStyles[3].Height += 10;
                if (tlp_Base.RowStyles[3].Height >= 200) { secsParaPage_11.ResumeLayout(); DgvShowTimer.Stop(); }
            }
        }

        private void bS1_Show_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            DoOpenClose();
        }

        #region --開啟連頁--

        private void DoOpenClose()
        {
            secsParaPage_11.SuspendLayout();
            if (DgvSpread)
            {
                bS1_Show.BtnImageIndex = 4;
            }
            else
            {
                bS1_Show.BtnImageIndex = 3;
            }
            if (!DgvShowTimer.Enabled) { DgvShowTimer.Start(); }
        }

        private void DoOpenClose(bool isOpen)
        {
            secsParaPage_11.SuspendLayout();
            if (isOpen)
            {
                if (isOpen != DgvSpread) { secsParaPage_11.ResumeLayout(); return; }
                bS1_Show.BtnImageIndex = 4;
            }
            else
            {
                if (isOpen != DgvSpread) { secsParaPage_11.ResumeLayout(); return; }
                bS1_Show.BtnImageIndex = 3;
            }
            if (!DgvShowTimer.Enabled) { DgvShowTimer.Start(); }
        }

        #endregion --開啟連頁--

        private void bS1_Add_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            DoAddRow();
            LinkTableCenter.Init_LinkTable_Receives();
        }

        private void dgv_Msgs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.RowIndex >= 0)
                {
                    DoOpenClose(true);
                    DataGridViewRow row0 = dgv_Msgs.Rows[e.RowIndex];
                    secsItemNow = (SECSItem)row0.Tag;
                    secsParaPage_11.SetSECSmsg((SECSItem)row0.Tag);
                }
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                if (e.RowIndex >= 0)
                {
                    dgv_Msgs.EndEdit(); //不知道原理(成功)
                    DataGridViewRow row0 = dgv_Msgs.Rows[e.RowIndex];
                    if (((SECSItem)row0.Tag).IsMsgHas_Spare && IsSen) 
                    { 
                        MessageBox.Show("This message contains Spare item", "Error");
                        ((DataGridViewCheckBoxCell)row0.Cells[3]).Value = false; 
                        return; 
                    }
                    object v = ((DataGridViewCheckBoxCell)row0.Cells[3]).Value;
                    if (v != null)
                    {
                        ((SECSItem)row0.Tag).IsUsed = (bool)v;
                        if (IsRec) { LinkTableCenter.Init_LinkTable_Receives(); }
                        LinkTableCenter.DoDGVListChange();
                    }
                }
            }
        }

        private void cbx_Search_DropDown(object sender, EventArgs e)
        {
            cbx_Search.Items.Clear();

            Dictionary<Tuple<int, int>, int> countOfSF = new Dictionary<Tuple<int, int>, int>();

            foreach (DataGridViewRow r in dgv_Msgs.Rows)
            {
                SECSItem sItem = (SECSItem)r.Tag;
                if (IsRec && RecList.ContainsValue(sItem))
                {
                    Tuple<int, int> sf = new Tuple<int, int>(sItem.Stream, sItem.Function);

                    if (!countOfSF.ContainsKey(sf)) { countOfSF.Add(sf, 0); }

                    countOfSF[sf]++;
                }
                else if (IsSen && SenList.ContainsValue(sItem))
                {
                    Tuple<int, int> sf = new Tuple<int, int>(sItem.Stream, sItem.Function);

                    if (!countOfSF.ContainsKey(sf)) { countOfSF.Add(sf, 0); }

                    countOfSF[sf]++;
                }
            }

            Sorting(ref countOfSF);

            foreach (Tuple<int, int> vCount in countOfSF.Keys)
            {
                string w = string.Format("S{0}F{1}  :  {2}", vCount.Item1.ToString(), vCount.Item2.ToString(), countOfSF[vCount].ToString());
                cbx_Search.Items.Add(w);
            }
        }

        private void DoChanging()
        {
            if (IsRec)
            {
                secsParaPage_11.IsAllowSpareLine = true;
                bS1_State.Text_Button = "Receive";
                bS1_State.ButtonNoneColor_KnownColor = Color.FromKnownColor(KnownColor.Navy);

                /*
                foreach (DataGridViewRow r in dgv_Msgs.Rows)
                {
                    if (RecList.ContainsValue((SECSItem)r.Tag)) { r.Visible = true; } else { r.Visible = false; }
                }
                */

                cms_SendPrimary.Enabled = false;
                cms_SendSecondary.Enabled = false;
            }
            else
            {
                secsParaPage_11.IsAllowSpareLine = false;
                bS1_State.Text_Button = "Send";
                bS1_State.ButtonNoneColor_KnownColor = Color.FromKnownColor(KnownColor.Aqua);

                /*
                foreach (DataGridViewRow r in dgv_Msgs.Rows)
                {
                    if (SenList.ContainsValue((SECSItem)r.Tag)) { r.Visible = true; } else { r.Visible = false; }
                }*/

                cms_SendPrimary.Enabled = true;
                cms_SendSecondary.Enabled = true;
            }
            DoShowOrNotShow();
        }

        private void Sorting(ref Dictionary<Tuple<int, int>, int> sour)
        {
            bool isChange = true;

            Dictionary<int, Tuple<int, int>> sfDic = new Dictionary<int, Tuple<int, int>>();

            foreach (Tuple<int, int> nowOne in sour.Keys)
            {
                sfDic.Add(sfDic.Count, nowOne);
            }

            while (isChange)
            {
                isChange = false;
                Tuple<int, int> lastTuple = null;

                for (int i = 0; i < sfDic.Count; i++)
                {
                    if (i > 0)
                    {
                        if (sfDic[i].Item1 < lastTuple.Item1)
                        {
                            Tuple<int, int> newfront = sfDic[i];
                            Tuple<int, int> newlast = lastTuple;

                            sfDic.Remove(i);
                            sfDic.Remove(i - 1);

                            sfDic.Add(i - 1, newfront);
                            sfDic.Add(i, newlast);

                            isChange = true;
                            break;
                        }
                        else if (sfDic[i].Item1 == lastTuple.Item1)
                        {
                            if (sfDic[i].Item2 < lastTuple.Item2)
                            {
                                Tuple<int, int> newfront = sfDic[i];
                                Tuple<int, int> newlast = lastTuple;

                                sfDic.Remove(i);
                                sfDic.Remove(i - 1);

                                sfDic.Add(i - 1, newfront);
                                sfDic.Add(i, newlast);

                                isChange = true;
                                break;
                            }
                        }
                    }
                    lastTuple = sfDic[i];
                }
            }

            Dictionary<Tuple<int, int>, int> newSour = new Dictionary<Tuple<int, int>, int>();
            for (int i = 0; i < sfDic.Count; i++)
            {
                newSour.Add(sfDic[i], sour[sfDic[i]]);
            }

            sour = new Dictionary<Tuple<int, int>, int>(newSour);
        }

        private void bS1_Search_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            char[] spl = { ' ' };
            if (string.IsNullOrEmpty(cbx_Search.Text))
            {
                NowShowSF = "SxFx";
                cms_ShowEnableSF.Checked = false;
            }
            else
            {
                string[] v = cbx_Search.Text.Split(spl);
                NowShowSF = v[0];
                cms_ShowEnableSF.Checked = true;
            }

            DoShowOrNotShow();
        }

        private void bS1_State_ButtonStyle1_OnclickEvent(object sender, EventArgs e)
        {
            if (IsRec)
            {
                IsSen = true;
                secsParaPage_11.IsAllowSpareLine = false;
                bS1_State.Text_Button = "Send";
                bS1_State.ButtonNoneColor_KnownColor = Color.FromKnownColor(KnownColor.Aqua);
            }
            else
            {
                IsRec = true;
                secsParaPage_11.IsAllowSpareLine = true;
                bS1_State.Text_Button = "Receive";
                bS1_State.ButtonNoneColor_KnownColor = Color.FromKnownColor(KnownColor.Navy);
            }
        }

        private void cms_ShowAllMessages_Click(object sender, EventArgs e)
        {
            cbx_Search.Text = string.Empty;
            cms_ShowUsed.Checked = true;
            cms_ShowUnUsed.Checked = true;
            cms_ShowEnableSF.Checked = false;

            if (IsRec)
            {
                foreach (DataGridViewRow r in dgv_Msgs.Rows)
                {
                    if (RecList.ContainsValue((SECSItem)r.Tag))
                    {
                        r.Visible = true;
                    }
                }
            }
            if (IsSen)
            {
                foreach (DataGridViewRow r in dgv_Msgs.Rows)
                {
                    if (SenList.ContainsValue((SECSItem)r.Tag))
                    {
                        r.Visible = true;
                    }
                }
            }

            RefreshNum();
        }

        private void cms_ShowUse_CheckedChanged(object sender, EventArgs e)
        {
            DoShowOrNotShow();
        }

        private void cms_ShowEnableSF_CheckedChanged(object sender, EventArgs e)
        {
            DoShowOrNotShow();
        }

        private void allDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do delete all message?", "Warnning", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }
            if (IsRec)
            {
                List<DataGridViewRow> collection = new List<DataGridViewRow>();
                foreach (DataGridViewRow r in dgv_Msgs.Rows)
                {
                    if (RecList.ContainsValue((SECSItem)r.Tag))
                    {
                        collection.Add(r);
                    }
                }
                for (int i = 0; i < collection.Count; i++)
                {
                    dgv_Msgs.Rows.Remove(collection[i]);
                }
                RecList.Clear();
            }
            if (IsSen)
            {
                List<DataGridViewRow> collection = new List<DataGridViewRow>();
                foreach (DataGridViewRow r in dgv_Msgs.Rows)
                {
                    if (SenList.ContainsValue((SECSItem)r.Tag))
                    {
                        collection.Add(r);
                    }
                }
                for (int i = 0; i < collection.Count; i++)
                {
                    dgv_Msgs.Rows.Remove(collection[i]);
                }
                SenList.Clear();
            }
        }

        private void dgv_Msgs_Leave(object sender, EventArgs e)
        {
            DoDGVrecord();
        }

        private void dgv_Msgs_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                if (e.RowIndex >= 0)
                {
                    //dgv_Msgs.EndEdit(); //不知道原理(成功)
                    DataGridViewRow row0 = dgv_Msgs.Rows[e.RowIndex];

                    if (e.ColumnIndex == 2) //Name
                    {
                        object v = ((DataGridViewTextBoxCell)row0.Cells[e.ColumnIndex]).EditedFormattedValue;
                        if (v != null) { ((SECSItem)row0.Tag).Name = v.ToString(); LinkTableCenter.DoDGVListChange(); }
                    }

                    if (e.ColumnIndex == 4) //Name
                    {
                        object v = ((DataGridViewTextBoxCell)row0.Cells[e.ColumnIndex]).EditedFormattedValue;
                        if (v != null) { ((SECSItem)row0.Tag).Description = v.ToString(); }
                    }
                }
            }
        }

        private void pasteMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SECSsystem.SECS_Clipboard != null)
            {
                SECSmsg ob = SECSsystem.SECS_Clipboard;
                DoAddRow(ob);
                DoShowOrNotShow();
                SECSsystem.SECS_Clipboard = null;
                LinkTableCenter.Init_LinkTable_Receives();
            }
        }

        private void cms_DGV_Opening(object sender, CancelEventArgs e)
        {
            if (SECSsystem.SECS_Clipboard != null)
            {
                cms_Paste.Enabled = true;
                cms_Paste.Text = string.Format("Paste {0} Message", SECSsystem.SECS_Clipboard.GetSF_string);
            }
            else
            {
                cms_Paste.Enabled = false;
                cms_Paste.Text = string.Format("Paste Message");
            }
        }

        private void dgv_Msgs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgv_Msgs.HitTest(e.X, e.Y);
                dgv_Msgs.ClearSelection();
                if (hti.RowIndex >= 0)
                {
                    dgv_Msgs.Rows[hti.RowIndex].Selected = true;
                    cms_DeleteRow.Enabled = true;
                    cms_copyMessage.Enabled = true;

                    if (IsSen ) { cms_SendPrimary.Enabled = true; cms_SendSecondary.Enabled = true; }
                }
                else
                {
                    cms_DeleteRow.Enabled = false;
                    cms_SendPrimary.Enabled = false;
                    cms_SendSecondary.Enabled = false;
                    cms_copyMessage.Enabled = false;
                }
            }
        }

        private void cms_DeleteRow_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = dgv_Msgs.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (IsRec)
            {
                List<int> removeTar = new List<int>();
                foreach (var item in RecList.Where(kvp => kvp.Value == ((SECSItem)dgv_Msgs.Rows[rowToDelete].Tag)).ToList())
                {
                    removeTar.Add(item.Key);
                }
                foreach (int t in removeTar) { RecList.Remove(t); LinkTableCenter.DoDGVListChange(); }
            }
            else
            {
                List<int> removeTar = new List<int>();
                foreach (var item in SenList.Where(kvp => kvp.Value == ((SECSItem)dgv_Msgs.Rows[rowToDelete].Tag)).ToList())
                {
                    removeTar.Add(item.Key);
                }
                foreach (int t in removeTar) { SenList.Remove(t); LinkTableCenter.DoDGVListChange(); }
            }

            dgv_Msgs.Rows.RemoveAt(rowToDelete);
            dgv_Msgs.ClearSelection();

            dgv_Msgs.Focus();
            RefreshNum();
        }

        private void dgv_Msgs_MouseEnter(object sender, EventArgs e)
        {
            dgv_Msgs.Focus();
        }

        private void cms_SendPrimary_Click(object sender, EventArgs e)
        {
            Int32 rowToSend = dgv_Msgs.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            TheMessage msg = new TheMessage();
            msg.SECS_Msg = ((SECSItem)dgv_Msgs.Rows[rowToSend].Tag).Clone();
            msg.SECS_Msg.IsWaitBit = true;
            msg.SECS_Msg.AsPrimaryMessage = true;
            if (msg.SECS_Msg.IsMsgHas_Spare) { MessageBox.Show("This message contains Spare item", "Error"); return; }
            if (SendMsg_Event != null)
            {
                EventArgs_TheMessage arg = new EventArgs_TheMessage();
                arg.themsg = msg;
                SendMsg_Event.Invoke(this, arg);
            }
        }

        private void sendSecondaryMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 rowToSend = dgv_Msgs.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            TheMessage msg = new TheMessage();
            msg.SECS_Msg = ((SECSItem)dgv_Msgs.Rows[rowToSend].Tag).Clone();
            msg.SECS_Msg.IsWaitBit = false;
            msg.SECS_Msg.AsSecondaryMessage = true;
            if (msg.SECS_Msg.IsMsgHas_Spare) { MessageBox.Show("This message contains Spare item", "Error"); return; }
            if (SendMsg_Event != null)
            {
                EventArgs_TheMessage arg = new EventArgs_TheMessage();
                arg.themsg = msg;
                SendMsg_Event.Invoke(this, arg);
            }
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int stream = 0;
            int function = 0;

            if (int.TryParse(cms_deleteS.Text, out stream) && int.TryParse(cms_deleteF.Text, out function))
            {
                List<SECSItem> abortItems = new List<SECSItem>();
                if (IsRec)
                {
                    foreach (SECSItem item in RecList.Values)
                    {
                        if (item.Stream == stream && item.Function == function)
                        {
                            abortItems.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (SECSItem item in SenList.Values)
                    {
                        if (item.Stream == stream && item.Function == function)
                        {
                            abortItems.Add(item);
                        }
                    }
                }
                if (MessageBox.Show(string.Format("Are you sure do delete {0} messages?", abortItems.Count), "Warnning", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }

                foreach (SECSItem item in abortItems)
                {
                    if (IsRec)
                    {
                        if (RecList.ContainsValue(item)) { RecList.Remove(RecList.FirstOrDefault(x => x.Value == item).Key); }
                    }
                    else
                    {
                        if (SenList.ContainsValue(item)) { SenList.Remove(SenList.FirstOrDefault(x => x.Value == item).Key); }
                    }
                }

                List<DataGridViewRow> abortRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow ro in dgv_Msgs.Rows)
                {
                    if (abortItems.Contains(ro.Tag as SECSItem))
                    {
                        abortRows.Add(ro);
                    }
                }

                foreach (DataGridViewRow ro in abortRows)
                {
                    dgv_Msgs.Rows.Remove(ro);
                }

                abortRows.Clear();
                abortItems.Clear();

                dgv_Msgs.Focus();
                RefreshNum();
                LinkTableCenter.Init_LinkTable_Receives();
            }
        }

        private void cms_copyMessage_Click(object sender, EventArgs e)
        {
            int place = dgv_Msgs.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            SECSsystem.SECS_Clipboard = (SECSmsg)dgv_Msgs.Rows[place].Tag;
        }

        private void dgv_Msgs_Sorted(object sender, EventArgs e)
        {
            RefreshNum();
        }


    }

    public class DGVstruct
    {
        private Dictionary<int, ROWstruct> allDatas = new Dictionary<int, ROWstruct>();

        public Dictionary<int, ROWstruct> AllDatas { get { return allDatas; } set { allDatas = value; } }
    }

    public class ROWstruct
    {
        private int index = -1;

        private bool isReceive = false;
        private bool isSend = false;

        private int stream = -1;
        private int function = -1;

        private string name = string.Empty;
        private bool isUse = false;
        private string description = string.Empty;

        private SECSmsg secsMsg = new SECSmsg();

        public int Index { get { return index; } set { index = value; } }

        public bool IsReceive { get { return isReceive; } set { isReceive = value; } }

        public bool IsSend { get { return isSend; } set { isSend = value; } }

        public int Stream { get { return stream; } set { stream = value; } }

        public int Function { get { return function; } set { function = value; } }

        public string Name { get { return name; } set { name = value; } }

        public bool IsUse { get { return isUse; } set { isUse = value; } }

        public string Description { get { return description; } set { description = value; } }

        public SECSmsg SECSMsg { get { return secsMsg.Clone(); } set { secsMsg = value.Clone(); } }

        public SECSItem SECSItem_Value
        {
            get
            {
                SECSItem item = new SECSItem();
                item.SetBase(secsMsg);

                item.Name = name;
                item.IsUsed = isUse;
                item.Description = description;

                return item;
            }
        }
    }
}