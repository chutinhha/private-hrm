using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace QLNS.Main
{
    public partial class frmMain : RadForm
    {
        public frmMain()
        {
            InitializeComponent();

            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light";
            //ThemeResolutionService.ApplicationThemeName = "ControlDefault";
            lblLoginName.Text = string.Format("Tài khoản: {0}", Program.Username);
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
            BaseControl.ControlBase control = null;

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

        public void AddPageToTab(string tabTag, BaseControl.ControlBase control)
        {
            if (control == null) return;
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
                    Text = control.PageCaption
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

        public void SetStatus(string message)
        {
            lblMainStatus.Text = message;
        }

        public void CloseCurrentTab() {
            tabMain.Pages.Remove(tabMain.SelectedPage);

            tabMain.SelectedPage = pageMain;
        }
    }
}
