using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HS.UI.Common;

namespace HS.UI.Forms.Systems
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            string imgLogoPath = System.IO.Path.Combine(Application.StartupPath, "Resources\\Images\\hr-logo.jpg");
            string imgLoginPath = System.IO.Path.Combine(Application.StartupPath, "Resources\\Images\\group.png");

            if (System.IO.File.Exists(imgLogoPath))
            {
                Image imgLogo = Image.FromFile(imgLogoPath);
                imgPlaceLogo.Image = imgLogo;
            }

            if (System.IO.File.Exists(imgLoginPath))
            {
                Image imgLogin = Image.FromFile(imgLoginPath);
                imgPlaceLogin.Image = imgLogin;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin đăng nhập.", Variables.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var menuItems = Common.Methods.LoadMenu();

            Common.Variables.MainForm.BuildMenu(menuItems);

            this.Hide();

            Common.Variables.MainForm.ShowDialog();

            if (Common.Variables.IsRelogin)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
