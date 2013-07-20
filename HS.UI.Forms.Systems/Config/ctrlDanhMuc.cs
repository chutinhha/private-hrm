using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HS.Server.BR.Entities.Systems;

namespace HS.UI.Forms.Systems.Config
{
    public partial class ctrlDanhMuc : UserControl
    {
        public ctrlDanhMuc()
        {
            InitializeComponent();


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

            //this.Load += ctrlDanhMuc_Load;
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
            var node = e.Node;
            if (node.Tag == null)
            {
                return;
            }

            LoadDetailDanhMuc(node.Tag.ToString());
        }

        private void SetDataBinding()
        {
            LoadLoaiDanhMuc();
        }

        private void LoadLoaiDanhMuc()
        {
            try
            {
                var db = new DanhMucEntities();

                var list = db.GetDanhMucs();

                trvDanhMuc.Nodes.Clear();
                trvDanhMuc.Nodes.Add(new TreeNode()
                {
                    Text = "Danh mục thường",
                    ForeColor = Color.Black,
                    NodeFont = new Font(DefaultFont, FontStyle.Bold)
                });

                trvDanhMuc.Nodes.Add(new TreeNode()
                {
                    Text = "Hệ thống",
                    NodeFont = new Font(DefaultFont, FontStyle.Bold),
                    ForeColor = Color.Red
                });

                foreach (var item in list.OrderBy(p => p.ThuTu))
                {
                    if (item.System.HasValue && item.System.Value)
                    {
                        trvDanhMuc.Nodes[1].Nodes.Add(new TreeNode()
                        {
                            Text = item.TenLoaiDanhMuc,
                            Tag = item.MaLoaiDanhMuc,
                            ForeColor = Color.Red,
                            NodeFont = new Font(DefaultFont, FontStyle.Italic)
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

                trvDanhMuc.ExpandAll();
                trvDanhMuc.Select();
            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("#LoadLoaiDanhMuc", ex);
            }
        }

        private void LoadDetailDanhMuc(string type)
        {
            try
            {

                var db = new DanhMucItemEntities();

                var list = db.GetDanhMucItemsByDanhMuc(type);

                sourceDanhMuc.DataSource = list;

            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("#LoadDetailDanhMuc", ex);
            }
        }

        void navInactive_Click(object sender, EventArgs e)
        {

        }

        void navActive_Click(object sender, EventArgs e)
        {

        }

        void navDelete_Click(object sender, EventArgs e)
        {

        }

        void navEdit_Click(object sender, EventArgs e)
        {

        }

        void navAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
