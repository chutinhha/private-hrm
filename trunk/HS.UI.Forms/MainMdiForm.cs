using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HS.UI.Base;
using HS.DataAccess;

namespace HS.UI.Forms
{
    public partial class MainMdiForms : Form
    {
        Dictionary<string, int> MdiChildFormCount = new Dictionary<string, int>();

        OleDbConnection Connection;// = ConnectionBase.Connection;

        public MainMdiForms()
        {
            InitializeComponent();

            Connection = ConnectionBase.Connection;

            this.Text = ConfigurationManager.AppSettings["AppName"];
        }

        #region Tab Events

        public void AddFormToTab(MdiChildForm childForm)
        {
            // kiểm tra xem childForm có là unique không
            // nếu là unique form
            if (childForm.IsUniqueForm)
            {
                // duyệt toàn bộ các Tab đã thêm
                foreach (TabPage page in tabMDI.TabPages)
                {
                    // nếu tab nào có tag trùng với tag của form cần thêm
                    if (object.Equals(page.Tag, childForm.Tag))
                    {
                        // active Tab đó
                        tabMDI.SelectedTab = page;
                        // bỏ qua không thêm vào nữa
                        return;
                    }
                }
            }

            if (MdiChildFormCount.ContainsKey(childForm.Name))
            {
                MdiChildFormCount[childForm.Name]++;
            }
            else
            {
                MdiChildFormCount.Add(childForm.Name, 1);
            }

            // không là unique Form

            string tabText = "";
#if (DEBUG)
            tabText = string.Format("{0} - {1}", childForm.Text, childForm.Name);
#else
            tabText = childForm.Text;
#endif

            // tạo tab mới
            TabPage newTabPage = new TabPage()
            {
                Location = new System.Drawing.Point(4, 22),
                Padding = new System.Windows.Forms.Padding(3),
                Size = new System.Drawing.Size(476, 89),
                UseVisualStyleBackColor = true,
                Text = tabText,
                Tag = childForm.Tag != null ? childForm.Tag : string.Format("{0}_{1}", childForm.Name, MdiChildFormCount[childForm.Name]),
                ContextMenuStrip = tabMDI.ContextMenuStrip
            };

            // thêm tabpage vào tabMdi 
            tabMDI.TabPages.Insert(0, newTabPage);

            // thêm Form vào Tab
            childForm.MdiParent = this;
            childForm.Parent = newTabPage;
            childForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // active form vừa tạo
            tabMDI.SelectedTab = newTabPage;

            // Thêm form vào contextmenu tab
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem()
            {
                Text = childForm.Text,
                CheckState = System.Windows.Forms.CheckState.Checked,
                Tag = newTabPage
            };

            newMenuItem.Click += delegate(object sender, EventArgs e)
            {
                ToolStripMenuItem currentMenuItem = sender as ToolStripMenuItem;

                foreach (ToolStripMenuItem mnuItem in mnuTabControl.Items)
                {
                    if (mnuItem == currentMenuItem)
                    {
                        //currentMenuItem.CheckState = CheckState.Checked;

                        TabPage newActivePage = currentMenuItem.Tag as TabPage;

                        tabMDI.SelectedTab = newActivePage;
                    }
                    else
                    {
                        // un-check other item 

                        //currentMenuItem.CheckState = CheckState.Unchecked;
                    }

                }
            };

            mnuTabControl.Items.Add(newMenuItem);

            childForm.BackColor = System.Drawing.SystemColors.Window;
            CreateToolBar(toolMain, childForm.ToolbarItems);

            // hiện form lên
            childForm.Show();

            pnlTabControl.Visible = true;
        }

        private void btnShowListWindow_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);

