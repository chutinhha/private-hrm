
namespace HS.UI.Forms
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhomTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendMailTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabMDI = new System.Windows.Forms.TabControl();
            this.pnlTabControl = new System.Windows.Forms.Panel();
            this.btnCloseActiveTab = new System.Windows.Forms.Button();
            this.btnShowListWindow = new System.Windows.Forms.Button();
            this.mnuTabControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(568, 24);
            this.mnuMain.TabIndex = 6;
            this.mnuMain.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuSendMailTest,
            this.toolStripSeparator1,
            this.mnuThoat});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhomTaiKhoan,
            this.mnuTaiKhoan});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(152, 22);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuNhomTaiKhoan
            // 
            this.mnuNhomTaiKhoan.Name = "mnuNhomTaiKhoan";
            this.mnuNhomTaiKhoan.Size = new System.Drawing.Size(160, 22);
            this.mnuNhomTaiKhoan.Text = "&Nhóm tài khoản";
            this.mnuNhomTaiKhoan.Click += new System.EventHandler(this.mnuNhomTaiKhoan_Click);
            // 
            // mnuTaiKhoan
            // 
            this.mnuTaiKhoan.Name = "mnuTaiKhoan";
            this.mnuTaiKhoan.Size = new System.Drawing.Size(160, 22);
            this.mnuTaiKhoan.Text = "Tài &khoản";
            this.mnuTaiKhoan.Click += new System.EventHandler(this.mnuTaiKhoan_Click);
            // 
            // mnuSendMailTest
            // 
            this.mnuSendMailTest.Name = "mnuSendMailTest";
            this.mnuSendMailTest.Size = new System.Drawing.Size(152, 22);
            this.mnuSendMailTest.Text = "Send Mail test";
            this.mnuSendMailTest.Click += new System.EventHandler(this.mnuSendMailTest_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(152, 22);
            this.mnuThoat.Text = "&Thoát";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(568, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolMain
            // 
            this.toolMain.Location = new System.Drawing.Point(0, 24);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(568, 25);
            this.toolMain.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabMDI);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 351);
            this.panel1.TabIndex = 9;
            // 
            // tabMDI
            // 
            this.tabMDI.AllowDrop = true;
            this.tabMDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMDI.Location = new System.Drawing.Point(0, 0);
            this.tabMDI.Name = "tabMDI";
            this.tabMDI.SelectedIndex = 0;
            this.tabMDI.Size = new System.Drawing.Size(568, 351);
            this.tabMDI.TabIndex = 0;
            this.tabMDI.SelectedIndexChanged += new System.EventHandler(this.tabMDI_SelectedIndexChanged);
            // 
            // pnlTabControl
            // 
            this.pnlTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControl.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTabControl.Controls.Add(this.btnCloseActiveTab);
            this.pnlTabControl.Controls.Add(this.btnShowListWindow);
            this.pnlTabControl.Location = new System.Drawing.Point(535, 51);
            this.pnlTabControl.Name = "pnlTabControl";
            this.pnlTabControl.Size = new System.Drawing.Size(32, 16);
            this.pnlTabControl.TabIndex = 11;
            this.pnlTabControl.Visible = false;
            // 
            // btnCloseActiveTab
            // 
            this.btnCloseActiveTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseActiveTab.FlatStyle = System.Windows.Forms.FlatStyle.System;
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
            this.btnShowListWindow.FlatStyle = System.Windows.Forms.FlatStyle.System;
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
            // MainMdiForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 422);
            this.Controls.Add(this.pnlTabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainMdiForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMDI;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuNhomTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuSendMailTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTabControl;
        private System.Windows.Forms.Button btnCloseActiveTab;
        private System.Windows.Forms.Button btnShowListWindow;
        private System.Windows.Forms.ContextMenuStrip mnuTabControl;
    }
}