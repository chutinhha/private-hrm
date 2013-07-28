namespace HS.UI.Forms.Systems.DanhMuc
{
    partial class frmDanhMuc
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
            this.trvDanhMuc = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvwDanhMuc = new System.Windows.Forms.DataGridView();
            this.MaDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThuTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDanhMuc = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceDanhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // trvDanhMuc
            // 
            this.trvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDanhMuc.HideSelection = false;
            this.trvDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.trvDanhMuc.Name = "trvDanhMuc";
            this.trvDanhMuc.Size = new System.Drawing.Size(220, 575);
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
            this.splitContainer1.Panel1MinSize = 220;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvwDanhMuc);
            this.splitContainer1.Size = new System.Drawing.Size(632, 575);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 2;
            // 
            // gvwDanhMuc
            // 
            this.gvwDanhMuc.AllowUserToAddRows = false;
            this.gvwDanhMuc.AllowUserToDeleteRows = false;
            this.gvwDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDanhMuc,
            this.TenDanhMuc,
            this.ThuTu});
            this.gvwDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvwDanhMuc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvwDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.gvwDanhMuc.MultiSelect = false;
            this.gvwDanhMuc.Name = "gvwDanhMuc";
            this.gvwDanhMuc.ReadOnly = true;
            this.gvwDanhMuc.RowHeadersVisible = false;
            this.gvwDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwDanhMuc.Size = new System.Drawing.Size(408, 575);
            this.gvwDanhMuc.TabIndex = 1;
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
            // sourceDanhMuc
            // 
            this.sourceDanhMuc.DataSource = typeof(HS.Service.Connection.HSService.DanhMucItemData);
            // 
            // frmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 575);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDanhMuc";
            this.Text = "Phân Quyền";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceDanhMuc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvDanhMuc;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvwDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThuTu;
        private System.Windows.Forms.BindingSource sourceDanhMuc;

    }
}