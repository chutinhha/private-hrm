using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HS.UI.Forms
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {

        public static OleDbConnection Connection;
        public static MainMdiForms MainForm;
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Connection =  HS.DataAccess.ConnectionBase.Connection;
            if (Connection == null)
            {
                MessageBox.Show("Không tồn tại file CSDL. Xin hãy kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainMdiForms();
            Application.Run(MainForm);
        }
    }
}
