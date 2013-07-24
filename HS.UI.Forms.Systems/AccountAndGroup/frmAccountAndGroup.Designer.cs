namespace HS.UI.Forms.Systems.AccountAndGroup
{
    partial class frmAccountAndGroup
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tài Khoản", 0, 0);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Nhóm", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Phân Quyền", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountAndGroup));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Tài khoản quản trị", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Tài khoản thường", System.Windows.Forms.HorizontalAlignment.Left);
            this.trvType = new System.Windows.Forms.TreeView();
            this.imgListUser = new System.Windows.Forms.ImageList(this.components);
            this.lstItems = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvType
            // 
            this.trvType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvType.ImageIndex = 2;
            this.trvType.ImageList = this.imgListUser;
            this.trvType.Location = new System.Drawing.Point(0, 0);
            this.trvType.Name = "trvType";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "nodeAccount";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Tài Khoản";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "nodeGroup";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Nhóm";
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "nodeMain";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "Phân Quyền";
            this.trvType.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.trvType.SelectedImageIndex = 2;
            this.trvType.Size = new System.Drawing.Size(177, 538);
            this.trvType.TabIndex = 0;
            // 
            // imgListUser
            // 
            this.imgListUser.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListUser.ImageStream")));
            this.imgListUser.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListUser.Images.SetKeyName(0, "user");
            this.imgListUser.Images.SetKeyName(1, "group");
            this.imgListUser.Images.SetKeyName(2, "main");
            // 
            // lstItems
            // 
            this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Tài khoản quản trị";
            listViewGroup1.Name = "grpAdmin";
            listViewGroup2.Header = "Tài khoản thường";
            listViewGroup2.Name = "grpNormal";
            this.lstItems.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(427, 538);
            this.lstItems.SmallImageList = this.imgListUser;
            this.lstItems.TabIndex = 1;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.List;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstItems);
            this.splitContainer1.Size = new System.Drawing.Size(608, 538);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 553);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // frmAccountAndGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 575);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAccountAndGroup";
            this.Text = "Phân Quyền";
            this.Load += new System.EventHandler(this.frmAccountAndGroup_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvType;
        private System.Windows.Forms.ImageList imgListUser;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}