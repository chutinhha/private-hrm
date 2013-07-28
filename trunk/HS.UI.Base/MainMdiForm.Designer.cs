
namespace HS.UI.Base
{
    partial class MainMdiForms
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
            this.components = new System.ComponentModel.Container();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSYSTEM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPhanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTOOL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHELP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.lblCurrentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabMDI = new System.Windows.Forms.TabControl();
            this.pnlTabControl = new System.Windows.Forms.Panel();
            this.btnCloseActiveTab = new System.Windows.Forms.Button();
            this.btnShowListWindow = new System.Windows.Forms.Button();
            this.mnuTabControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.mnuMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSYSTEM,
            this.mnuTOOL,
            this.mnuHELP});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(591, 24);
            this.mnuMain.TabIndex = 12;
            // 
            // mnuSYSTEM
            // 
            this.mnuSYSTEM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangePassword,
            this.mnuLogin,
            this.toolStripSeparator4,
            this.mnuPhanQuyen,
            this.mnuConfiguration,
            this.toolStripSeparator3,
            this.mnuExit});
            this.mnuSYSTEM.Name = "mnuSYSTEM";
            this.mnuSYSTEM.Size = new System.Drawing.Size(79, 20);
            this.mnuSYSTEM.Tag = "_0";
            this.mnuSYSTEM.Text = "HỆ THỐNG";
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(163, 22);
            this.mnuChangePassword.Text = "Đổi Mật Khẩu";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(163, 22);
            this.mnuLogin.Tag = "1";
            this.mnuLogin.Text = "Đăng Nhập";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuPhanQuyen
            // 
            this.mnuPhanQuyen.Name = "mnuPhanQuyen";
            this.mnuPhanQuyen.Size = new System.Drawing.Size(163, 22);
            this.mnuPhanQuyen.Tag = "0|1|HS.UI.Forms.Systems.dll|HS.UI.Forms.Systems.AccountAndGroup.frmAccountAndGrou" +
                "p|1";
            this.mnuPhanQuyen.Text = "Phân Quyền";
            this.mnuPhanQuyen.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuConfiguration
            // 
            this.mnuConfiguration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMuc});
            this.mnuConfiguration.Name = "mnuConfiguration";
            this.mnuConfiguration.Size = new System.Drawing.Size(163, 22);
            this.mnuConfiguration.Tag = "0|0|HS.UI.Forms.Systems.dll|HS.UI.Forms.Systems.Config.frmConfiguration|1";
            this.mnuConfiguration.Text = "Thiết Lập";
            this.mnuConfiguration.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(129, 22);
            this.mnuDanhMuc.Tag = "0|1|HS.UI.Forms.Systems.dll|HS.UI.Forms.Systems.DanhMuc.frmDanhMuc|1";
            this.mnuDanhMuc.Text = "&Danh Mục";
            this.mnuDanhMuc.Click += new System.EventHandler(this.mnuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(163, 22);
            this.mnuExit.Text = "Thoát Ra";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuTOOL
            // 
            this.mnuTOOL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripSeparator2});
            this.mnuTOOL.Name = "mnuTOOL";
            this.mnuTOOL.Size = new System.Drawing.Size(67, 20);
            this.mnuTOOL.Tag = "_998";
            this.mnuTOOL.Text = "TIỆN ÍCH";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "toolStripMenuItem5";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuHELP
            // 
            this.mnuHELP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewDocument,
            this.mnuCheckUpdate,
            this.toolStripSeparator1,
            this.mnuAbout});
            this.mnuHELP.Name = "mnuHELP";
            this.mnuHELP.Size = new System.Drawing.Size(71, 20);
            this.mnuHELP.Tag = "_999";
            this.mnuHELP.Text = "TRỢ GIÚP";
            // 
            // mnuViewDocument
            // 
            this.mnuViewDocument.Name = "mnuViewDocument";
            this.mnuViewDocument.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.mnuViewDocument.Size = new System.Drawing.Size(229, 22);
            this.mnuViewDocument.Text = "Hướng Dẫn Sử Dụng";
            // 
            // mnuCheckUpdate
            // 
            this.mnuCheckUpdate.Name = "mnuCheckUpdate";
            this.mnuCheckUpdate.Size = new System.Drawing.Size(229, 22);
            this.mnuCheckUpdate.Text = "Kiểm Tra Cập Nhật";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(229, 22);
            this.mnuAbout.Text = "Giới Thiệu";
            // 
            // statusMain
            // 
            this.statusMain.Dock = System.Windows.Forms.DockStyle.None;
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentStatus});
            this.statusMain.Location = new System.Drawing.Point(0, 0);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(591, 22);
            this.statusMain.TabIndex = 0;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(545, 17);
            this.lblCurrentStatus.Spring = true;
            this.lblCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolMain
            // 
            this.toolMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolMain.Location = new System.Drawing.Point(3, 24);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(111, 25);
            this.toolMain.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabMDI);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 351);
            this.panel1.TabIndex = 9;
            // 
            // tabMDI
            // 
            this.tabMDI.AllowDrop = true;
            this.tabMDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMDI.Location = new System.Drawing.Point(0, 0);
            this.tabMDI.Name = "tabMDI";
            this.tabMDI.SelectedIndex = 0;
            this.tabMDI.Size = new System.Drawing.Size(591, 351);
            this.tabMDI.TabIndex = 0;
            this.tabMDI.SelectedIndexChanged += new System.EventHandler(this.tabMDI_SelectedIndexChanged);
            // 
            // pnlTabControl
            // 
            this.pnlTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControl.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTabControl.Controls.Add(this.btnCloseActiveTab);
            this.pnlTabControl.Controls.Add(this.btnShowListWindow);
            this.pnlTabControl.Location = new System.Drawing.Point(558, 2);
            this.pnlTabControl.Name = "pnlTabControl";
            this.pnlTabControl.Size = new System.Drawing.Size(32, 16);
            this.pnlTabControl.TabIndex = 11;
            this.pnlTabControl.Visible = false;
            // 
            // btnCloseActiveTab
            // 
            this.btnCloseActiveTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseActiveTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCloseActiveTab.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseActiveTab.Location = new System.Drawing.Point(16, -1);
            this.btnCloseActiveTab.Name = "btnCloseActiveTab";
            this.btnCloseActiveTab.Size = new System.Drawing.Size(17, 18);
            this.btnCloseActiveTab.TabIndex = 1;
            this.btnCloseActiveTab.Text = "X";
            this.btnCloseActiveTab.UseVisualStyleBackColor = true;
            this.btnCloseActiveTab.Click += new System.EventHandler(this.btnCloseActiveTab_Click);
            // 
            // btnShowListWindow
            // 
            this.btnShowListWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowListWindow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowListWindow.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowListWindow.Location = new System.Drawing.Point(-1, -1);
            this.btnShowListWindow.Name = "btnShowListWindow";
            this.btnShowListWindow.Size = new System.Drawing.Size(18, 18);
            this.btnShowListWindow.TabIndex = 0;
            this.btnShowListWindow.Text = "▼";
            this.btnShowListWindow.UseVisualStyleBackColor = true;
            this.btnShowListWindow.Click += new System.EventHandler(this.btnShowListWindow_Click);
            // 
            // mnuTabControl
            // 
            this.mnuTabControl.Name = "mnuTabControl";
            this.mnuTabControl.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusMain);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pnlTabControl);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(591, 351);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(591, 422);
            this.toolStripContainer1.TabIndex = 14;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mnuMain);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolMain);
            // 
            // MainMdiForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 422);
            this.Controls.Add(this.toolStripContainer1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainMdiForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMDI;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTabControl;
        private System.Windows.Forms.Button btnCloseActiveTab;
        private System.Windows.Forms.Button btnShowListWindow;
        private System.Windows.Forms.ContextMenuStrip mnuTabControl;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuSYSTEM;
        private System.Windows.Forms.ToolStripMenuItem mnuTOOL;
        private System.Windows.Forms.ToolStripMenuItem mnuHELP;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDocument;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuPhanQuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
    }
}