using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace QLNS.Main.BaseControl
{
    public partial class ControlBase : UserControl
    {
        public string PageCaption;

        public ControlBase()
        {
            InitializeComponent();
        }
    }
}
