using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HS.UI.Forms.Systems.Config
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();

            this.Load += frmConfiguration_Load;
        }

        void frmConfiguration_Load(object sender, EventArgs e)
        {
            ctrlDanhMuc1.InitControl();
        }
    }
}
