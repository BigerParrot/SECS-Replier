namespace SECSTry
{
    partial class Loggers_Ctrl1
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
            this.tlp_Base = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Tittle = new System.Windows.Forms.Label();
            this.cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s0F0Show_check = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.send_check = new System.Windows.Forms.ToolStripMenuItem();
            this.receive_check = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.unselectItem_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.timeout_check = new System.Windows.Forms.ToolStripMenuItem();
            this.tlp_Base.SuspendLayout();
            this.cms1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Base
            // 
            this.tlp_Base.ColumnCount = 1;
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Controls.Add(this.lb_Tittle, 0, 0);
            this.tlp_Base.Controls.Add(this.dgv1, 0, 1);
            this.tlp_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Base.Location = new System.Drawing.Point(0, 0);
            this.tlp_Base.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Base.Name = "tlp_Base";
            this.tlp_Base.RowCount = 2;
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Size = new System.Drawing.Size(100, 437);
            this.tlp_Base.TabIndex = 0;
            this.tlp_Base.Paint += new System.Windows.Forms.PaintEventHandler(this.tlp_Base_Paint);
            // 
            // lb_Tittle
            // 
            this.lb_Tittle.AutoSize = true;
            this.lb_Tittle.BackColor = System.Drawing.Color.Silver;
            this.lb_Tittle.ContextMenuStrip = this.cms1;
            this.lb_Tittle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Tittle.Location = new System.Drawing.Point(3, 0);
            this.lb_Tittle.Name = "lb_Tittle";
            this.lb_Tittle.Size = new System.Drawing.Size(94, 25);
            this.lb_Tittle.TabIndex = 0;
            this.lb_Tittle.Text = "Type Log";
            this.lb_Tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cms1
            // 
            this.cms1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripSeparator1,
            this.unselectItem_btn});
            this.cms1.Name = "cms1";
            this.cms1.Size = new System.Drawing.Size(169, 58);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s0F0Show_check,
            this.toolStripSeparator2,
            this.send_check,
            this.receive_check,
            this.toolStripSeparator3,
            this.timeout_check});
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // s0F0Show_check
            // 
            this.s0F0Show_check.Checked = true;
            this.s0F0Show_check.CheckOnClick = true;
            this.s0F0Show_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.s0F0Show_check.Name = "s0F0Show_check";
            this.s0F0Show_check.Size = new System.Drawing.Size(175, 26);
            this.s0F0Show_check.Text = "S0F0 message";
            this.s0F0Show_check.CheckedChanged += new System.EventHandler(this.s0F0Show_check_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // send_check
            // 
            this.send_check.Checked = true;
            this.send_check.CheckOnClick = true;
            this.send_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.send_check.Name = "send_check";
            this.send_check.Size = new System.Drawing.Size(175, 26);
            this.send_check.Text = "Send";
            this.send_check.CheckedChanged += new System.EventHandler(this.send_check_CheckedChanged);
            // 
            // receive_check
            // 
            this.receive_check.Checked = true;
            this.receive_check.CheckOnClick = true;
            this.receive_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.receive_check.Name = "receive_check";
            this.receive_check.Size = new System.Drawing.Size(175, 26);
            this.receive_check.Text = "Receive";
            this.receive_check.CheckedChanged += new System.EventHandler(this.receive_check_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // unselectItem_btn
            // 
            this.unselectItem_btn.Name = "unselectItem_btn";
            this.unselectItem_btn.Size = new System.Drawing.Size(168, 24);
            this.unselectItem_btn.Text = "Unselect Item";
            this.unselectItem_btn.Click += new System.EventHandler(this.unselectItem_btn_Click);
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.ContextMenuStrip = this.cms1;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(0, 25);
            this.dgv1.Margin = new System.Windows.Forms.Padding(0);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.Size = new System.Drawing.Size(100, 412);
            this.dgv1.TabIndex = 1;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(172, 6);
            // 
            // timeout_check
            // 
            this.timeout_check.Checked = true;
            this.timeout_check.CheckOnClick = true;
            this.timeout_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.timeout_check.Name = "timeout_check";
            this.timeout_check.Size = new System.Drawing.Size(175, 26);
            this.timeout_check.Text = "Timeout";
            this.timeout_check.CheckedChanged += new System.EventHandler(this.timeout_check_CheckedChanged);
            // 
            // Loggers_Ctrl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Base);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Loggers_Ctrl1";
            this.Size = new System.Drawing.Size(100, 437);
            this.tlp_Base.ResumeLayout(false);
            this.tlp_Base.PerformLayout();
            this.cms1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Base;
        private System.Windows.Forms.Label lb_Tittle;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ContextMenuStrip cms1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s0F0Show_check;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem unselectItem_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem send_check;
        private System.Windows.Forms.ToolStripMenuItem receive_check;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem timeout_check;
    }
}
