using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HS.UI.Base;

namespace HS.UI.Forms.Config
{
    public partial class frmUser : MdiChildForm
    {
        public frmUser()
        {
            InitializeComponent();

            this.Tag = "frmUser";
            this.IsUniqueForm = true;

            this.ToolbarItems.AddRange(new List<ToolbarItem>() 
            { 
                ToolbarItem.Add,
                ToolbarItem.Edit,
                ToolbarItem.Seperator,
                ToolbarItem.Exit
            });
        }
        
    }
}
