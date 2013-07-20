using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.UI.Common
{
    public static class Variables
    {
        private const string CONNECTION_STRING = "Data Source={0};Initial Catalog={1};User Id={2};Password={3};";

        public static Base.MainMdiForms MainForm
        {
            get
            {
                return Base.Variables.MainForm;
            }
        }

        private static string _connectionString = "";
        public static string ConnectionString
        {
            get
            {
                if (_connectionString == "")
                {
                    var appSettings = System.Configuration.ConfigurationManager.AppSettings;

                    _connectionString = string.Format(CONNECTION_STRING, appSettings["DB_Server"], appSettings["DB_Database"], appSettings["DB_User"], appSettings["DB_Pass"]);
                }

                return _connectionString;
            }
            set
            {
                if (_connectionString != value)
                {
                    _connectionString = value;
                }
            }
        }

        public static bool IsRelogin
        {
            get { return Base.Variables.IsRelogin; }
            set { Base.Variables.IsRelogin = value; }
        }

        public static string ApplicationName
        {
            get { return Base.Variables.ApplicationName; }
            set
            {
                Base.Variables.ApplicationName = value;
            }
        }
    }
}
