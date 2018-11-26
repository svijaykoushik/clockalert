/***********************************************************************************
This file is part of Clock Alert.

    Clock Alert is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 3 as published by
    the Free Software Foundation.

    Clock Alert is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Clock Alert.  If not, see <http://www.gnu.org/licenses/>.
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Clock_Alert
{
    public partial class CrashReporterUI : Form
    {
        private Exception exception;
        private CrashReporter reporter;
        private string message;
        private readonly ComponentResourceManager _resource;

        public CrashReporterUI(Exception exceptionObject)
        {
            InitializeComponent();
            exception = exceptionObject;
            reporter = new CrashReporter();
            _resource= new ComponentResourceManager(typeof(CrashReporterUI));
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
            if (InternetConnection.checkConntection())
            { 
                reporter.sendWebReport(); 
            }
            else
            {
                if (System.Windows.Forms.DialogResult.Retry == System.Windows.Forms.MessageBox.Show(Contents.noInternetMessage, Contents.noInternetTitle, System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Exclamation))
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
