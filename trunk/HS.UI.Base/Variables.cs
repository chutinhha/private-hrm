using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.UI.Base
{
    public static class Variables
    {
        public static MainMdiForms _mainForm;
        public static MainMdiForms MainForm
        {
            get
            {
                if (_mainForm == null)
                {
                    _mainForm = new Base.MainMdiForms();
                }

                return _mainForm;
            }
        }


        public static bool IsRelogin
        {
            get;
            set;
        }


        public static string ApplicationName { get; set; }
    }
}
