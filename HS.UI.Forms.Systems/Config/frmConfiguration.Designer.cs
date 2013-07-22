namespace HS.UI.Forms.Systems.Config
{
    partial class frmConfiguration
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
            this.tabControlConfig = new System.Windows.Forms.TabControl();
            this.tabPageDanhMuc = new System.Windows.Forms.TabPage();
            this.tabPageSystemSetting = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlDanhMuc1 = new HS.UI.Forms.Systems.Config.DanhMuc.ctrlDanhMuc();
            this.tabControlConfig.SuspendLayout();
            this.tabPageDanhMuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlConfig
            // 
            this.tabControlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlConfig.Controls.Add(this.tabPageDanhMuc);
            this.tabControlConfig.Controls.Add(this.tabPageSystemSetting);
            this.tabControlConfig.Location = new System.Drawing.Point(12, 12);
            this.tabControlConfig.Name = "tabControlConfig";
            this.tabControlConfig.SelectedIndex = 0;
            this.tabControlConfig.Size = new System.Drawing.Size(709, 441);
            this.tabControlConfig.TabIndex = 0;
            // 
            // tabPageDanhMuc
            // 
            this.tabPageDanhMuc.Controls.Add(this.ctrlDanhMuc1);
            this.tabPageDanhMuc.Location = new System.Drawing.Point(4, 22);
            this.tabPageDanhMuc.Name = "tabPageDanhMuc";
            this.tabPageDanhMuc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDanhMuc.Size = new System.Drawing.Size(701, 415);
            this.tabPageDanhMuc.TabIndex = 0;
            this.tabPageDanhMuc.Text = "Danh mục";
            // 
            // tabPageSystemSetting
            // 
            this.tabPageSystemSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystemSetting.Name = "tabPageSystemSetting";
            this.tabPageSystemSetting.Size = new System.Drawing.Size(701, 415);
            this.tabPageSystemSetting.TabIndex = 1;
            this.tabPageSystemSetting.Text = "Tham số";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(643, 459);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ctrlDanhMuc1
            // 
            this.ctrlDanhMuc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDanhMuc1.Location = new System.Drawing.Point(3, 3);
            this.ctrlDanhMuc1.Name = "ctrlDanhMuc1";
            this.ctrlDanhMuc1.Size = new System.Drawing.Size(695, 409);
            this.ctrlDanhMuc1.TabIndex = 0;
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(733, 494);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControlConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguration";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu hình hệ thống";
            this.tabControlConfig.ResumeLayout(false);
            this.tabPageDanhMuc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlConfig;
        private System.Windows.Forms.TabPage tabPageDanhMuc;
        private System.Windows.Forms.TabPage tabPageSystemSetting;
        private System.Windows.Forms.Button btnClose;
        private DanhMuc.ctrlDanhMuc ctrlDanhMuc1;
    }
}