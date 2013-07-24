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

namespace HS.UI.Forms.Systems.AccountAndGroup
{
    public partial class frmAccountAndGroup : MdiChildForm
    {
        private string typeSelect = "";
        private SystemWraper db = new SystemWraper();

        public frmAccountAndGroup()
        {
            InitializeComponent();

            this.Tag = "frmAccountAndGroup";
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

            trvType.AfterSelect += trvType_AfterSelect;

            #endregion
        }

        private void trvType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lstItems.Items.Clear();

            typeSelect = e.Node.Name;

            if (e.Node.Name == "nodeAccount")
            {
                LoadAccountList();
            }
            else if (e.Node.Name == "nodeGroup")
            {
                LoadGroupList();
            }
        }

        private void LoadGroupList()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("[LoadGroupList]", ex);
            }
        }

        private void LoadAccountList()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Methods.ShowError("[LoadAccountList]", ex);
            }
        }

        private void frmAccountAndGroup_Load(object sender, EventArgs e)
        {
            trvType.ExpandAll();
        }
        
    }
}
