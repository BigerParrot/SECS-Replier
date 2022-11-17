namespace SECSTry.UControl.MainPages
{
    partial class Tabs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tabs));
            this.tlp_Base = new System.Windows.Forms.TableLayoutPanel();
            this.tbCtrl = new System.Windows.Forms.TabControl();
            this.tp_Datas = new System.Windows.Forms.TabPage();
            this.page1_UCtrl1 = new SECSTry.Page1_UCtrl();
            this.tp_Logs = new System.Windows.Forms.TabPage();
            this.tbCtrl_Logs = new System.Windows.Forms.TabControl();
            this.tb_Loggers = new System.Windows.Forms.TabPage();
            this.tlp_Logger = new System.Windows.Forms.TableLayoutPanel();
            this.bS_lift = new SECSCtrlLibs.ButtonStyle1();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pl_LoggerCtrl1 = new System.Windows.Forms.Panel();
            this.loggers_Ctrl11 = new SECSTry.Loggers_Ctrl1();
            this.loggers_Ctrl21 = new SECSTry.Loggers_Ctrl2();
            this.tb_Records = new System.Windows.Forms.TabPage();
            this.tb_Paras = new System.Windows.Forms.TabPage();
            this.page3_UCtrl1 = new SECSTry.Page3_UCtrl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cms_MessageLogs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pl_UC1 = new System.Windows.Forms.Panel();
            this.controller_UC11 = new SECSTry.Controller_UC1();
            this.tlp_Base.SuspendLayout();
            this.tbCtrl.SuspendLayout();
            this.tp_Datas.SuspendLayout();
            this.tp_Logs.SuspendLayout();
            this.tbCtrl_Logs.SuspendLayout();
            this.tb_Loggers.SuspendLayout();
            this.tlp_Logger.SuspendLayout();
            this.pl_LoggerCtrl1.SuspendLayout();
            this.tb_Paras.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pl_UC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Base
            // 
            this.tlp_Base.ColumnCount = 2;
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_Base.Controls.Add(this.tbCtrl, 0, 0);
            this.tlp_Base.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlp_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Base.Location = new System.Drawing.Point(0, 0);
            this.tlp_Base.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Base.Name = "tlp_Base";
            this.tlp_Base.RowCount = 1;
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Size = new System.Drawing.Size(786, 507);
            this.tlp_Base.TabIndex = 0;
            // 
            // tbCtrl
            // 
            this.tbCtrl.Controls.Add(this.tp_Datas);
            this.tbCtrl.Controls.Add(this.tp_Logs);
            this.tbCtrl.Controls.Add(this.tb_Paras);
            this.tbCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtrl.Location = new System.Drawing.Point(0, 0);
            this.tbCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.tbCtrl.Name = "tbCtrl";
            this.tbCtrl.SelectedIndex = 0;
            this.tbCtrl.Size = new System.Drawing.Size(471, 507);
            this.tbCtrl.TabIndex = 0;
            // 
            // tp_Datas
            // 
            this.tp_Datas.Controls.Add(this.page1_UCtrl1);
            this.tp_Datas.Location = new System.Drawing.Point(4, 25);
            this.tp_Datas.Name = "tp_Datas";
            this.tp_Datas.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Datas.Size = new System.Drawing.Size(463, 478);
            this.tp_Datas.TabIndex = 0;
            this.tp_Datas.Text = "Datas Configuration";
            this.tp_Datas.UseVisualStyleBackColor = true;
            // 
            // page1_UCtrl1
            // 
            this.page1_UCtrl1.BackColor = System.Drawing.Color.Gainsboro;
            this.page1_UCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page1_UCtrl1.Location = new System.Drawing.Point(3, 3);
            this.page1_UCtrl1.Margin = new System.Windows.Forms.Padding(0);
            this.page1_UCtrl1.Name = "page1_UCtrl1";
            this.page1_UCtrl1.Size = new System.Drawing.Size(457, 472);
            this.page1_UCtrl1.TabIndex = 0;
            // 
            // tp_Logs
            // 
            this.tp_Logs.BackColor = System.Drawing.SystemColors.Control;
            this.tp_Logs.Controls.Add(this.tbCtrl_Logs);
            this.tp_Logs.Location = new System.Drawing.Point(4, 25);
            this.tp_Logs.Name = "tp_Logs";
            this.tp_Logs.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Logs.Size = new System.Drawing.Size(463, 478);
            this.tp_Logs.TabIndex = 1;
            this.tp_Logs.Text = "Message Logs";
            // 
            // tbCtrl_Logs
            // 
            this.tbCtrl_Logs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbCtrl_Logs.Controls.Add(this.tb_Loggers);
            this.tbCtrl_Logs.Controls.Add(this.tb_Records);
            this.tbCtrl_Logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtrl_Logs.Location = new System.Drawing.Point(3, 3);
            this.tbCtrl_Logs.Margin = new System.Windows.Forms.Padding(0);
            this.tbCtrl_Logs.Multiline = true;
            this.tbCtrl_Logs.Name = "tbCtrl_Logs";
            this.tbCtrl_Logs.SelectedIndex = 0;
            this.tbCtrl_Logs.Size = new System.Drawing.Size(457, 472);
            this.tbCtrl_Logs.TabIndex = 0;
            // 
            // tb_Loggers
            // 
            this.tb_Loggers.Controls.Add(this.tlp_Logger);
            this.tb_Loggers.Location = new System.Drawing.Point(4, 4);
            this.tb_Loggers.Name = "tb_Loggers";
            this.tb_Loggers.Padding = new System.Windows.Forms.Padding(3);
            this.tb_Loggers.Size = new System.Drawing.Size(449, 443);
            this.tb_Loggers.TabIndex = 0;
            this.tb_Loggers.Text = "Logger";
            this.tb_Loggers.UseVisualStyleBackColor = true;
            // 
            // tlp_Logger
            // 
            this.tlp_Logger.ColumnCount = 3;
            this.tlp_Logger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Logger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Logger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Logger.Controls.Add(this.bS_lift, 1, 0);
            this.tlp_Logger.Controls.Add(this.pl_LoggerCtrl1, 0, 0);
            this.tlp_Logger.Controls.Add(this.loggers_Ctrl21, 2, 0);
            this.tlp_Logger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Logger.Location = new System.Drawing.Point(3, 3);
            this.tlp_Logger.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Logger.Name = "tlp_Logger";
            this.tlp_Logger.RowCount = 1;
            this.tlp_Logger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Logger.Size = new System.Drawing.Size(443, 437);
            this.tlp_Logger.TabIndex = 0;
            // 
            // bS_lift
            // 
            this.bS_lift.BackColor = System.Drawing.Color.White;
            this.bS_lift.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS_lift.BtnImageIndex = 0;
            this.bS_lift.BtnImageList = this.imageList1;
            this.bS_lift.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_lift.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_lift.ButtonNoneColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_lift.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_lift.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_lift.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_lift.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS_lift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS_lift.IsListDown = false;
            this.bS_lift.IsOnOffClick = true;
            this.bS_lift.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS_lift.Location = new System.Drawing.Point(100, 0);
            this.bS_lift.Margin = new System.Windows.Forms.Padding(0);
            this.bS_lift.Name = "bS_lift";
            this.bS_lift.Size = new System.Drawing.Size(25, 437);
            this.bS_lift.Speed = 3;
            this.bS_lift.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS_lift.TabIndex = 0;
            this.bS_lift.Text_Button = "";
            this.bS_lift.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS_lift_ButtonStyle1_OnclickEvent);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "5402362_direction_arrow_previous_left_chevron_icon.png");
            this.imageList1.Images.SetKeyName(1, "5402363_arrow_chevron_direction_next_right_icon.png");
            // 
            // pl_LoggerCtrl1
            // 
            this.pl_LoggerCtrl1.BackColor = System.Drawing.Color.LightGray;
            this.pl_LoggerCtrl1.Controls.Add(this.loggers_Ctrl11);
            this.pl_LoggerCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_LoggerCtrl1.Location = new System.Drawing.Point(0, 0);
            this.pl_LoggerCtrl1.Margin = new System.Windows.Forms.Padding(0);
            this.pl_LoggerCtrl1.Name = "pl_LoggerCtrl1";
            this.pl_LoggerCtrl1.Size = new System.Drawing.Size(100, 437);
            this.pl_LoggerCtrl1.TabIndex = 1;
            // 
            // loggers_Ctrl11
            // 
            this.loggers_Ctrl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggers_Ctrl11.Location = new System.Drawing.Point(0, 0);
            this.loggers_Ctrl11.Margin = new System.Windows.Forms.Padding(0);
            this.loggers_Ctrl11.Name = "loggers_Ctrl11";
            this.loggers_Ctrl11.Size = new System.Drawing.Size(100, 437);
            this.loggers_Ctrl11.TabIndex = 0;
            // 
            // loggers_Ctrl21
            // 
            this.loggers_Ctrl21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggers_Ctrl21.Location = new System.Drawing.Point(125, 0);
            this.loggers_Ctrl21.Margin = new System.Windows.Forms.Padding(0);
            this.loggers_Ctrl21.Name = "loggers_Ctrl21";
            this.loggers_Ctrl21.Size = new System.Drawing.Size(318, 437);
            this.loggers_Ctrl21.TabIndex = 2;
            // 
            // tb_Records
            // 
            this.tb_Records.Location = new System.Drawing.Point(4, 4);
            this.tb_Records.Name = "tb_Records";
            this.tb_Records.Padding = new System.Windows.Forms.Padding(3);
            this.tb_Records.Size = new System.Drawing.Size(178, 36);
            this.tb_Records.TabIndex = 1;
            this.tb_Records.Text = "Records";
            this.tb_Records.UseVisualStyleBackColor = true;
            // 
            // tb_Paras
            // 
            this.tb_Paras.Controls.Add(this.page3_UCtrl1);
            this.tb_Paras.Location = new System.Drawing.Point(4, 25);
            this.tb_Paras.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Paras.Name = "tb_Paras";
            this.tb_Paras.Size = new System.Drawing.Size(463, 478);
            this.tb_Paras.TabIndex = 2;
            this.tb_Paras.Text = "System Parameters";
            this.tb_Paras.UseVisualStyleBackColor = true;
            // 
            // page3_UCtrl1
            // 
            this.page3_UCtrl1.BackColor = System.Drawing.Color.Gainsboro;
            this.page3_UCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page3_UCtrl1.Location = new System.Drawing.Point(0, 0);
            this.page3_UCtrl1.Margin = new System.Windows.Forms.Padding(0);
            this.page3_UCtrl1.Name = "page3_UCtrl1";
            this.page3_UCtrl1.Size = new System.Drawing.Size(463, 478);
            this.page3_UCtrl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pl_UC1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(471, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 507);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cms_MessageLogs
            // 
            this.cms_MessageLogs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_MessageLogs.Name = "cms_MessageLogs";
            this.cms_MessageLogs.Size = new System.Drawing.Size(61, 4);
            // 
            // pl_UC1
            // 
            this.pl_UC1.Controls.Add(this.controller_UC11);
            this.pl_UC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_UC1.Location = new System.Drawing.Point(0, 0);
            this.pl_UC1.Margin = new System.Windows.Forms.Padding(0);
            this.pl_UC1.Name = "pl_UC1";
            this.pl_UC1.Size = new System.Drawing.Size(315, 253);
            this.pl_UC1.TabIndex = 0;
            // 
            // controller_UC11
            // 
            this.controller_UC11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controller_UC11.Location = new System.Drawing.Point(0, 0);
            this.controller_UC11.Margin = new System.Windows.Forms.Padding(0);
            this.controller_UC11.MinimumSize = new System.Drawing.Size(315, 253);
            this.controller_UC11.Name = "controller_UC11";
            this.controller_UC11.Size = new System.Drawing.Size(315, 253);
            this.controller_UC11.TabIndex = 0;
            // 
            // Tabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Base);
            this.Name = "Tabs";
            this.Size = new System.Drawing.Size(786, 507);
            this.tlp_Base.ResumeLayout(false);
            this.tbCtrl.ResumeLayout(false);
            this.tp_Datas.ResumeLayout(false);
            this.tp_Logs.ResumeLayout(false);
            this.tbCtrl_Logs.ResumeLayout(false);
            this.tb_Loggers.ResumeLayout(false);
            this.tlp_Logger.ResumeLayout(false);
            this.pl_LoggerCtrl1.ResumeLayout(false);
            this.tb_Paras.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pl_UC1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Base;
        private System.Windows.Forms.TabControl tbCtrl;
        private System.Windows.Forms.TabPage tp_Datas;
        private System.Windows.Forms.TabPage tp_Logs;
        private System.Windows.Forms.TabPage tb_Paras;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tbCtrl_Logs;
        private System.Windows.Forms.TabPage tb_Loggers;
        private System.Windows.Forms.TableLayoutPanel tlp_Logger;
        private SECSCtrlLibs.ButtonStyle1 bS_lift;
        private System.Windows.Forms.TabPage tb_Records;
        private System.Windows.Forms.ContextMenuStrip cms_MessageLogs;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pl_LoggerCtrl1;
        private Loggers_Ctrl2 loggers_Ctrl21;
        private Loggers_Ctrl1 loggers_Ctrl11;
        private Page1_UCtrl page1_UCtrl1;
        private Page3_UCtrl page3_UCtrl1;
        private System.Windows.Forms.Panel pl_UC1;
        private Controller_UC1 controller_UC11;
    }
}
