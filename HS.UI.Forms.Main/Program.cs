using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using HS.UI.Common;
using HS.UI.Forms.Systems;

namespace HS.UI.Forms.Main
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {

        public static SqlConnection Connection;
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Connection =  HS.DataAccess.ConnectionBase.Connection;
            //if (Connection == null)
            //{
            //    MessageBox.Show("Không tồn tại file CSDL. Xin hãy kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SplashForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi khi chạy chương trình. Hãy thử khởi động lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HS.Common.ErrorLog.Log("System Error: ", ex.ToString());
            }
        }
    }
}
