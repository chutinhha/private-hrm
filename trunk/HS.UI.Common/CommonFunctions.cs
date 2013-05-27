using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.UI.Base
{
    public static class CommonFunctions
    {
        #region String

        public static string MD5(this string input)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
        }

        #endregion

        #region Int

        #endregion

        #region DateTime

        #endregion

        #region Other

        #endregion
    }
}
