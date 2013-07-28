using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HS.UI.Base;
using HS.Service.Wraper;
using HS.Service.Connection.HSService;

namespace HS.UI.Forms.Systems.DanhMuc
{
    public partial class frmDanhMuc : MdiChildForm
    {
        private string CurrentDanhMuc = "";

        private BackgroundWorker workerLoadDetail;
        private BackgroundWorker workerLoadDanhMuc;
        private SystemWraper db = new SystemWraper();
        private Dictionary<ToolbarItem, bool> toolStripItemStatus = new Dictionary<ToolbarItem, bool>() { 
            {ToolbarItem.Add, true},
            {ToolbarItem.Edit, true},
            {ToolbarItem.Active, true},
            {ToolbarItem.InActive, true},
            {ToolbarItem.Delete, true}
        };

        public frmDanhMuc()
        {
            InitializeComponent();

            this.Tag = "frmDanhMuc";
            this.IsUniqueForm = true;

            this.ToolbarItems.AddRange(new List<ToolbarItem>() 
            { 
                ToolbarItem.Add,
                ToolbarItem.Edit,
                ToolbarItem.Seperator,
                ToolbarItem.Active,
                ToolbarItem.InActive,
                ToolbarItem.Seperator,
                ToolbarItem.Delete,
                ToolbarItem.Exit
            });

            #region Events

            SetEvents();

            #endregion

            //this.MainToolStrip = mainToolStrip;
            //mainToolStrip.Visible = false;
        }

        private void SetEvents()
        {
            this.Load += new EventHandler(frmDanhMuc_Load);

            trvDanhMuc.AfterSelect += trvDanhMuc_AfterSelect;
            trvDanhMuc.BeforeSelect += trvDanhMuc_BeforeSelect;

            workerLoadDetail = new BackgroundWorker()
            {
                WorkerReportsProgress = true
            };

            workerLoadDetail.DoWork += workerLoadDetail_DoWork;
            workerLoadDetail.ProgressChanged += workerLoadDetail_ProgressChanged;
            workerLoadDetail.RunWorkerCompleted += workerLoadDetail_RunWorkerCompleted;

            workerLoadDanhMuc = new BackgroundWorker()
            {
                WorkerReportsProgress = true
            };

            workerLoadDanhMuc.DoWork += new DoWorkEventHandler(workerLoadDanhMuc_DoWork);
            workerLoadDanhMuc.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerLoadDanhMuc_RunWorkerCompleted);

            sourceDanhMuc.CurrentChanged += sourceDanhMuc_CurrentChanged;

            gvwDanhMuc.CellDoubleClick += gvwDanhMuc_CellDoubleClick;
        }

        void frmDanhMuc_Load(object sender, EventArgs e)
        {
            InitControl();
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

            toolStripItemStatus[ToolbarItem.Active] = !curItem.Active;
            toolStripItemStatus[ToolbarItem.InActive] = curItem.Active;

            Variables.MainForm.SetStatusToolStrip(toolStripItemStatus);
        }

        void workerLoadDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            trvDanhMuc.SelectedNode.Text = trvDanhMuc.SelectedNode.Text.Replace(" (Loading)", "");

            //mainToolStrip.Enabled =
            toolStripItemStatus[ToolbarItem.Add] =
                                toolStripItemStatus[ToolbarItem.Edit] =
                                toolStripItemStatus[ToolbarItem.Active] =
                                toolStripItemStatus[ToolbarItem.InActive] =
                                toolStripItemStatus[ToolbarItem.Delete] = true;
            Variables.MainForm.SetStatusToolStrip(toolStripItemStatus);

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
            Variables.MainForm.SetStatus("");
        }

        void workerLoadDetail_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        void workerLoadDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = db.GetDanhMucItemsByDanhMuc(CurrentDanhMuc);

            e.Result = list != null ? list.OrderBy(p => p.ThuTu).ToList() : list;
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
            InitControl();
        }

        void trvDanhMuc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadDanhMucItem();
        }

        private void SetDataBinding()
        {
            LoadLoaiDanhMuc();
        }

        void workerLoadDanhMuc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var list = e.Result as List<DanhMucData>;

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
                Variables.MainForm.SetStatus("");
            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("[LoadLoaiDanhMuc]", ex);
                Variables.MainForm.SetStatus("");
            }
        }

        void workerLoadDanhMuc_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = db.GetDanhMucs();

            e.Result = list;
        }

        private void LoadLoaiDanhMuc()
        {
            workerLoadDanhMuc.RunWorkerAsync();
            Variables.MainForm.SetStatus("Đang lấy dữ liệu...");
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

                toolStripItemStatus[ToolbarItem.Add] =
                    toolStripItemStatus[ToolbarItem.Edit] =
                    toolStripItemStatus[ToolbarItem.Active] =
                    toolStripItemStatus[ToolbarItem.InActive] =
                    toolStripItemStatus[ToolbarItem.Delete] = false;
                Variables.MainForm.SetStatusToolStrip(toolStripItemStatus);

                gvwDanhMuc.Enabled = false;

                trvDanhMuc.SelectedNode.Text += " (Loading)";

                Variables.MainForm.SetStatus("Đang lấy dữ liệu...");
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
                MainMdiForms MDIForm = Variables.MainForm;

                toolStripItemStatus[ToolbarItem.Add] =
                toolStripItemStatus[ToolbarItem.Edit] =
                toolStripItemStatus[ToolbarItem.Active] =
                toolStripItemStatus[ToolbarItem.InActive] =
                toolStripItemStatus[ToolbarItem.Delete] = true;

                if (CurrentDanhMuc == "")
                {
                    
                    toolStripItemStatus[ToolbarItem.Add] =
                    toolStripItemStatus[ToolbarItem.Edit] =
                    toolStripItemStatus[ToolbarItem.Active] =
                    toolStripItemStatus[ToolbarItem.InActive] =
                    toolStripItemStatus[ToolbarItem.Delete] = false;

                    MDIForm.SetStatusToolStrip(toolStripItemStatus);

                    return;
                }

                if (sourceDanhMuc.Count == 0)
                {
                    toolStripItemStatus[ToolbarItem.Edit] =
                    toolStripItemStatus[ToolbarItem.Active] =
                    toolStripItemStatus[ToolbarItem.InActive] =
                    toolStripItemStatus[ToolbarItem.Delete] = false;
                    
                    MDIForm.SetStatusToolStrip(toolStripItemStatus);
                    return;
                }

                var curItem = sourceDanhMuc.Current as DanhMucItemData;

                if (curItem.Active)
                {
                    toolStripItemStatus[ToolbarItem.Active] = false;
                }
                else
                {
                    toolStripItemStatus[ToolbarItem.InActive] = false;
                }
                MDIForm.SetStatusToolStrip(toolStripItemStatus);
            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("[SetStatusNavigation]", ex);
            }
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

        public override void DoAdd()
        {
            if (new frmDanhMucItem_Edit(CurrentDanhMuc).ShowDialog() != DialogResult.Cancel)
            {
                LoadDanhMucItem();
            }
        }
        public override void DoEdit()
        {
            EditItem();
        }
        public override void DoDelete()
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
        public override void DoActive()
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
        public override void DoInActive()
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
    }
}
