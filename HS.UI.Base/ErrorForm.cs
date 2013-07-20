using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HS.UI.Base
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }
        public ErrorForm(string functionName, Exception ex)
        {
            InitializeComponent();

            this.Text = string.Format("Lỗi - {0}", functionName);
            txtErrorDetail.Text = ex.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
