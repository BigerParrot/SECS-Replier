namespace SECSTry
{
    partial class Controller_UC1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller_UC1));
            this.pl_base = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_server = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_base2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Mode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_ClientsNum = new System.Windows.Forms.Label();
            this.btn_Separate = new System.Windows.Forms.Button();
            this.dgv_Clients = new System.Windows.Forms.DataGridView();
            this.tp_Link = new System.Windows.Forms.TabPage();
            this.tlp_LinkTable = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Receive = new System.Windows.Forms.DataGridView();
            this.dgv_Send = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.bS1_QA = new SECSCtrlLibs.ButtonStyle1();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.bS1_Add = new SECSCtrlLibs.ButtonStyle1();
            this.cbx_Receive = new System.Windows.Forms.ComboBox();
            this.cbx_Send = new System.Windows.Forms.ComboBox();
            this.pl_base.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tp_server.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlp_base2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Clients)).BeginInit();
            this.tp_Link.SuspendLayout();
            this.tlp_LinkTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Receive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Send)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_base
            // 
            this.pl_base.Controls.Add(this.tabControl1);
            this.pl_base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_base.Location = new System.Drawing.Point(0, 0);
            this.pl_base.Margin = new System.Windows.Forms.Padding(0);
            this.pl_base.Name = "pl_base";
            this.pl_base.Size = new System.Drawing.Size(438, 405);
            this.pl_base.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_server);
            this.tabControl1.Controls.Add(this.tp_Link);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 405);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tp_server
            // 
            this.tp_server.Controls.Add(this.tableLayoutPanel3);
            this.tp_server.Location = new System.Drawing.Point(4, 25);
            this.tp_server.Margin = new System.Windows.Forms.Padding(0);
            this.tp_server.Name = "tp_server";
            this.tp_server.Size = new System.Drawing.Size(430, 376);
            this.tp_server.TabIndex = 0;
            this.tp_server.Text = "Server Table";
            this.tp_server.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tlp_base2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgv_Clients, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(430, 376);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tlp_base2
            // 
            this.tlp_base2.ColumnCount = 4;
            this.tlp_base2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlp_base2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_base2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_base2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_base2.Controls.Add(this.lb_Mode, 0, 0);
            this.tlp_base2.Controls.Add(this.label4, 1, 0);
            this.tlp_base2.Controls.Add(this.lb_ClientsNum, 2, 0);
            this.tlp_base2.Controls.Add(this.btn_Separate, 3, 0);
            this.tlp_base2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_base2.Location = new System.Drawing.Point(0, 0);
            this.tlp_base2.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_base2.Name = "tlp_base2";
            this.tlp_base2.RowCount = 1;
            this.tlp_base2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_base2.Size = new System.Drawing.Size(430, 25);
            this.tlp_base2.TabIndex = 0;
            // 
            // lb_Mode
            // 
            this.lb_Mode.AutoSize = true;
            this.lb_Mode.BackColor = System.Drawing.Color.Black;
            this.lb_Mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Mode.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_Mode.ForeColor = System.Drawing.Color.White;
            this.lb_Mode.Location = new System.Drawing.Point(0, 0);
            this.lb_Mode.Margin = new System.Windows.Forms.Padding(0);
            this.lb_Mode.Name = "lb_Mode";
            this.lb_Mode.Size = new System.Drawing.Size(75, 25);
            this.lb_Mode.TabIndex = 0;
            this.lb_Mode.Text = "First";
            this.lb_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(75, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Clients:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_ClientsNum
            // 
            this.lb_ClientsNum.AutoSize = true;
            this.lb_ClientsNum.BackColor = System.Drawing.Color.White;
            this.lb_ClientsNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_ClientsNum.Location = new System.Drawing.Point(125, 0);
            this.lb_ClientsNum.Margin = new System.Windows.Forms.Padding(0);
            this.lb_ClientsNum.Name = "lb_ClientsNum";
            this.lb_ClientsNum.Size = new System.Drawing.Size(25, 25);
            this.lb_ClientsNum.TabIndex = 2;
            this.lb_ClientsNum.Text = "0";
            this.lb_ClientsNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Separate
            // 
            this.btn_Separate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Separate.Location = new System.Drawing.Point(150, 0);
            this.btn_Separate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Separate.Name = "btn_Separate";
            this.btn_Separate.Size = new System.Drawing.Size(280, 25);
            this.btn_Separate.TabIndex = 3;
            this.btn_Separate.Text = "Separate All";
            this.btn_Separate.UseVisualStyleBackColor = true;
            // 
            // dgv_Clients
            // 
            this.dgv_Clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Clients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Clients.Location = new System.Drawing.Point(0, 25);
            this.dgv_Clients.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Clients.Name = "dgv_Clients";
            this.dgv_Clients.RowHeadersVisible = false;
            this.dgv_Clients.RowTemplate.Height = 27;
            this.dgv_Clients.Size = new System.Drawing.Size(430, 351);
            this.dgv_Clients.TabIndex = 1;
            // 
            // tp_Link
            // 
            this.tp_Link.BackColor = System.Drawing.Color.Gainsboro;
            this.tp_Link.Controls.Add(this.tlp_LinkTable);
            this.tp_Link.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tp_Link.Location = new System.Drawing.Point(4, 25);
            this.tp_Link.Margin = new System.Windows.Forms.Padding(0);
            this.tp_Link.Name = "tp_Link";
            this.tp_Link.Size = new System.Drawing.Size(430, 376);
            this.tp_Link.TabIndex = 1;
            this.tp_Link.Text = "Link Table";
            // 
            // tlp_LinkTable
            // 
            this.tlp_LinkTable.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_LinkTable.ColumnCount = 2;
            this.tlp_LinkTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_LinkTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_LinkTable.Controls.Add(this.dgv_Receive, 0, 2);
            this.tlp_LinkTable.Controls.Add(this.dgv_Send, 1, 2);
            this.tlp_LinkTable.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlp_LinkTable.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tlp_LinkTable.Controls.Add(this.cbx_Receive, 0, 1);
            this.tlp_LinkTable.Controls.Add(this.cbx_Send, 1, 1);
            this.tlp_LinkTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_LinkTable.Location = new System.Drawing.Point(0, 0);
            this.tlp_LinkTable.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_LinkTable.Name = "tlp_LinkTable";
            this.tlp_LinkTable.RowCount = 3;
            this.tlp_LinkTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_LinkTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_LinkTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_LinkTable.Size = new System.Drawing.Size(430, 376);
            this.tlp_LinkTable.TabIndex = 0;
            // 
            // dgv_Receive
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Receive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Receive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Receive.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Receive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Receive.Location = new System.Drawing.Point(0, 50);
            this.dgv_Receive.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Receive.Name = "dgv_Receive";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Receive.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Receive.RowHeadersVisible = false;
            this.dgv_Receive.RowTemplate.Height = 27;
            this.dgv_Receive.Size = new System.Drawing.Size(215, 326);
            this.dgv_Receive.TabIndex = 0;
            this.dgv_Receive.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Receive_CellContentClick);
            this.dgv_Receive.MouseEnter += new System.EventHandler(this.dgv_Receive_MouseEnter);
            // 
            // dgv_Send
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Send.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Send.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Send.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Send.Location = new System.Drawing.Point(215, 50);
            this.dgv_Send.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Send.Name = "dgv_Send";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Send.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Send.RowHeadersVisible = false;
            this.dgv_Send.RowTemplate.Height = 27;
            this.dgv_Send.Size = new System.Drawing.Size(215, 326);
            this.dgv_Send.TabIndex = 1;
            this.dgv_Send.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Send_CellContentClick);
            this.dgv_Send.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bS1_QA, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(215, 25);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receive";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bS1_QA
            // 
            this.bS1_QA.BackColor = System.Drawing.Color.White;
            this.bS1_QA.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_QA.BtnImageIndex = 0;
            this.bS1_QA.BtnImageList = this.imageList1;
            this.bS1_QA.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_QA.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_QA.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_QA.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_QA.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_QA.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_QA.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_QA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_QA.IsListDown = false;
            this.bS1_QA.IsOnOffClick = true;
            this.bS1_QA.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_QA.Location = new System.Drawing.Point(190, 0);
            this.bS1_QA.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_QA.Name = "bS1_QA";
            this.bS1_QA.Size = new System.Drawing.Size(25, 25);
            this.bS1_QA.Speed = 3;
            this.bS1_QA.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_QA.TabIndex = 1;
            this.bS1_QA.Text_Button = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "9025906_question_icon.png");
            this.imageList1.Images.SetKeyName(1, "4879897_add_new_plus_icon.png");
            this.imageList1.Images.SetKeyName(2, "5402370_bin_delete_remove_trash_can_icon.png");
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bS1_Add, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(215, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(215, 25);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Send";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bS1_Add
            // 
            this.bS1_Add.BackColor = System.Drawing.Color.White;
            this.bS1_Add.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_Add.BtnImageIndex = 1;
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
            this.bS1_Add.Location = new System.Drawing.Point(190, 0);
            this.bS1_Add.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Add.Name = "bS1_Add";
            this.bS1_Add.Size = new System.Drawing.Size(25, 25);
            this.bS1_Add.Speed = 3;
            this.bS1_Add.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Add.TabIndex = 1;
            this.bS1_Add.Text_Button = "";
            this.bS1_Add.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_Add_ButtonStyle1_OnclickEvent);
            // 
            // cbx_Receive
            // 
            this.cbx_Receive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_Receive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Receive.FormattingEnabled = true;
            this.cbx_Receive.Location = new System.Drawing.Point(0, 25);
            this.cbx_Receive.Margin = new System.Windows.Forms.Padding(0);
            this.cbx_Receive.Name = "cbx_Receive";
            this.cbx_Receive.Size = new System.Drawing.Size(215, 23);
            this.cbx_Receive.TabIndex = 4;
            this.cbx_Receive.SelectedIndexChanged += new System.EventHandler(this.cbx_Receive_SelectedIndexChanged);
            // 
            // cbx_Send
            // 
            this.cbx_Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_Send.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Send.FormattingEnabled = true;
            this.cbx_Send.Location = new System.Drawing.Point(215, 25);
            this.cbx_Send.Margin = new System.Windows.Forms.Padding(0);
            this.cbx_Send.Name = "cbx_Send";
            this.cbx_Send.Size = new System.Drawing.Size(215, 23);
            this.cbx_Send.TabIndex = 5;
            // 
            // Controller_UC1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pl_base);
            this.Name = "Controller_UC1";
            this.Size = new System.Drawing.Size(438, 405);
            this.pl_base.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tp_server.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tlp_base2.ResumeLayout(false);
            this.tlp_base2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Clients)).EndInit();
            this.tp_Link.ResumeLayout(false);
            this.tlp_LinkTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Receive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Send)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_base;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_server;
        private System.Windows.Forms.TabPage tp_Link;
        private System.Windows.Forms.TableLayoutPanel tlp_LinkTable;
        private System.Windows.Forms.DataGridView dgv_Receive;
        private System.Windows.Forms.DataGridView dgv_Send;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private SECSCtrlLibs.ButtonStyle1 bS1_QA;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private SECSCtrlLibs.ButtonStyle1 bS1_Add;
        private System.Windows.Forms.ComboBox cbx_Receive;
        private System.Windows.Forms.ComboBox cbx_Send;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tlp_base2;
        private System.Windows.Forms.Label lb_Mode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_ClientsNum;
        private System.Windows.Forms.Button btn_Separate;
        private System.Windows.Forms.DataGridView dgv_Clients;
    }
}
