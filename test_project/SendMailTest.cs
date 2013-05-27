using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HS.UI.Common;

namespace test_project
{
    public partial class SendMailTest : HS.UI.Base.MdiChildForm
    {
        public SendMailTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailService.MailServicePortTypeClient client = new MailService.MailServicePortTypeClient();

            string response = client.sendMail(string.Format("solo.vn{0}{1}", "5b9b3058e1cc42508ded062a8cfa80b4", "contact@solo.vn").MD5().ToLower(), "contact@solo.vn", "test email", "test", "bangdinhvan@solo.vn", "solo.vn", "", "", "");

            MessageBox.Show(response);
        }
    }
}
