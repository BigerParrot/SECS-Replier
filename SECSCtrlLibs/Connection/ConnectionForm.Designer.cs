namespace SECSCtrlLibs
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_IP = new System.Windows.Forms.ComboBox();
            this.bS_Refresh = new SECSCtrlLibs.ButtonStyle1();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bS_Connect = new SECSCtrlLibs.ButtonStyle1();
            this.bS_Leave = new SECSCtrlLibs.ButtonStyle1();
            this.bS_Question = new SECSCtrlLibs.ButtonStyle1();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 157);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbx_IP, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.bS_Refresh, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(346, 25);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbx_IP
            // 
            this.cbx_IP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_IP.FormattingEnabled = true;
            this.cbx_IP.Location = new System.Drawing.Point(75, 0);
            this.cbx_IP.Margin = new System.Windows.Forms.Padding(0);
            this.cbx_IP.Name = "cbx_IP";
            this.cbx_IP.Size = new System.Drawing.Size(246, 23);
            this.cbx_IP.TabIndex = 1;
            this.cbx_IP.DropDown += new System.EventHandler(this.cbx_IP_DropDown);
            this.cbx_IP.TextChanged += new System.EventHandler(this.cbx_IP_TextChanged);
            // 
            // bS_Refresh
            // 
            this.bS_Refresh.BackColor = System.Drawing.Color.White;
            this.bS_Refresh.BtnImageIndex = 0;
            this.bS_Refresh.BtnImageList = this.imageList1;
            this.bS_Refresh.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Refresh.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Refresh.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Refresh.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Refresh.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Refresh.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Refresh.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Refresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS_Refresh.IsListDown = false;
            this.bS_Refresh.IsOnOffClick = true;
            this.bS_Refresh.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS_Refresh.Location = new System.Drawing.Point(321, 0);
            this.bS_Refresh.Margin = new System.Windows.Forms.Padding(0);
            this.bS_Refresh.Name = "bS_Refresh";
            this.bS_Refresh.Size = new System.Drawing.Size(25, 25);
            this.bS_Refresh.Speed = 3;
            this.bS_Refresh.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS_Refresh.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS_Refresh.TabIndex = 2;
            this.bS_Refresh.Text_Button = "";
            this.bS_Refresh.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS_Refresh_ButtonStyle1_OnclickEvent);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "6428070_arrow_recycle_refresh_reload_return_icon.png");
            this.imageList1.Images.SetKeyName(1, "9025906_question_icon.png");
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tb_Port, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tb_Name, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(20, 65);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(346, 25);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(176, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "NickName";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Port
            // 
            this.tb_Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Port.Location = new System.Drawing.Point(75, 0);
            this.tb_Port.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(98, 25);
            this.tb_Port.TabIndex = 2;
            this.tb_Port.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.tb_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Port_KeyPress);
            // 
            // tb_Name
            // 
            this.tb_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Name.Location = new System.Drawing.Point(248, 0);
            this.tb_Name.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(98, 25);
            this.tb_Name.TabIndex = 3;
            this.tb_Name.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Controls.Add(this.bS_Connect, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.bS_Leave, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.bS_Question, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(20, 90);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(346, 67);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // bS_Connect
            // 
            this.bS_Connect.BackColor = System.Drawing.Color.White;
            this.bS_Connect.BtnImageIndex = -1;
            this.bS_Connect.BtnImageList = null;
            this.bS_Connect.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Connect.ButtonLockedColor_KnownColor = System.Drawing.Color.Honeydew;
            this.bS_Connect.ButtonNoneColor_KnownColor = System.Drawing.Color.GreenYellow;
            this.bS_Connect.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Connect.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Connect.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Connect.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS_Connect.IsListDown = false;
            this.bS_Connect.IsOnOffClick = true;
            this.bS_Connect.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS_Connect.Location = new System.Drawing.Point(30, 20);
            this.bS_Connect.Margin = new System.Windows.Forms.Padding(0);
            this.bS_Connect.Name = "bS_Connect";
            this.bS_Connect.Size = new System.Drawing.Size(118, 27);
            this.bS_Connect.Speed = 3;
            this.bS_Connect.bS_Style = SECSCtrlLibs.EButtonStyle1.locked;
            this.bS_Connect.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS_Connect.TabIndex = 0;
            this.bS_Connect.Text_Button = "Connect";
            this.bS_Connect.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS_Connect_ButtonStyle1_OnclickEvent);
            // 
            // bS_Leave
            // 
            this.bS_Leave.BackColor = System.Drawing.Color.White;
            this.bS_Leave.BtnImageIndex = -1;
            this.bS_Leave.BtnImageList = null;
            this.bS_Leave.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Leave.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Leave.ButtonNoneColor_KnownColor = System.Drawing.Color.Red;
            this.bS_Leave.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Leave.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Leave.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Leave.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Leave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS_Leave.IsListDown = false;
            this.bS_Leave.IsOnOffClick = true;
            this.bS_Leave.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS_Leave.Location = new System.Drawing.Point(198, 20);
            this.bS_Leave.Margin = new System.Windows.Forms.Padding(0);
            this.bS_Leave.Name = "bS_Leave";
            this.bS_Leave.Size = new System.Drawing.Size(118, 27);
            this.bS_Leave.Speed = 3;
            this.bS_Leave.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS_Leave.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS_Leave.TabIndex = 1;
            this.bS_Leave.Text_Button = "Leave";
            this.bS_Leave.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS_Leave_ButtonStyle1_OnclickEvent);
            // 
            // bS_Question
            // 
            this.bS_Question.BackColor = System.Drawing.Color.White;
            this.bS_Question.BtnImageIndex = 1;
            this.bS_Question.BtnImageList = this.imageList1;
            this.bS_Question.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Question.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Question.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Question.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Question.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Question.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_Question.ButtonWarnningColor2_KnownColor = System.Drawing.Color.Red;
            this.bS_Question.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS_Question.IsListDown = false;
            this.bS_Question.IsOnOffClick = true;
            this.bS_Question.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS_Question.Location = new System.Drawing.Point(0, 20);
            this.bS_Question.Margin = new System.Windows.Forms.Padding(0);
            this.bS_Question.Name = "bS_Question";
            this.bS_Question.Size = new System.Drawing.Size(30, 27);
            this.bS_Question.Speed = 3;
            this.bS_Question.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS_Question.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS_Question.TabIndex = 2;
            this.bS_Question.Text_Button = "";
            this.bS_Question.Visible = false;
            this.bS_Question.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS_Question_ButtonStyle1_OnclickEvent);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 157);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "ConnectionForm";
            this.Text = "Connection";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_IP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ButtonStyle1 bS_Connect;
        private ButtonStyle1 bS_Leave;
        private ButtonStyle1 bS_Refresh;
        private System.Windows.Forms.ImageList imageList1;
        private ButtonStyle1 bS_Question;
    }
}