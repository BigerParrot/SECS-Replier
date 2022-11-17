namespace SECSTry
{
    partial class IntValueSet_UCtrl
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
            this.tlp_Base = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbx_Value = new System.Windows.Forms.TextBox();
            this.tlp_Base.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Base
            // 
            this.tlp_Base.ColumnCount = 3;
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Controls.Add(this.label1, 0, 0);
            this.tlp_Base.Controls.Add(this.panel1, 1, 0);
            this.tlp_Base.Controls.Add(this.tbx_Value, 2, 0);
            this.tlp_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Base.Location = new System.Drawing.Point(0, 0);
            this.tlp_Base.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Base.Name = "tlp_Base";
            this.tlp_Base.RowCount = 1;
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Size = new System.Drawing.Size(313, 25);
            this.tlp_Base.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Int Value";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(100, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 25);
            this.panel1.TabIndex = 1;
            // 
            // tbx_Value
            // 
            this.tbx_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Value.Location = new System.Drawing.Point(102, 0);
            this.tbx_Value.Margin = new System.Windows.Forms.Padding(0);
            this.tbx_Value.Name = "tbx_Value";
            this.tbx_Value.Size = new System.Drawing.Size(211, 25);
            this.tbx_Value.TabIndex = 2;
            this.tbx_Value.TextChanged += new System.EventHandler(this.tbx_Value_TextChanged);
            this.tbx_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Value_KeyPress);
            // 
            // IntValueSet_UCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Base);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(0, 25);
            this.MinimumSize = new System.Drawing.Size(0, 25);
            this.Name = "IntValueSet_UCtrl";
            this.Size = new System.Drawing.Size(313, 25);
            this.tlp_Base.ResumeLayout(false);
            this.tlp_Base.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Base;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbx_Value;
    }
}
