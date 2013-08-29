using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QLNS.Main
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {
        private bool isShowThietLap = true;
        private bool isConnectionOK = false;

        public frmLogin()
        {
            InitializeComponent();

            isShowThietLap = !isShowThietLap;
            grThietLap.Visible = isShowThietLap;
            if (isShowThietLap)
            {
                this.Height += (grThietLap.Height + 5);
            }
            else
            {
                this.Height -= (grThietLap.Height + 5);
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            isShowThietLap = !isShowThietLap;
            grThietLap.Visible = isShowThietLap;
            if (isShowThietLap)
            {
                this.Height += (grThietLap.Height + 5);
            }
            else
            {
                this.Height -= (grThietLap.Height + 5);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string connectionFile = Path.Combine(Application.StartupPath, "Data\\Connection.txt");
            if (File.Exists(connectionFile))
            {
                StreamReader sr = File.OpenText(connectionFile);

                Program.ConnectionString = sr.ReadToEnd();
                TestConnection();
            }

            if (!isConnectionOK)
            {
                txtTaiKhoan.Enabled =
                    txtMatKhau.Enabled =
                    btnLogin.Enabled = false;
                RadMessageBox.Show("Không thể kết nối tới Máy chủ Dữ liệu.\nNguyên nhân:\n - Chưa thiết lập Thông số kết nối tới CSDL\n - Thông số kết nối không chính xác. \n\n Hãy thiết lập lại thông số");
                return;
            }
        }

        private void TestConnection()
        {
            if (Program.ConnectionString == "") return;
            SqlConnection _testConnection = new SqlConnection(Program.ConnectionString);

            try
            {
                _testConnection.Open();
                _testConnection.Close();

                isConnectionOK = true;
            }
            catch (SqlException ex)
            {
                isConnectionOK = false;
            }
        }


    }
}
