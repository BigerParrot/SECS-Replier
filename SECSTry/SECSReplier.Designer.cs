namespace SECSTry
{
    partial class SECSReplier
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
            this.tlp_Base = new System.Windows.Forms.TableLayoutPanel();
            this.tittle1 = new SECSTry.UControl.Tittle();
            this.pl_Main = new System.Windows.Forms.Panel();
            this.tabs1 = new SECSTry.UControl.MainPages.Tabs();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_msg2 = new System.Windows.Forms.TextBox();
            this.lb_MsgState = new System.Windows.Forms.Label();
            this.tb_msg1 = new System.Windows.Forms.TextBox();
            this.tlp_Base.SuspendLayout();
            this.pl_Main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Base
            // 
            this.tlp_Base.ColumnCount = 1;
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Controls.Add(this.tittle1, 0, 0);
            this.tlp_Base.Controls.Add(this.pl_Main, 0, 1);
            this.tlp_Base.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tlp_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Base.Location = new System.Drawing.Point(0, 0);
            this.tlp_Base.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Base.Name = "tlp_Base";
            this.tlp_Base.RowCount = 3;
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Base.Size = new System.Drawing.Size(987, 756);
            this.tlp_Base.TabIndex = 0;
            // 
            // tittle1
            // 
            this.tittle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tittle1.Location = new System.Drawing.Point(0, 0);
            this.tittle1.Margin = new System.Windows.Forms.Padding(0);
            this.tittle1.Name = "tittle1";
            this.tittle1.Size = new System.Drawing.Size(987, 25);
            this.tittle1.TabIndex = 0;
            this.tittle1.DoConnectTryEvent += new System.EventHandler(this.tittle1_DoConnectTryEvent);
            this.tittle1.DoOfflineEvent += new System.EventHandler(this._DoOfflineEvent);
            // 
            // pl_Main
            // 
            this.pl_Main.BackColor = System.Drawing.SystemColors.Control;
            this.pl_Main.Controls.Add(this.tabs1);
            this.pl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_Main.Location = new System.Drawing.Point(0, 25);
            this.pl_Main.Margin = new System.Windows.Forms.Padding(0);
            this.pl_Main.Name = "pl_Main";
            this.pl_Main.Size = new System.Drawing.Size(987, 706);
            this.pl_Main.TabIndex = 1;
            // 
            // tabs1
            // 
            this.tabs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs1.Location = new System.Drawing.Point(0, 0);
            this.tabs1.Margin = new System.Windows.Forms.Padding(0);
            this.tabs1.Name = "tabs1";
            this.tabs1.Size = new System.Drawing.Size(987, 706);
            this.tabs1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Controls.Add(this.tb_msg2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_MsgState, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_msg1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 731);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(987, 25);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tb_msg2
            // 
            this.tb_msg2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_msg2.Location = new System.Drawing.Point(455, 0);
            this.tb_msg2.Margin = new System.Windows.Forms.Padding(0);
            this.tb_msg2.Name = "tb_msg2";
            this.tb_msg2.ReadOnly = true;
            this.tb_msg2.Size = new System.Drawing.Size(455, 25);
            this.tb_msg2.TabIndex = 5;
            // 
            // lb_MsgState
            // 
            this.lb_MsgState.AutoSize = true;
            this.lb_MsgState.BackColor = System.Drawing.SystemColors.Control;
            this.lb_MsgState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_MsgState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_MsgState.Location = new System.Drawing.Point(910, 0);
            this.lb_MsgState.Margin = new System.Windows.Forms.Padding(0);
            this.lb_MsgState.Name = "lb_MsgState";
            this.lb_MsgState.Size = new System.Drawing.Size(77, 25);
            this.lb_MsgState.TabIndex = 0;
            this.lb_MsgState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_msg1
            // 
            this.tb_msg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_msg1.Location = new System.Drawing.Point(0, 0);
            this.tb_msg1.Margin = new System.Windows.Forms.Padding(0);
            this.tb_msg1.Name = "tb_msg1";
            this.tb_msg1.ReadOnly = true;
            this.tb_msg1.Size = new System.Drawing.Size(455, 25);
            this.tb_msg1.TabIndex = 4;
            // 
            // SECSReplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(987, 756);
            this.ControlBox = false;
            this.Controls.Add(this.tlp_Base);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1001, 799);
            this.MinimumSize = new System.Drawing.Size(1001, 799);
            this.Name = "SECSReplier";
            this.Text = "SECS Replier";
            this.Load += new System.EventHandler(this.SECSReplier_Load);
            this.tlp_Base.ResumeLayout(false);
            this.pl_Main.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Base;
        private UControl.Tittle tittle1;
        private System.Windows.Forms.Panel pl_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lb_MsgState;
        private System.Windows.Forms.TextBox tb_msg1;
        private System.Windows.Forms.TextBox tb_msg2;
        private UControl.MainPages.Tabs tabs1;
    }
}

