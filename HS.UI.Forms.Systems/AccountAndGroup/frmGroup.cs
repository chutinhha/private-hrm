using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HS.UI.Base;

namespace HS.UI.Forms.Systems.Config
{
    public partial class frmGroup : Base.MdiChildForm
    {
        public frmGroup()
        {
            InitializeComponent();

            this.Tag = "frmGroup";
            this.IsUniqueForm = true;

            this.ToolbarItems.AddRange(new List<ToolbarItem>() 
            { 
                ToolbarItem.Add,
                ToolbarItem.Edit,
                ToolbarItem.Seperator,
                ToolbarItem.Active,
                ToolbarItem.InActive,
                ToolbarItem.Seperator,
                ToolbarItem.Exit
            });
        }
    }
}
