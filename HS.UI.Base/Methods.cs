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
            HS.Common.ErrorLog.Log(functionName, ex.Message);

            if (Variables.IsDebug)
            {
                new ErrorForm(functionName, ex).ShowDialog();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Bạn hãy thử lại.", Variables.ApplicationName,  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
