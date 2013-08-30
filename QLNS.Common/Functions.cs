using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLNS.Common
{
    public static class Functions
    {
        public static string MD5(this string input)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
        }
    }
}
