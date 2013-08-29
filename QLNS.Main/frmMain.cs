using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace QLNS.Main
{
    public partial class frmMain : RadForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tabMain_PageRemoving(object sender, RadPageViewCancelEventArgs e)
        {
            if (e.Page.Name == "pageMain")
            {
                e.Cancel = true;
            }
        }

        private void trvChucNang_SelectedNodeChanging(object sender, RadTreeViewCancelEventArgs e)
        {
            e.Cancel = true;
            var tag = e.Node.Tag;

            if (tag == null)
            {
                return;
            }

            string tabTag = "";
            UserControl control = null;

            switch (tag.ToString())
            {
                case "Add":
                    tabTag = "addNhanSu";
                    control = new NhanSu.ctrlThemMoi();
                    break;
                case "Edit":
                    break;
                case "Delete":
                    break;
                case "Contract":
                    break;
                case "Education":
                    break;
                case "Family":
                    break;
            }

            AddPageToTab(tabTag, control);
        }

        private void AddPageToTab(string tabTag, UserControl control)
        {
            RadPageViewPage pageView = null;
            foreach (RadPageViewPage page in tabMain.Pages)
            {
                if (page.Tag == tabTag)
                {
                    pageView = page;
                    break;
                }
            }

            if (pageView != null)
            {
                tabMain.SelectedPage = pageView;
            }
            else
            {
                RadPageViewPage newPage = new RadPageViewPage()
                {
                    Tag = tabTag,
                    Text = control.Text
                };

                tabMain.Pages.Add(newPage);
                tabMain.SelectedPage = newPage;

                control.Dock = DockStyle.Fill;
                control.Parent = newPage;
            }
        }

        private void AddPageToTab(string tabTag, RadForm control)
        {
            RadPageViewPage pageView = null;
            foreach (RadPageViewPage page in tabMain.Pages)
            {
                if (page.Tag == tabTag)
                {
                    pageView = page;
                    break;
                }
            }

            if (pageView != null)
            {
                tabMain.SelectedPage = pageView;
            }
            else
            {
                RadPageViewPage newPage = new RadPageViewPage()
                {
                    Tag = tabTag,
                    Text = control.Text
                };

                control.BackColor = System.Drawing.SystemColors.Control;
                control.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                control.Dock = DockStyle.Fill;
                control.TopLevel = false;
                control.Parent = newPage;

                tabMain.Pages.Add(newPage);
                tabMain.SelectedPage = newPage;

            }
        }
    }
}
