using HS.UI.Base;
using System.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                var menuFiles = Directory.GetFiles(Path.Combine( Application.StartupPath, "Menu"), "*.xml");

                if(menuFiles.Length > 0)
                {
                    foreach(string filePath in menuFiles)
                    {
                        dts.ReadXml(filePath);

                        if(retTable == null)
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
                ErrorLog.Log("#LoadMenu", ex.Message);
                return new DataTable();
            }

        }

        public static void ShowError(string functionName, Exception ex)
        {
            Base.Methods.ShowError(functionName, ex);
        }
    }
}
