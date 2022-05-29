using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClockAlert.Modules;

namespace ClockAlert
{
    public partial class CrashReporterUI : Form
    {
        private Exception exception;
        private CrashReporter reporter;
        private string message;
        private readonly ComponentResourceManager _resource;

        public CrashReporterUI(Exception exceptionObject)
        {
            this.InitializeComponent();
            exception = exceptionObject;
            reporter = new CrashReporter();
            _resource = new ComponentResourceManager(typeof(CrashReporterUI));
            this.Text = _resource.GetString("TitleText");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            /* Commenting this until
             * a new api is developed to
             * report the crash
            Hide();
            reporter.getException(exception);
            //reporter.createReport();
            sendReport();
            Close();
            Application.Exit();*/
            System.Diagnostics.Process.Start(Properties.Settings.Default.ProjectDiscussionURL);
            Close();
            Application.Exit();
        }

        private void sendReport()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(App));
            if (InternetConnection.checkConntection())
            {
                reporter.sendWebReport();
            }
            else
            {
                if (System.Windows.Forms.DialogResult.Retry == System.Windows.Forms.MessageBox.Show(resources.GetString("noInternetMessage"), resources.GetString("noInternetTitle"), System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Exclamation))
                {
                    sendReport();
                }
                else
                {
                    InternetConnection.InternettConnectionStateCanged += InternetConnection_InternettConnectionStateCanged;
                }
            }
        }

        void InternetConnection_InternettConnectionStateCanged(object sender, InternetConnectionStateChangedEventArgs e)
        {
            sendReport();
            InternetConnection.InternettConnectionStateCanged -= InternetConnection_InternettConnectionStateCanged;
        }

        private void dontSendButton_Click(object sender, EventArgs e)
        {
            Close();
            Application.Restart();
        }

        private void CrashReporterUI_Load(object sender, EventArgs e)
        {
            message = ErrorLog.logError(exception);
            logURLText.Text = message;
        }

        private void copyLocationButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(logURLText.Text);
        }
    }
}