            mnuTabControl.Show(ptLowerLeft);
        }

        private void btnCloseActiveTab_Click(object sender, EventArgs e)
        {
            CloseActiveTab();
        }

        private void CloseActiveTab()
        {
            var activeTab = tabMDI.SelectedTab;

            int i = 0;

            while (i < mnuTabControl.Items.Count)
            {
                ToolStripMenuItem mnuItem = mnuTabControl.Items[i] as ToolStripMenuItem;

                if (mnuItem.Tag == activeTab)
                {
                    mnuTabControl.Items.Remove(mnuItem);
                    continue;
                }

                i++;
            }

            tabMDI.TabPages.Remove(activeTab);

            if (tabMDI.TabPages.Count == 0)
            {
                pnlTabControl.Visible = false;

                toolMain.Items.Clear();

                toolMain.Visible = false;
            }
        }

        private void tabMDI_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set check for current item
            foreach (ToolStripMenuItem mnuItem in mnuTabControl.Items)
            {
                if (mnuItem.Tag == tabMDI.SelectedTab)
                {
                    mnuItem.CheckState = CheckState.Checked;

                    MdiChildForm childForm = tabMDI.SelectedTab.Controls[0] as MdiChildForm;

                    CreateToolBar(toolMain, childForm.ToolbarItems);
                }
                else
                {
                    mnuItem.CheckState = CheckState.Unchecked;
                }
            }
        }

        #endregion

        #region Menu Item Events

        private void mnuNhomTaiKhoan_Click(object sender, EventArgs e)
        {
            AddFormToTab(new HS.UI.Forms.Config.frmUserGroup());
        }
        private void mnuTaiKhoan_Click(object sender, EventArgs e)
        {
            AddFormToTab(new HS.UI.Forms.Config.frmUser());
        }

        #endregion

        #region Build ToolbarItem

        private void CreateToolBar(ToolStrip toolStrip, List<ToolbarItem> items)
        {
            toolMain.Visible = true;
            toolStrip.Items.Clear();

            foreach (ToolbarItem item in items)
            {
                if (item == ToolbarItem.Seperator)
                {
                    toolStrip.Items.Add(new ToolStripSeparator());
                    continue;
                }

                string imagePath = "";
                string buttonText = "";

                switch (item)
                {
                    case ToolbarItem.Add:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\add.png");
                        buttonText = "Thêm mới";
                        break;
                    case ToolbarItem.Edit:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\edit.png");
                        buttonText = "Sửa chữa";
                        break;
                    case ToolbarItem.Save:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\save.png");
                        buttonText = "Lưu lại";
                        break;
                    case ToolbarItem.Cancel:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\cancel.png");
                        buttonText = "Hủy bỏ";
                        break;
                    case ToolbarItem.Active:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\active.png");
                        buttonText = "Sử dụng";
                        break;
                    case ToolbarItem.InActive:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\inactive.png");
                        buttonText = "Khóa";
                        break;
                    case ToolbarItem.Print:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\print.png");
                        buttonText = "In";
                        break;
                    case ToolbarItem.Export:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\export.png");
                        buttonText = "Kết xuất";
                        break;
                    case ToolbarItem.Exit:
                        imagePath = System.IO.Path.Combine(Application.StartupPath, "Icons\\exit.png");
                        buttonText = "Đóng lại";
                        break;
                }

                ToolStripButton button = new ToolStripButton()
                {
                    Image = System.IO.File.Exists(imagePath) ? System.Drawing.Image.FromFile(imagePath) : null,
                    Text = buttonText,
                    DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                    Tag = item
                };

                button.Click += delegate(object sender, EventArgs e)
                {
                    ToolStripButton _button = sender as ToolStripButton;

                    var buttonType = _button.Tag as Nullable<ToolbarItem>;

                    MdiChildForm currentActiveForm = tabMDI.SelectedTab.Controls[0] as MdiChildForm;

                    switch (buttonType)
                    {
                        case ToolbarItem.Add:
                            currentActiveForm.DoAdd();
                            break;
                        case ToolbarItem.Edit:
                            currentActiveForm.DoEdit();
                            break;
                        case ToolbarItem.Save:
                            currentActiveForm.DoSave();
                            break;
                        case ToolbarItem.Cancel:
                            currentActiveForm.DoCancel();
                            break;
                        case ToolbarItem.Active:
                            currentActiveForm.DoActive();
                            break;
                        case ToolbarItem.InActive:
                            currentActiveForm.DoInActive();
                            break;
                        case ToolbarItem.Print:
                            currentActiveForm.DoPrint();
                            break;
                        case ToolbarItem.Export:
                            currentActiveForm.DoExport();
                            break;
                        case ToolbarItem.Exit:
                            CloseActiveTab();
                            break;
                    }
                };

                toolStrip.Items.Add(button);
            }
        }

        #endregion

    }
}
