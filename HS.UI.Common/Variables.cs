using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace HS.UI.Common
{
    public static class Variables
    {
        public static Base.MainMdiForms MainForm
        {
            get
            {
                return Base.Variables.MainForm;
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

        public static bool IsDebug
        {
            get { return Base.Variables.IsDebug; }
            set
            {
                Base.Variables.IsDebug = value;
            }
        }

        public static string ServiceURL;

    }
}
