namespace SECSTry
{
    partial class Page3_UCtrl
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
            this.tlp_Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bS1_System = new SECSCtrlLibs.ButtonStyle1();
            this.bS1_SECSII = new SECSCtrlLibs.ButtonStyle1();
            this.bS1_Protocol = new SECSCtrlLibs.ButtonStyle1();
            this.buttonStyle14 = new SECSCtrlLibs.ButtonStyle1();
            this.tlp_Base.SuspendLayout();
            this.tlp_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Base
            // 
            this.tlp_Base.ColumnCount = 2;
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlp_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Controls.Add(this.tlp_Buttons, 0, 0);
            this.tlp_Base.Controls.Add(this.panel1, 1, 0);
            this.tlp_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Base.Location = new System.Drawing.Point(0, 0);
            this.tlp_Base.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Base.Name = "tlp_Base";
            this.tlp_Base.RowCount = 1;
            this.tlp_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Base.Size = new System.Drawing.Size(463, 478);
            this.tlp_Base.TabIndex = 0;
            // 
            // tlp_Buttons
            // 
            this.tlp_Buttons.ColumnCount = 1;
            this.tlp_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Buttons.Controls.Add(this.bS1_System, 0, 0);
            this.tlp_Buttons.Controls.Add(this.bS1_SECSII, 0, 1);
            this.tlp_Buttons.Controls.Add(this.bS1_Protocol, 0, 2);
            this.tlp_Buttons.Controls.Add(this.buttonStyle14, 0, 3);
            this.tlp_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Buttons.Location = new System.Drawing.Point(0, 0);
            this.tlp_Buttons.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Buttons.Name = "tlp_Buttons";
            this.tlp_Buttons.RowCount = 5;
            this.tlp_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Buttons.Size = new System.Drawing.Size(75, 478);
            this.tlp_Buttons.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(75, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 478);
            this.panel1.TabIndex = 1;
            // 
            // bS1_System
            // 
            this.bS1_System.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bS1_System.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_System.BtnImageIndex = -1;
            this.bS1_System.BtnImageList = null;
            this.bS1_System.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_System.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_System.ButtonNoneColor_KnownColor = System.Drawing.Color.Aqua;
            this.bS1_System.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_System.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_System.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_System.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_System.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_System.IsListDown = false;
            this.bS1_System.IsOnOffClick = true;
            this.bS1_System.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_System.Location = new System.Drawing.Point(0, 0);
            this.bS1_System.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_System.Name = "bS1_System";
            this.bS1_System.Size = new System.Drawing.Size(75, 30);
            this.bS1_System.Speed = 3;
            this.bS1_System.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_System.TabIndex = 0;
            this.bS1_System.Tag = "";
            this.bS1_System.Text_Button = "System";
            this.bS1_System.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_System_ButtonStyle1_OnclickEvent);
            // 
            // bS1_SECSII
            // 
            this.bS1_SECSII.BackColor = System.Drawing.Color.White;
            this.bS1_SECSII.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_SECSII.BtnImageIndex = -1;
            this.bS1_SECSII.BtnImageList = null;
            this.bS1_SECSII.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_SECSII.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_SECSII.ButtonNoneColor_KnownColor = System.Drawing.Color.Azure;
            this.bS1_SECSII.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_SECSII.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_SECSII.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_SECSII.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_SECSII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_SECSII.IsListDown = false;
            this.bS1_SECSII.IsOnOffClick = true;
            this.bS1_SECSII.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_SECSII.Location = new System.Drawing.Point(0, 30);
            this.bS1_SECSII.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_SECSII.Name = "bS1_SECSII";
            this.bS1_SECSII.Size = new System.Drawing.Size(75, 30);
            this.bS1_SECSII.Speed = 3;
            this.bS1_SECSII.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_SECSII.TabIndex = 1;
            this.bS1_SECSII.Tag = "";
            this.bS1_SECSII.Text_Button = "SECS II";
            this.bS1_SECSII.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_System_ButtonStyle1_OnclickEvent);
            // 
            // bS1_Protocol
            // 
            this.bS1_Protocol.BackColor = System.Drawing.Color.White;
            this.bS1_Protocol.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.bS1_Protocol.BtnImageIndex = -1;
            this.bS1_Protocol.BtnImageList = null;
            this.bS1_Protocol.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Protocol.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Protocol.ButtonNoneColor_KnownColor = System.Drawing.Color.Azure;
            this.bS1_Protocol.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Protocol.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Protocol.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Protocol.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.bS1_Protocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bS1_Protocol.IsListDown = false;
            this.bS1_Protocol.IsOnOffClick = true;
            this.bS1_Protocol.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bS1_Protocol.Location = new System.Drawing.Point(0, 60);
            this.bS1_Protocol.Margin = new System.Windows.Forms.Padding(0);
            this.bS1_Protocol.Name = "bS1_Protocol";
            this.bS1_Protocol.Size = new System.Drawing.Size(75, 30);
            this.bS1_Protocol.Speed = 3;
            this.bS1_Protocol.SubButtonSize = new System.Drawing.Size(100, 25);
            this.bS1_Protocol.TabIndex = 2;
            this.bS1_Protocol.Text_Button = "Protocol";
            this.bS1_Protocol.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_System_ButtonStyle1_OnclickEvent);
            // 
            // buttonStyle14
            // 
            this.buttonStyle14.BackColor = System.Drawing.Color.White;
            this.buttonStyle14.bS_Style = SECSCtrlLibs.EButtonStyle1.None;
            this.buttonStyle14.BtnImageIndex = -1;
            this.buttonStyle14.BtnImageList = null;
            this.buttonStyle14.ButtonEnterColor_KnownColor = System.Drawing.SystemColors.Control;
            this.buttonStyle14.ButtonLockedColor_KnownColor = System.Drawing.SystemColors.Control;
            this.buttonStyle14.ButtonNoneColor_KnownColor = System.Drawing.Color.Azure;
            this.buttonStyle14.ButtonOffColor_KnownColor = System.Drawing.SystemColors.Control;
            this.buttonStyle14.ButtonOnColor_KnownColor = System.Drawing.SystemColors.Control;
            this.buttonStyle14.ButtonWarnningColor1_KnownColor = System.Drawing.SystemColors.Control;
            this.buttonStyle14.ButtonWarnningColor2_KnownColor = System.Drawing.SystemColors.Control;
            this.buttonStyle14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStyle14.IsListDown = false;
            this.buttonStyle14.IsOnOffClick = true;
            this.buttonStyle14.ListAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonStyle14.Location = new System.Drawing.Point(0, 90);
            this.buttonStyle14.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStyle14.Name = "buttonStyle14";
            this.buttonStyle14.Size = new System.Drawing.Size(75, 30);
            this.buttonStyle14.Speed = 3;
            this.buttonStyle14.SubButtonSize = new System.Drawing.Size(100, 25);
            this.buttonStyle14.TabIndex = 3;
            this.buttonStyle14.Text_Button = "";
            this.buttonStyle14.ButtonStyle1_OnclickEvent += new System.EventHandler(this.bS1_System_ButtonStyle1_OnclickEvent);
            // 
            // Page3_UCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.tlp_Base);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Page3_UCtrl";
            this.Size = new System.Drawing.Size(463, 478);
            this.tlp_Base.ResumeLayout(false);
            this.tlp_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Base;
        private System.Windows.Forms.TableLayoutPanel tlp_Buttons;
        private SECSCtrlLibs.ButtonStyle1 bS1_System;
        private SECSCtrlLibs.ButtonStyle1 bS1_SECSII;
        private SECSCtrlLibs.ButtonStyle1 bS1_Protocol;
        private SECSCtrlLibs.ButtonStyle1 buttonStyle14;
        private System.Windows.Forms.Panel panel1;
    }
}
