using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLNS.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        public static string ConnectionString = "";
        public static string Username = "";
    }
}
