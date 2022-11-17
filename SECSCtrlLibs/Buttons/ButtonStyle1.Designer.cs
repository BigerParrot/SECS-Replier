namespace SECSCtrlLibs
{
    partial class ButtonStyle1
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
            this.buttonBase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBase
            // 
            this.buttonBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBase.Location = new System.Drawing.Point(0, 0);
            this.buttonBase.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBase.Name = "buttonBase";
            this.buttonBase.Size = new System.Drawing.Size(338, 120);
            this.buttonBase.TabIndex = 0;
            this.buttonBase.UseVisualStyleBackColor = true;
            // 
            // ButtonStyle1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonBase);
            this.Name = "ButtonStyle1";
            this.Size = new System.Drawing.Size(338, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBase;
    }
}
