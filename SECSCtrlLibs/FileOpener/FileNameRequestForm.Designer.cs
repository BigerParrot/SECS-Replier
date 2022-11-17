namespace SECSCtrlLibs
{
    partial class FileNameRequestForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bS1_Enter = new SECSCtrlLibs.ButtonStyle1();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bS1_Enter, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(45, 16);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // bS1_Enter
            // 
            this.bS1_Enter.BackColor = System.Drawing.Color.White;
            this.bS1_Enter.bS_Style = SECSCtrlLibs.EButtonStyle1.Warrning;
            this.bS1_Enter.BtnImageIndex = -1;
            this.bS1_Enter.BtnImageList = null;
            this.bS1_Enter.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Enter.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Enter.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Enter.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Enter.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Enter.ButtonWarnningColor1_KnownColor = System.Drawing.Color.PaleGoldenrod;
            this.bS1_Enter.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Enter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_Enter.IsListDown = false;
            this.bS1_Enter.IsOnOffClick = true;
            this.bS1_Enter.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_Enter.Location = new System.Drawing.Point(265, 16);
            this.bS1_Enter.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Enter.Name = "bS1_Enter";
            this.bS1_Enter.Size = new System.Drawing.Size(75, 25);
            this.bS1_Enter.Speed = 1;
            this.bS1_Enter.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Enter.TabIndex = 1;
            this.bS1_Enter.Text_Button = "Enter";
            this.bS1_Enter.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_Enter_ButtonStyle1_OnclickEvent);
            // 
            // FileNameRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 57);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(400, 100);
            this.MinimumSize = new System.Drawing.Size(400, 100);
            this.Name = "FileNameRequestForm";
            this.Text = "File Name";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private ButtonStyle1 bS1_Enter;
    }
}