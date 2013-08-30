using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

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

            ThemeResolutionService.ApplicationThemeName = "Windows8";
        }

        public static string ConnectionString = "";
        public static string Username = "";
        public static bool IsLogin = false;
    }
}
