using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HS.UI.Forms.Systems
{
    public partial class SplashForm : Form
    {
        private BackgroundWorker workerLoadConfig;

        public SplashForm()
        {
            InitializeComponent();

            workerLoadConfig = new BackgroundWorker() { WorkerReportsProgress = true };

            workerLoadConfig.DoWork += workerLoadConfig_DoWork;
            workerLoadConfig.ProgressChanged += workerLoadConfig_ProgressChanged;
            workerLoadConfig.RunWorkerCompleted += workerLoadConfig_RunWorkerCompleted;
        }

        void workerLoadConfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        void workerLoadConfig_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = string.Format("Loading ({0}%)...", e.ProgressPercentage);
        }

        void workerLoadConfig_DoWork(object sender, DoWorkEventArgs e)
        {
            var appSettings = System.Configuration.ConfigurationManager.AppSettings;

            Common.Variables.ApplicationName = appSettings["AppName"];
            Common.Variables.IsDebug = appSettings["Debug"].ToString() == "1";
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            workerLoadConfig.RunWorkerAsync();
        }
    }
}
