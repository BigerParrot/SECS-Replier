namespace SECSTry
{
    partial class ValueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValueForm));
            this.tlp_base = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Type = new System.Windows.Forms.ComboBox();
            this.lb_Checked = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bS1_Save = new SECSCtrlLibs.ButtonStyle1();
            this.bS1_Leave = new SECSCtrlLibs.ButtonStyle1();
            this.pl_base = new System.Windows.Forms.Panel();
            this.tlp_base.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_base
            // 
            this.tlp_base.ColumnCount = 1;
            this.tlp_base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_base.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlp_base.Controls.Add(this.pl_base, 0, 1);
            this.tlp_base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_base.Location = new System.Drawing.Point(0, 0);
            this.tlp_base.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_base.Name = "tlp_base";
            this.tlp_base.RowCount = 2;
            this.tlp_base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_base.Size = new System.Drawing.Size(336, 186);
            this.tlp_base.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbx_Type, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_Checked, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.bS1_Save, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.bS1_Leave, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbx_Type
            // 
            this.cbx_Type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Type.FormattingEnabled = true;
            this.cbx_Type.Location = new System.Drawing.Point(50, 0);
            this.cbx_Type.Margin = new System.Windows.Forms.Padding(0);
            this.cbx_Type.Name = "cbx_Type";
            this.cbx_Type.Size = new System.Drawing.Size(50, 23);
            this.cbx_Type.TabIndex = 1;
            this.cbx_Type.SelectedIndexChanged += new System.EventHandler(this.cbx_Type_SelectedIndexChanged);
            // 
            // lb_Checked
            // 
            this.lb_Checked.AutoSize = true;
            this.lb_Checked.BackColor = System.Drawing.Color.Red;
            this.lb_Checked.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_Checked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Checked.ImageIndex = 1;
            this.lb_Checked.ImageList = this.imageList1;
            this.lb_Checked.Location = new System.Drawing.Point(161, 0);
            this.lb_Checked.Margin = new System.Windows.Forms.Padding(0);
            this.lb_Checked.Name = "lb_Checked";
            this.lb_Checked.Size = new System.Drawing.Size(25, 25);
            this.lb_Checked.TabIndex = 2;
            this.lb_Checked.Tag = "0";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1564499_accept_added_check_complite_yes_icon.png");
            this.imageList1.Images.SetKeyName(1, "1564505_close_delete_exit_remove_icon.png");
            // 
            // bS1_Save
            // 
            this.bS1_Save.BackColor = System.Drawing.Color.White;
            this.bS1_Save.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_Save.BtnImageIndex = -1;
            this.bS1_Save.BtnImageList = null;
            this.bS1_Save.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Save.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Save.ButtonNoneColor_KnownColor = System.Drawing.Color.GreenYellow;
            this.bS1_Save.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Save.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Save.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Save.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_Save.IsListDown = false;
            this.bS1_Save.IsOnOffClick = true;
            this.bS1_Save.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_Save.Location = new System.Drawing.Point(186, 0);
            this.bS1_Save.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Save.Name = "bS1_Save";
            this.bS1_Save.Size = new System.Drawing.Size(75, 25);
            this.bS1_Save.Speed = 3;
            this.bS1_Save.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Save.TabIndex = 3;
            this.bS1_Save.Text_Button = "Save";
            this.bS1_Save.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_Save_ButtonStyle1_OnclickEvent);
            // 
            // bS1_Leave
            // 
            this.bS1_Leave.BackColor = System.Drawing.Color.White;
            this.bS1_Leave.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_Leave.BtnImageIndex = -1;
            this.bS1_Leave.BtnImageList = null;
            this.bS1_Leave.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Leave.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Leave.ButtonNoneColor_KnownColor = System.Drawing.Color.Red;
            this.bS1_Leave.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Leave.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Leave.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Leave.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Leave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_Leave.IsListDown = false;
            this.bS1_Leave.IsOnOffClick = true;
            this.bS1_Leave.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_Leave.Location = new System.Drawing.Point(261, 0);
            this.bS1_Leave.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Leave.Name = "bS1_Leave";
            this.bS1_Leave.Size = new System.Drawing.Size(75, 25);
            this.bS1_Leave.Speed = 3;
            this.bS1_Leave.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Leave.TabIndex = 4;
            this.bS1_Leave.Text_Button = "Leave";
            this.bS1_Leave.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_Leave_ButtonStyle1_OnclickEvent);
            // 
            // pl_base
            // 
            this.pl_base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_base.Location = new System.Drawing.Point(0, 25);
            this.pl_base.Margin = new System.Windows.Forms.Padding(0);
            this.pl_base.Name = "pl_base";
            this.pl_base.Size = new System.Drawing.Size(336, 161);
            this.pl_base.TabIndex = 1;
            // 
            // ValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 186);
            this.ControlBox = false;
            this.Controls.Add(this.tlp_base);
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "ValueForm";
            this.Text = "ValueForm";
            this.tlp_base.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_base;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Type;
        private System.Windows.Forms.Label lb_Checked;
        private System.Windows.Forms.ImageList imageList1;
        private SECSCtrlLibs.ButtonStyle1 bS1_Save;
        private SECSCtrlLibs.ButtonStyle1 bS1_Leave;
        private System.Windows.Forms.Panel pl_base;
    }
}