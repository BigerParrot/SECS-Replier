namespace SECSTry
{
    partial class Page1_UCtrl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page1_UCtrl));
            this.tlp_Base = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bS1_State = new SECSCtrlLibs.ButtonStyle1();
            this.bS1_Q = new SECSCtrlLibs.ButtonStyle1();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bS1_Search = new SECSCtrlLibs.ButtonStyle1();
            this.cbx_Search = new System.Windows.Forms.ComboBox();
            this.bS1_Add = new SECSCtrlLibs.ButtonStyle1();
            this.dgv_Msgs = new System.Windows.Forms.DataGridView();
            this.cms_DGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ShowAllMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_ShowUsed = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ShowUnUsed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showSFTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ShowEnableSF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.streamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_tb_ShowStream = new System.Windows.Forms.ToolStripTextBox();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_tb_ShowFunction = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.allS0F0MessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_execute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.streamToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_deleteS = new System.Windows.Forms.ToolStripTextBox();
            this.functionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_deleteF = new System.Windows.Forms.ToolStripTextBox();
            this.cms_DeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_copyMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_SendPrimary = new System.Windows.Forms.ToolStripMenuItem();
            this.bS1_Show = new SECSCtrlLibs.ButtonStyle1();
            this.secsParaPage_11 = new SECSTry.SECSParaPage_1();
            this.tlp_Base.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Msgs)).BeginInit();
            this.cms_DGV.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Base
            // 
            this.tlp_Base.ColumnCount = 1;
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlp_Base.Controls.Add(this.dgv_Msgs, 0, 1);
            this.tlp_Base.Controls.Add(this.bS1_Show, 0, 2);
            this.tlp_Base.Controls.Add(this.secsParaPage_11, 0, 3);
            this.tlp_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Base.Location = new System.Drawing.Point(0, 0);
            this.tlp_Base.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Base.Name = "tlp_Base";
            this.tlp_Base.RowCount = 4;
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlp_Base.Size = new System.Drawing.Size(463, 478);
            this.tlp_Base.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.bS1_State, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bS1_Q, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.bS1_Search, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbx_Search, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.bS1_Add, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(463, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bS1_State
            // 
            this.bS1_State.BackColor = System.Drawing.Color.White;
            this.bS1_State.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_State.BtnImageIndex = -1;
            this.bS1_State.BtnImageList = null;
            this.bS1_State.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_State.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_State.ButtonNoneColor_KnownColor = System.Drawing.Color.Navy;
            this.bS1_State.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_State.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_State.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_State.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_State.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_State.IsListDown = false;
            this.bS1_State.IsOnOffClick = true;
            this.bS1_State.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_State.Location = new System.Drawing.Point(0, 0);
            this.bS1_State.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_State.Name = "bS1_State";
            this.bS1_State.Size = new System.Drawing.Size(100, 25);
            this.bS1_State.Speed = 3;
            this.bS1_State.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_State.TabIndex = 0;
            this.bS1_State.Text_Button = "Receive";
            this.bS1_State.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_State_ButtonStyle1_OnclickEvent);
            // 
            // bS1_Q
            // 
            this.bS1_Q.BackColor = System.Drawing.Color.White;
            this.bS1_Q.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_Q.BtnImageIndex = 0;
            this.bS1_Q.BtnImageList = this.imageList1;
            this.bS1_Q.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Q.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Q.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Q.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Q.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Q.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Q.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Q.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_Q.IsListDown = false;
            this.bS1_Q.IsOnOffClick = true;
            this.bS1_Q.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_Q.Location = new System.Drawing.Point(438, 0);
            this.bS1_Q.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Q.Name = "bS1_Q";
            this.bS1_Q.Size = new System.Drawing.Size(25, 25);
            this.bS1_Q.Speed = 3;
            this.bS1_Q.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Q.TabIndex = 1;
            this.bS1_Q.Text_Button = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "9025906_question_icon.png");
            this.imageList1.Images.SetKeyName(1, "3844432_magnifier_search_zoom_icon.png");
            this.imageList1.Images.SetKeyName(2, "4879897_add_new_plus_icon.png");
            this.imageList1.Images.SetKeyName(3, "186407_arrow_up_icon.png");
            this.imageList1.Images.SetKeyName(4, "186411_arrow_down_icon.png");
            // 
            // bS1_Search
            // 
            this.bS1_Search.BackColor = System.Drawing.Color.White;
            this.bS1_Search.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_Search.BtnImageIndex = 1;
            this.bS1_Search.BtnImageList = this.imageList1;
            this.bS1_Search.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Search.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Search.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Search.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Search.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Search.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Search.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_Search.IsListDown = false;
            this.bS1_Search.IsOnOffClick = true;
            this.bS1_Search.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_Search.Location = new System.Drawing.Point(388, 0);
            this.bS1_Search.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Search.Name = "bS1_Search";
            this.bS1_Search.Size = new System.Drawing.Size(25, 25);
            this.bS1_Search.Speed = 3;
            this.bS1_Search.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Search.TabIndex = 2;
            this.bS1_Search.Text_Button = "";
            this.bS1_Search.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_Search_ButtonStyle1_OnclickEvent);
            // 
            // cbx_Search
            // 
            this.cbx_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_Search.FormattingEnabled = true;
            this.cbx_Search.Location = new System.Drawing.Point(120, 0);
            this.cbx_Search.Margin = new System.Windows.Forms.Padding(0);
            this.cbx_Search.Name = "cbx_Search";
            this.cbx_Search.Size = new System.Drawing.Size(268, 23);
            this.cbx_Search.TabIndex = 3;
            this.cbx_Search.DropDown += new System.EventHandler(this.cbx_Search_DropDown);
            // 
            // bS1_Add
            // 
            this.bS1_Add.BackColor = System.Drawing.Color.White;
            this.bS1_Add.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_Add.BtnImageIndex = 2;
            this.bS1_Add.BtnImageList = this.imageList1;
            this.bS1_Add.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Add.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Add.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Add.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Add.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Add.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Add.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_Add.IsListDown = false;
            this.bS1_Add.IsOnOffClick = true;
            this.bS1_Add.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_Add.Location = new System.Drawing.Point(413, 0);
            this.bS1_Add.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Add.Name = "bS1_Add";
            this.bS1_Add.Size = new System.Drawing.Size(25, 25);
            this.bS1_Add.Speed = 3;
            this.bS1_Add.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Add.TabIndex = 4;
            this.bS1_Add.Text_Button = "";
            this.bS1_Add.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_Add_ButtonStyle1_OnclickEvent);
            // 
            // dgv_Msgs
            // 
            this.dgv_Msgs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Msgs.ContextMenuStrip = this.cms_DGV;
            this.dgv_Msgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Msgs.Location = new System.Drawing.Point(0, 25);
            this.dgv_Msgs.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Msgs.Name = "dgv_Msgs";
            this.dgv_Msgs.RowHeadersVisible = false;
            this.dgv_Msgs.RowTemplate.Height = 27;
            this.dgv_Msgs.Size = new System.Drawing.Size(463, 228);
            this.dgv_Msgs.TabIndex = 1;
            this.dgv_Msgs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Msgs_CellContentClick);
            this.dgv_Msgs.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Msgs_CellLeave);
            this.dgv_Msgs.Sorted += new System.EventHandler(this.dgv_Msgs_Sorted);
            this.dgv_Msgs.Leave += new System.EventHandler(this.dgv_Msgs_Leave);
            this.dgv_Msgs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_Msgs_MouseDown);
            this.dgv_Msgs.MouseEnter += new System.EventHandler(this.dgv_Msgs_MouseEnter);
            // 
            // cms_DGV
            // 
            this.cms_DGV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_DGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllDataToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearAllDataToolStripMenuItem,
            this.cms_DeleteRow,
            this.toolStripSeparator4,
            this.cms_copyMessage,
            this.cms_Paste,
            this.toolStripSeparator8,
            this.cms_SendPrimary});
            this.cms_DGV.Name = "cms_DGV";
            this.cms_DGV.Size = new System.Drawing.Size(228, 166);
            this.cms_DGV.Opening += new System.ComponentModel.CancelEventHandler(this.cms_DGV_Opening);
            // 
            // showAllDataToolStripMenuItem
            // 
            this.showAllDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_ShowAllMessages,
            this.toolStripSeparator2,
            this.cms_ShowUsed,
            this.cms_ShowUnUsed,
            this.toolStripSeparator3,
            this.showSFTypeToolStripMenuItem});
            this.showAllDataToolStripMenuItem.Name = "showAllDataToolStripMenuItem";
            this.showAllDataToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.showAllDataToolStripMenuItem.Text = "Show Data";
            // 
            // cms_ShowAllMessages
            // 
            this.cms_ShowAllMessages.Name = "cms_ShowAllMessages";
            this.cms_ShowAllMessages.Size = new System.Drawing.Size(229, 26);
            this.cms_ShowAllMessages.Text = "All Messages";
            this.cms_ShowAllMessages.Click += new System.EventHandler(this.cms_ShowAllMessages_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // cms_ShowUsed
            // 
            this.cms_ShowUsed.Checked = true;
            this.cms_ShowUsed.CheckOnClick = true;
            this.cms_ShowUsed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cms_ShowUsed.Name = "cms_ShowUsed";
            this.cms_ShowUsed.Size = new System.Drawing.Size(229, 26);
            this.cms_ShowUsed.Text = "Show Used Message";
            this.cms_ShowUsed.CheckedChanged += new System.EventHandler(this.cms_ShowUse_CheckedChanged);
            // 
            // cms_ShowUnUsed
            // 
            this.cms_ShowUnUsed.Checked = true;
            this.cms_ShowUnUsed.CheckOnClick = true;
            this.cms_ShowUnUsed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cms_ShowUnUsed.Name = "cms_ShowUnUsed";
            this.cms_ShowUnUsed.Size = new System.Drawing.Size(229, 26);
            this.cms_ShowUnUsed.Text = "Show unUsed Message";
            this.cms_ShowUnUsed.CheckedChanged += new System.EventHandler(this.cms_ShowUse_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(226, 6);
            // 
            // showSFTypeToolStripMenuItem
            // 
            this.showSFTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_ShowEnableSF,
            this.toolStripSeparator6,
            this.streamToolStripMenuItem,
            this.cms_tb_ShowStream,
            this.functionToolStripMenuItem,
            this.cms_tb_ShowFunction});
            this.showSFTypeToolStripMenuItem.Name = "showSFTypeToolStripMenuItem";
            this.showSFTypeToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.showSFTypeToolStripMenuItem.Text = "Show SF Type (S0F0)";
            // 
            // cms_ShowEnableSF
            // 
            this.cms_ShowEnableSF.CheckOnClick = true;
            this.cms_ShowEnableSF.Name = "cms_ShowEnableSF";
            this.cms_ShowEnableSF.Size = new System.Drawing.Size(183, 24);
            this.cms_ShowEnableSF.Text = "Enable Function";
            this.cms_ShowEnableSF.CheckedChanged += new System.EventHandler(this.cms_ShowEnableSF_CheckedChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(180, 6);
            // 
            // streamToolStripMenuItem
            // 
            this.streamToolStripMenuItem.Name = "streamToolStripMenuItem";
            this.streamToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.streamToolStripMenuItem.Text = "Stream :";
            // 
            // cms_tb_ShowStream
            // 
            this.cms_tb_ShowStream.Name = "cms_tb_ShowStream";
            this.cms_tb_ShowStream.Size = new System.Drawing.Size(100, 27);
            this.cms_tb_ShowStream.Text = "0";
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.functionToolStripMenuItem.Text = "Function :";
            // 
            // cms_tb_ShowFunction
            // 
            this.cms_tb_ShowFunction.Name = "cms_tb_ShowFunction";
            this.cms_tb_ShowFunction.Size = new System.Drawing.Size(100, 27);
            this.cms_tb_ShowFunction.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
            // 
            // clearAllDataToolStripMenuItem
            // 
            this.clearAllDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allDataToolStripMenuItem,
            this.toolStripSeparator5,
            this.allS0F0MessagesToolStripMenuItem});
            this.clearAllDataToolStripMenuItem.Name = "clearAllDataToolStripMenuItem";
            this.clearAllDataToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.clearAllDataToolStripMenuItem.Text = "Delete Datas";
            // 
            // allDataToolStripMenuItem
            // 
            this.allDataToolStripMenuItem.Name = "allDataToolStripMenuItem";
            this.allDataToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.allDataToolStripMenuItem.Text = "All Messages";
            this.allDataToolStripMenuItem.Click += new System.EventHandler(this.allDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(175, 6);
            // 
            // allS0F0MessagesToolStripMenuItem
            // 
            this.allS0F0MessagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_execute,
            this.toolStripSeparator7,
            this.streamToolStripMenuItem1,
            this.cms_deleteS,
            this.functionToolStripMenuItem1,
            this.cms_deleteF});
            this.allS0F0MessagesToolStripMenuItem.Name = "allS0F0MessagesToolStripMenuItem";
            this.allS0F0MessagesToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.allS0F0MessagesToolStripMenuItem.Text = "Messages Type";
            // 
            // cms_execute
            // 
            this.cms_execute.Name = "cms_execute";
            this.cms_execute.Size = new System.Drawing.Size(160, 24);
            this.cms_execute.Text = "Execute";
            this.cms_execute.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(157, 6);
            // 
            // streamToolStripMenuItem1
            // 
            this.streamToolStripMenuItem1.Name = "streamToolStripMenuItem1";
            this.streamToolStripMenuItem1.Size = new System.Drawing.Size(160, 24);
            this.streamToolStripMenuItem1.Text = "Stream :";
            // 
            // cms_deleteS
            // 
            this.cms_deleteS.Name = "cms_deleteS";
            this.cms_deleteS.Size = new System.Drawing.Size(100, 27);
            // 
            // functionToolStripMenuItem1
            // 
            this.functionToolStripMenuItem1.Name = "functionToolStripMenuItem1";
            this.functionToolStripMenuItem1.Size = new System.Drawing.Size(160, 24);
            this.functionToolStripMenuItem1.Text = "Function :";
            // 
            // cms_deleteF
            // 
            this.cms_deleteF.Name = "cms_deleteF";
            this.cms_deleteF.Size = new System.Drawing.Size(100, 27);
            // 
            // cms_DeleteRow
            // 
            this.cms_DeleteRow.Name = "cms_DeleteRow";
            this.cms_DeleteRow.Size = new System.Drawing.Size(227, 24);
            this.cms_DeleteRow.Text = "Delete Row";
            this.cms_DeleteRow.Click += new System.EventHandler(this.cms_DeleteRow_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(224, 6);
            // 
            // cms_copyMessage
            // 
            this.cms_copyMessage.Name = "cms_copyMessage";
            this.cms_copyMessage.Size = new System.Drawing.Size(227, 24);
            this.cms_copyMessage.Text = "Copy Message";
            this.cms_copyMessage.Click += new System.EventHandler(this.cms_copyMessage_Click);
            // 
            // cms_Paste
            // 
            this.cms_Paste.Name = "cms_Paste";
            this.cms_Paste.Size = new System.Drawing.Size(227, 24);
            this.cms_Paste.Text = "Paste Message";
            this.cms_Paste.Click += new System.EventHandler(this.pasteMessageToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(224, 6);
            // 
            // cms_SendPrimary
            // 
            this.cms_SendPrimary.Name = "cms_SendPrimary";
            this.cms_SendPrimary.Size = new System.Drawing.Size(227, 24);
            this.cms_SendPrimary.Text = "Send Primary Message";
            this.cms_SendPrimary.Click += new System.EventHandler(this.cms_SendPrimary_Click);
            // 
            // bS1_Show
            // 
            this.bS1_Show.BackColor = System.Drawing.Color.White;
            this.bS1_Show.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_Show.BtnImageIndex = 4;
            this.bS1_Show.BtnImageList = this.imageList1;
            this.bS1_Show.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Show.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Show.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Show.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Show.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Show.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Show.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_Show.IsListDown = false;
            this.bS1_Show.IsOnOffClick = true;
            this.bS1_Show.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_Show.Location = new System.Drawing.Point(0, 253);
            this.bS1_Show.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Show.Name = "bS1_Show";
            this.bS1_Show.Size = new System.Drawing.Size(463, 25);
            this.bS1_Show.Speed = 3;
            this.bS1_Show.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Show.TabIndex = 2;
            this.bS1_Show.Text_Button = "";
            this.bS1_Show.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_Show_ButtonStyle1_OnclickEvent);
            // 
            // secsParaPage_11
            // 
            this.secsParaPage_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secsParaPage_11.IsAllowSpareLine = true;
            this.secsParaPage_11.Location = new System.Drawing.Point(0, 278);
            this.secsParaPage_11.Margin = new System.Windows.Forms.Padding(0);
            this.secsParaPage_11.Name = "secsParaPage_11";
            this.secsParaPage_11.Size = new System.Drawing.Size(463, 200);
            this.secsParaPage_11.TabIndex = 3;
            // 
            // Page1_UCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.tlp_Base);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Page1_UCtrl";
            this.Size = new System.Drawing.Size(463, 478);
            this.tlp_Base.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Msgs)).EndInit();
            this.cms_DGV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Base;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SECSCtrlLibs.ButtonStyle1 bS1_State;
        private SECSCtrlLibs.ButtonStyle1 bS1_Q;
        private System.Windows.Forms.ImageList imageList1;
        private SECSCtrlLibs.ButtonStyle1 bS1_Search;
        private System.Windows.Forms.ComboBox cbx_Search;
        private SECSCtrlLibs.ButtonStyle1 bS1_Add;
        private System.Windows.Forms.DataGridView dgv_Msgs;
        private SECSCtrlLibs.ButtonStyle1 bS1_Show;
        private System.Windows.Forms.ContextMenuStrip cms_DGV;
        private System.Windows.Forms.ToolStripMenuItem showAllDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cms_ShowAllMessages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cms_ShowUsed;
        private System.Windows.Forms.ToolStripMenuItem cms_ShowUnUsed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearAllDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSFTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox cms_tb_ShowStream;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox cms_tb_ShowFunction;
        private System.Windows.Forms.ToolStripMenuItem cms_ShowEnableSF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem allS0F0MessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cms_execute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem streamToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox cms_deleteS;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox cms_deleteF;
        private System.Windows.Forms.ToolStripMenuItem cms_Paste;
        private System.Windows.Forms.ToolStripMenuItem cms_DeleteRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem cms_SendPrimary;
        private System.Windows.Forms.ToolStripMenuItem cms_copyMessage;
        private SECSParaPage_1 secsParaPage_11;
    }
}
