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
using QLNS.Data.DataAccessLayer;

namespace QLNS.Main
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {
        private bool isShowThietLap = true;
        private bool isConnectionOK = false;

        private const string CONNECTION_STRING = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";

        public frmLogin()
        {
            InitializeComponent();

            ShowHideSetup();

            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light";
            //ThemeResolutionService.ApplicationThemeName = "ControlDefault";
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            ShowHideSetup();
        }

        private void ShowHideSetup()
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
                ShowError("Không thể kết nối tới Máy chủ Dữ liệu.\nNguyên nhân:\n - Chưa thiết lập Thông số kết nối tới CSDL\n - Thông số kết nối không chính xác. \n\n Hãy thiết lập lại thông số.");
                return;
            }
        }

        private void ShowError(string message)
        {
            RadMessageBox.Show(message, this.Text, MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string
                    serverIP = txtDBServer.Text,
                    databaseName = txtDBName.Text,
                    databaseUser = txtDBUser.Text,
                    databasePassword = txtDBPassword.Text;


                if (serverIP == "" || databaseName == "" || databaseUser == "" || databasePassword == "")
                {
                    ShowError("Bạn chưa nhập đầy đủ thông tin cần thiết để thiết lập kết nối tới Máy chủ dữ liệu.\nHãy thiết lập lại.");
                    return;
                }

                Program.ConnectionString = string.Format(CONNECTION_STRING, serverIP, databaseName, databaseUser, databasePassword);

                isConnectionOK = false;
                TestConnection();

                if (!isConnectionOK)
                {
                    ShowError("Không thể kết nối tới Máy chủ Dữ liệu.\n\n Hãy thiết lập lại thông số.");
                }
                else
                {
                    RadMessageBox.Show("Thông số thiết lập chính xác.\nHãy Lưu lại thông số này.", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionFile = Path.Combine(Application.StartupPath, "Data\\Connection.txt");

                if (File.Exists(connectionFile))
                {
                    File.Delete(connectionFile);
                }

                StreamWriter sw = File.CreateText(connectionFile);

                sw.Write(Program.ConnectionString);

                sw.Close();

                RadMessageBox.Show("Đã lưu thông số kết nối thành công.", this.Text, MessageBoxButtons.OK, RadMessageIcon.Info);

                txtTaiKhoan.Enabled =
                    txtMatKhau.Enabled =
                    btnLogin.Enabled = true;

                ShowHideSetup();
                txtTaiKhoan.Focus();
            }
            catch (Exception ex)
            {
                ShowError("Đã có lỗi:\n" + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanManager db = new TaiKhoanManager(Program.ConnectionString);

                string error = "";
                if (db.Login(txtTaiKhoan.Text, txtMatKhau.Text, ref error))
                {
                    Program.Username = txtTaiKhoan.Text;

                    frmMain fMain = new frmMain();
                    this.Hide();
                    fMain.ShowDialog();

                    if (Program.IsLogin)
                    {
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    ShowError("Đã có lỗi:\n" + error + "\nBạn hãy thử lại.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
