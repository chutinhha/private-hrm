using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HS.UI.Base
{
    public static class Methods
    {
        public static void ShowError(string functionName, Exception ex)
        {
            ErrorLog.Log(functionName, ex.Message);

            new ErrorForm(functionName, ex).ShowDialog();
        }
    }
}
