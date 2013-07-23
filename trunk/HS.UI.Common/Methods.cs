using HS.UI.Base;
using System.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace HS.UI.Common
{
    public static class Methods
    {
        public static DataTable LoadMenu()
        {
            DataSet dts = new DataSet();
            DataTable retTable = null;

            try
            {
                var menuFiles = Directory.GetFiles(Path.Combine(Application.StartupPath, "Menu"), "*.xml");

                if (menuFiles.Length > 0)
                {
                    foreach (string filePath in menuFiles)
                    {
                        dts.ReadXml(filePath);

                        if (retTable == null)
                        {
                            retTable = dts.Tables[0].Clone();
                        }

                        foreach (DataRow row in dts.Tables[0].Rows)
                        {
                            retTable.ImportRow(row);
                        }
                    }
                }
                else
                {
                    retTable = new DataTable();
                }

                return retTable;
            }
            catch (Exception ex)
            {
                ShowError("#LoadMenu", ex);
                return new DataTable();
            }

        }

        public static void ShowError(string functionName, Exception ex)
        {
            Base.Methods.ShowError(functionName, ex);
        }

        public static void Alert(string msg)
        {
            MessageBox.Show(msg, Variables.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirm(string msg)
        {
            return MessageBox.Show(msg, Variables.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

    }
}
