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

        public CrashReporterUI(Exception exceptionObject)
        {
            InitializeComponent();
            exception = exceptionObject;
            reporter = new CrashReporter();            
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Hide();
            reporter.getException(exception);
            reporter.createReport();
            reporter.sendReport();
            Close();
            Application.Exit();
        }

        private void dontSendButton_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void CrashReporterUI_Load(object sender, EventArgs e)
        {
            message = ErrorLog.logError(exception);
            textBox1.Text = message;
        }
    }
}
