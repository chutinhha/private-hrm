using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Web;

namespace HS.UI.Common
{
    public class ErrorLog
    {
        public static void Log(string functionName, string errorMsg)
        {
            try
            {
                string logFileName = Path.Combine(Application.StartupPath, string.Format("Log_{0}_{1}_{2}.txt", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                StreamWriter sw;
                if (File.Exists(logFileName))
                {
                    sw = File.AppendText(logFileName);
                }
                else
                {
                    sw = File.CreateText(logFileName);
                }

                sw.WriteLine(string.Format("------- {0} -------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                sw.WriteLine("#" + functionName);
                sw.WriteLine("-- ");
                sw.WriteLine(errorMsg);

                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("#Log Error: " + ex.Message);
            }
        }

        public static void WebLog(string functionName, string errorMsg)
        {
            try
            {
                string logFileName = HttpContext.Current.Server.MapPath(string.Format("~/Log_{0}_{1}_{2}.txt", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                StreamWriter sw;
                if (File.Exists(logFileName))
                {
                    sw = File.AppendText(logFileName);
                }
                else
                {
                    sw = File.CreateText(logFileName);
                }

                sw.WriteLine(string.Format("------- {0} -------", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                sw.WriteLine("#" + functionName);
                sw.WriteLine("-- ");
                sw.WriteLine(errorMsg);

                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("#Log Error: " + ex.Message);
            }
        }
    }
}
