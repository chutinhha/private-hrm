using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HS.UI.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace( txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Program.MainForm.ShowDialog();

            this.Close();
        }
    }
}
