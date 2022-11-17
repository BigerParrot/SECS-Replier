namespace SECSTry
{
    partial class Loggers_Ctrl2
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
            this.tab_Base = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtb_MsgBase = new System.Windows.Forms.RichTextBox();
            this.ctms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unselectItem_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cms_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtb_Msg = new System.Windows.Forms.RichTextBox();
            this.tab_Base.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ctms1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_Base
            // 
            this.tab_Base.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tab_Base.Controls.Add(this.tabPage1);
            this.tab_Base.Controls.Add(this.tabPage2);
            this.tab_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Base.Location = new System.Drawing.Point(0, 0);
            this.tab_Base.Margin = new System.Windows.Forms.Padding(0);
            this.tab_Base.Name = "tab_Base";
            this.tab_Base.SelectedIndex = 0;
            this.tab_Base.Size = new System.Drawing.Size(260, 303);
            this.tab_Base.TabIndex = 0;
            this.tab_Base.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_Base_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtb_MsgBase);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(252, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Message Base Logger";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtb_MsgBase
            // 
            this.rtb_MsgBase.ContextMenuStrip = this.ctms1;
            this.rtb_MsgBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_MsgBase.Location = new System.Drawing.Point(0, 0);
            this.rtb_MsgBase.Margin = new System.Windows.Forms.Padding(0);
            this.rtb_MsgBase.Name = "rtb_MsgBase";
            this.rtb_MsgBase.ReadOnly = true;
            this.rtb_MsgBase.Size = new System.Drawing.Size(252, 274);
            this.rtb_MsgBase.TabIndex = 0;
            this.rtb_MsgBase.Text = "";
            // 
            // ctms1
            // 
            this.ctms1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unselectItem_btn,
            this.toolStripSeparator2,
            this.cms_Copy});
            this.ctms1.Name = "ctms1";
            this.ctms1.Size = new System.Drawing.Size(176, 86);
            this.ctms1.Opening += new System.ComponentModel.CancelEventHandler(this.ctms1_Opening);
            // 
            // unselectItem_btn
            // 
            this.unselectItem_btn.Name = "unselectItem_btn";
            this.unselectItem_btn.Size = new System.Drawing.Size(175, 24);
            this.unselectItem_btn.Text = "Unselect Item";
            this.unselectItem_btn.Click += new System.EventHandler(this.unselectItem_btn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // cms_Copy
            // 
            this.cms_Copy.Name = "cms_Copy";
            this.cms_Copy.Size = new System.Drawing.Size(175, 24);
            this.cms_Copy.Text = "Copy Message";
            this.cms_Copy.Click += new System.EventHandler(this.copyMessageToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtb_Msg);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(252, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Message Logger";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtb_Msg
            // 
            this.rtb_Msg.ContextMenuStrip = this.ctms1;
            this.rtb_Msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Msg.Location = new System.Drawing.Point(0, 0);
            this.rtb_Msg.Margin = new System.Windows.Forms.Padding(0);
            this.rtb_Msg.Name = "rtb_Msg";
            this.rtb_Msg.ReadOnly = true;
            this.rtb_Msg.Size = new System.Drawing.Size(252, 274);
            this.rtb_Msg.TabIndex = 0;
            this.rtb_Msg.Text = "";
            // 
            // Loggers_Ctrl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tab_Base);
            this.Name = "Loggers_Ctrl2";
            this.Size = new System.Drawing.Size(260, 303);
            this.tab_Base.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ctms1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Base;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtb_MsgBase;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtb_Msg;
        private System.Windows.Forms.ContextMenuStrip ctms1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem unselectItem_btn;
        private System.Windows.Forms.ToolStripMenuItem cms_Copy;
    }
}
