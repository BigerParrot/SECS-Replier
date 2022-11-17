namespace SECSCtrlLibs
{
    partial class FileOpenForm
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_path = new System.Windows.Forms.TextBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_HomePage = new System.Windows.Forms.Button();
            this.dgv_main = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Path:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbx_path
            // 
            this.tbx_path.Location = new System.Drawing.Point(115, 10);
            this.tbx_path.Name = "tbx_path";
            this.tbx_path.ReadOnly = true;
            this.tbx_path.Size = new System.Drawing.Size(269, 25);
            this.tbx_path.TabIndex = 2;
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(138, 41);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(120, 50);
            this.btn_Back.TabIndex = 4;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(264, 41);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(120, 51);
            this.btn_Select.TabIndex = 5;
            this.btn_Select.Text = "Select";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_HomePage
            // 
            this.btn_HomePage.Location = new System.Drawing.Point(12, 41);
            this.btn_HomePage.Name = "btn_HomePage";
            this.btn_HomePage.Size = new System.Drawing.Size(120, 50);
            this.btn_HomePage.TabIndex = 6;
            this.btn_HomePage.Text = "Home Page";
            this.btn_HomePage.UseVisualStyleBackColor = true;
            this.btn_HomePage.Click += new System.EventHandler(this.btn_HomePage_Click);
            // 
            // dgv_main
            // 
            this.dgv_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_main.Location = new System.Drawing.Point(12, 98);
            this.dgv_main.Name = "dgv_main";
            this.dgv_main.ReadOnly = true;
            this.dgv_main.RowHeadersVisible = false;
            this.dgv_main.RowTemplate.Height = 27;
            this.dgv_main.Size = new System.Drawing.Size(372, 297);
            this.dgv_main.TabIndex = 7;
            this.dgv_main.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_main_CellContentClick);
            // 
            // FileOpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 407);
            this.Controls.Add(this.dgv_main);
            this.Controls.Add(this.btn_HomePage);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.tbx_path);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(410, 450);
            this.MinimumSize = new System.Drawing.Size(410, 450);
            this.Name = "FileOpenForm";
            this.Text = "Open File";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_path;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_HomePage;
        private System.Windows.Forms.DataGridView dgv_main;
    }
}

