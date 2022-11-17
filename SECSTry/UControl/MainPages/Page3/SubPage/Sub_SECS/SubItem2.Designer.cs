namespace SECSTry
{
    partial class SubItem2
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
            this.tlp_base = new System.Windows.Forms.TableLayoutPanel();
            this.rbtn_SECSI = new System.Windows.Forms.RadioButton();
            this.rbtn_HSMS = new System.Windows.Forms.RadioButton();
            this.tlp_base.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_base
            // 
            this.tlp_base.ColumnCount = 3;
            this.tlp_base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlp_base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_base.Controls.Add(this.rbtn_SECSI, 1, 1);
            this.tlp_base.Controls.Add(this.rbtn_HSMS, 1, 2);
            this.tlp_base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_base.Location = new System.Drawing.Point(0, 0);
            this.tlp_base.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_base.Name = "tlp_base";
            this.tlp_base.RowCount = 4;
            this.tlp_base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_base.Size = new System.Drawing.Size(75, 69);
            this.tlp_base.TabIndex = 0;
            // 
            // rbtn_SECSI
            // 
            this.rbtn_SECSI.AutoSize = true;
            this.rbtn_SECSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtn_SECSI.Font = new System.Drawing.Font("新細明體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtn_SECSI.Location = new System.Drawing.Point(3, 12);
            this.rbtn_SECSI.Name = "rbtn_SECSI";
            this.rbtn_SECSI.Size = new System.Drawing.Size(69, 19);
            this.rbtn_SECSI.TabIndex = 0;
            this.rbtn_SECSI.Text = "SECS I";
            this.rbtn_SECSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtn_SECSI.UseVisualStyleBackColor = true;
            this.rbtn_SECSI.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtn_HSMS
            // 
            this.rbtn_HSMS.AutoSize = true;
            this.rbtn_HSMS.Checked = true;
            this.rbtn_HSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbtn_HSMS.Font = new System.Drawing.Font("新細明體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtn_HSMS.Location = new System.Drawing.Point(3, 37);
            this.rbtn_HSMS.Name = "rbtn_HSMS";
            this.rbtn_HSMS.Size = new System.Drawing.Size(69, 19);
            this.rbtn_HSMS.TabIndex = 1;
            this.rbtn_HSMS.TabStop = true;
            this.rbtn_HSMS.Text = "HSMS";
            this.rbtn_HSMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtn_HSMS.UseVisualStyleBackColor = true;
            this.rbtn_HSMS.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // SubItem2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_base);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SubItem2";
            this.Size = new System.Drawing.Size(75, 69);
            this.tlp_base.ResumeLayout(false);
            this.tlp_base.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_base;
        private System.Windows.Forms.RadioButton rbtn_SECSI;
        private System.Windows.Forms.RadioButton rbtn_HSMS;
    }
}
