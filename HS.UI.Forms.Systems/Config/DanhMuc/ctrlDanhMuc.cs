using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HS.Service;
using HS.Service.Connection.HSService;
using HS.UI.Common;

namespace HS.UI.Forms.Systems.Config.DanhMuc
{
    public partial class ctrlDanhMuc : UserControl
    {
        private string CurrentDanhMuc = "";

        private BackgroundWorker workerLoadDetail;
        private SystemWraper db = new SystemWraper();

        public ctrlDanhMuc()
        {
            InitializeComponent();

            navActive.Enabled =
                        navAdd.Enabled =
                        navEdit.Enabled =
                        navInactive.Enabled =
                        navDelete.Enabled = false;

            SetEvents();
        }

        private void SetEvents()
        {
            navAdd.Click += navAdd_Click;
            navEdit.Click += navEdit_Click;
            navDelete.Click += navDelete_Click;
            navActive.Click += navActive_Click;
            navInactive.Click += navInactive_Click;

            trvDanhMuc.AfterSelect += trvDanhMuc_AfterSelect;
            trvDanhMuc.BeforeSelect += trvDanhMuc_BeforeSelect;

            workerLoadDetail = new BackgroundWorker()
            {
                WorkerReportsProgress = true
            };

            workerLoadDetail.DoWork += workerLoadDetail_DoWork;
            workerLoadDetail.ProgressChanged += workerLoadDetail_ProgressChanged;
            workerLoadDetail.RunWorkerCompleted += workerLoadDetail_RunWorkerCompleted;

            sourceDanhMuc.CurrentChanged += sourceDanhMuc_CurrentChanged;

            gvwDanhMuc.CellDoubleClick += gvwDanhMuc_CellDoubleClick;
        }

        void gvwDanhMuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditItem();
        }

        void sourceDanhMuc_CurrentChanged(object sender, EventArgs e)
        {
            if (sourceDanhMuc.Count == 0)
            {
                return;
            }

            var curItem = sourceDanhMuc.Current as DanhMucItemData;

            navActive.Enabled = !curItem.Active;
            navInactive.Enabled = curItem.Active;
        }

        void workerLoadDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            trvDanhMuc.SelectedNode.Text = trvDanhMuc.SelectedNode.Text.Replace(" (Loading)", "");

            toolStrip1.Enabled =
            gvwDanhMuc.Enabled = true;

