namespace HS.UI.Forms.Systems.Config
{
    partial class ctrlDanhMuc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlDanhMuc));
            this.trvDanhMuc = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvwDanhMuc = new System.Windows.Forms.DataGridView();
            this.sourceDanhMuc = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.navAdd = new System.Windows.Forms.ToolStripButton();
            this.navEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.navActive = new System.Windows.Forms.ToolStripButton();
            this.navInactive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.navDelete = new System.Windows.Forms.ToolStripButton();
            this.MaDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThuTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceDanhMuc)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvDanhMuc
            // 
            this.trvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDanhMuc.HideSelection = false;
            this.trvDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.trvDanhMuc.Name = "trvDanhMuc";
            this.trvDanhMuc.Size = new System.Drawing.Size(254, 524);
            this.trvDanhMuc.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvDanhMuc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvwDanhMuc);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(763, 524);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 1;
            // 
            // gvwDanhMuc
            // 
            this.gvwDanhMuc.AllowUserToAddRows = false;
            this.gvwDanhMuc.AllowUserToDeleteRows = false;
            this.gvwDanhMuc.AutoGenerateColumns = false;
            this.gvwDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDanhMuc,
            this.TenDanhMuc,
            this.ThuTu});
            this.gvwDanhMuc.DataSource = this.sourceDanhMuc;
            this.gvwDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvwDanhMuc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvwDanhMuc.Location = new System.Drawing.Point(0, 25);
            this.gvwDanhMuc.MultiSelect = false;
            this.gvwDanhMuc.Name = "gvwDanhMuc";
            this.gvwDanhMuc.ReadOnly = true;
            this.gvwDanhMuc.RowHeadersVisible = false;
            this.gvwDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwDanhMuc.Size = new System.Drawing.Size(505, 499);
            this.gvwDanhMuc.TabIndex = 1;
            // 
            // sourceDanhMuc
            // 
            this.sourceDanhMuc.DataSource = typeof(HS.Server.Interfaces.DAO.DmDanhmucitemData);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navAdd,
            this.navEdit,
            this.toolStripSeparator1,
            this.navActive,
            this.navInactive,
            this.toolStripSeparator2,
            this.navDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(505, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // navAdd
            // 
            this.navAdd.Image = ((System.Drawing.Image)(resources.GetObject("navAdd.Image")));
            this.navAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navAdd.Name = "navAdd";
            this.navAdd.Size = new System.Drawing.Size(82, 22);
            this.navAdd.Text = "Thêm mới";
            // 
            // navEdit
            // 
            this.navEdit.Image = ((System.Drawing.Image)(resources.GetObject("navEdit.Image")));
            this.navEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navEdit.Name = "navEdit";
            this.navEdit.Size = new System.Drawing.Size(80, 22);
            this.navEdit.Text = "Chỉnh sửa";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // navActive
            // 
            this.navActive.Image = ((System.Drawing.Image)(resources.GetObject("navActive.Image")));
            this.navActive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navActive.Name = "navActive";
            this.navActive.Size = new System.Drawing.Size(71, 22);
            this.navActive.Text = "Sử dụng";
            // 
            // navInactive
            // 
            this.navInactive.Image = ((System.Drawing.Image)(resources.GetObject("navInactive.Image")));
            this.navInactive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navInactive.Name = "navInactive";
            this.navInactive.Size = new System.Drawing.Size(110, 22);
            this.navInactive.Text = "Ngừng sử dụng";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // navDelete
            // 
            this.navDelete.Image = ((System.Drawing.Image)(resources.GetObject("navDelete.Image")));
            this.navDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navDelete.Name = "navDelete";
            this.navDelete.Size = new System.Drawing.Size(64, 22);
            this.navDelete.Text = "Xóa bỏ";
            // 
            // MaDanhMuc
            // 
            this.MaDanhMuc.DataPropertyName = "MaDanhMuc";
            this.MaDanhMuc.HeaderText = "Mã danh mục";
            this.MaDanhMuc.MaxInputLength = 150;
            this.MaDanhMuc.Name = "MaDanhMuc";
            this.MaDanhMuc.ReadOnly = true;
            this.MaDanhMuc.Width = 150;
            // 
            // TenDanhMuc
            // 
            this.TenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.TenDanhMuc.HeaderText = "Tên danh mục";
            this.TenDanhMuc.MaxInputLength = 150;
            this.TenDanhMuc.Name = "TenDanhMuc";
            this.TenDanhMuc.ReadOnly = true;
            this.TenDanhMuc.Width = 200;
            // 
            // ThuTu
            // 
            this.ThuTu.DataPropertyName = "ThuTu";
            this.ThuTu.HeaderText = "Thứ tự";
            this.ThuTu.MaxInputLength = 5;
            this.ThuTu.Name = "ThuTu";
            this.ThuTu.ReadOnly = true;
            // 
            // ctrlDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctrlDanhMuc";
            this.Size = new System.Drawing.Size(763, 524);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceDanhMuc)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvDanhMuc;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvwDanhMuc;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton navAdd;
        private System.Windows.Forms.ToolStripButton navEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton navActive;
        private System.Windows.Forms.ToolStripButton navInactive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton navDelete;
        private System.Windows.Forms.BindingSource sourceDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThuTu;
    }
}