            if (e.Result != null)
            {
                var list = e.Result as List<DanhMucItemData>;

                sourceDanhMuc.DataSource = list;

                if (list.Count > 0)
                {
                    sourceDanhMuc.MoveFirst();
                }

                SetStatusNavigation();
            }
        }

        void workerLoadDetail_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        void workerLoadDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = db.GetDanhMucItemsByDanhMuc(CurrentDanhMuc);

            e.Result = list != null ? list.OrderBy(p=>p.ThuTu).ToList() : list;
        }

        void trvDanhMuc_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (workerLoadDetail.IsBusy)
            {
                e.Cancel = true;
            }
        }

        public void InitControl()
        {
            gvwDanhMuc.AutoGenerateColumns = false;

            gvwDanhMuc.DataSource = sourceDanhMuc;

            SetDataBinding();
        }

        void ctrlDanhMuc_Load(object sender, EventArgs e)
        {
            //SetDataBinding();
        }

        void trvDanhMuc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadDanhMucItem();
        }

        private void SetDataBinding()
        {
            LoadLoaiDanhMuc();
        }

        private void LoadLoaiDanhMuc()
        {
            try
            {

                var list = db.GetDanhMucs();

                trvDanhMuc.Nodes.Clear();
                trvDanhMuc.Nodes.Add(new TreeNode()
                {
                    Text = "Danh mục thường",
                    ForeColor = Color.Blue
                });

                trvDanhMuc.Nodes.Add(new TreeNode()
                {
                    Text = "Hệ thống",
                    ForeColor = Color.Red
                });

                foreach (var item in list.OrderBy(p => p.ThuTu))
                {
                    if (item.System.HasValue && item.System.Value)
                    {
                        trvDanhMuc.Nodes[1].Nodes.Add(new TreeNode()
                        {
                            Text = item.TenLoaiDanhMuc,
                            Tag = item.MaLoaiDanhMuc
                        });
                    }
                    else
                    {
                        trvDanhMuc.Nodes[0].Nodes.Add(new TreeNode()
                        {
                            Text = item.TenLoaiDanhMuc,
                            Tag = item.MaLoaiDanhMuc
                        });
                    }
                }

                trvDanhMuc.Refresh();
                trvDanhMuc.ExpandAll();
            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("[LoadLoaiDanhMuc]", ex);
            }
        }

        private void LoadDanhMucItem()
        {
            try
            {
                var node = trvDanhMuc.SelectedNode;
                if (node == null || node.Tag == null)
                {
                    sourceDanhMuc.Clear();
                    CurrentDanhMuc = "";
                    SetStatusNavigation();

                    return;
                }

                CurrentDanhMuc = node.Tag.ToString();

                toolStrip1.Enabled =
                gvwDanhMuc.Enabled = false;

                trvDanhMuc.SelectedNode.Text += " (Loading)";

                workerLoadDetail.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("[LoadDetailDanhMuc]", ex);
            }
        }

        private void SetStatusNavigation()
        {
            try
            {
                navActive.Enabled =
                        navAdd.Enabled =
                        navEdit.Enabled =
                        navInactive.Enabled =
                        navDelete.Enabled = true;

                if (CurrentDanhMuc == "")
                {
                    navActive.Enabled =
                        navAdd.Enabled =
                        navEdit.Enabled =
                        navInactive.Enabled =
                        navDelete.Enabled = false;

                    return;
                }

                if (sourceDanhMuc.Count == 0)
                {
                    navActive.Enabled =
                        navEdit.Enabled =
                        navInactive.Enabled =
                        navDelete.Enabled = false;

                    return;
                }

                var curItem = sourceDanhMuc.Current as DanhMucItemData;

                if (curItem.Active)
                {
                    navActive.Enabled = false;
                }
                else
                {
                    navInactive.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("[SetStatusNavigation]", ex);
            }
        }

        void navInactive_Click(object sender, EventArgs e)
        {
            if (sourceDanhMuc.Count == 0)
            {
                return;
            }

            if (Common.Methods.Confirm("Chắc chắn bạn muốn Ngưng sử dụng danh mục đang chọn"))
            {
                var curItem = sourceDanhMuc.Current as DanhMucItemData;

                curItem.Active = false;
                if (db.ChangeDanhMucItem(curItem) > 0)
                {
                    LoadDanhMucItem();
                }
            }
        }

        void navActive_Click(object sender, EventArgs e)
        {
            if (sourceDanhMuc.Count == 0)
            {
                return;
            }

            if (Common.Methods.Confirm("Chắc chắn bạn muốn Sử dụng lại danh mục đang chọn"))
            {
                var curItem = sourceDanhMuc.Current as DanhMucItemData;

                curItem.Active = true;
                if (db.ChangeDanhMucItem(curItem) > 0)
                {
                    LoadDanhMucItem();
                }
            }
        }

        void navDelete_Click(object sender, EventArgs e)
        {
            if (sourceDanhMuc.Count == 0)
            {
                return;
            }

            if (Common.Methods.Confirm("Chắc chắn bạn muốn xóa Danh mục đang chọn"))
            {
                var curItem = sourceDanhMuc.Current as DanhMucItemData;

                if (db.RemoveDanhMucItem(curItem) > 0)
                {
                    LoadDanhMucItem();
                }
            }
        }

        void navEdit_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void EditItem()
        {
            if (sourceDanhMuc.Count == 0)
            {
                return;
            }

            var refData = sourceDanhMuc.Current as DanhMucItemData;

            var f = new frmDanhMucItem_Edit(CurrentDanhMuc) { RefData = refData };

            if (f.ShowDialog() != DialogResult.Cancel)
            {
                LoadDanhMucItem();
            }
        }

        void navAdd_Click(object sender, EventArgs e)
        {
            if (new frmDanhMucItem_Edit(CurrentDanhMuc).ShowDialog() != DialogResult.Cancel)
            {
                LoadDanhMucItem();
            }
        }
    }
}
