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
using System.Windows.Forms;
using System.Diagnostics;

namespace Clock_Alert
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] runningProcess = Process.GetProcessesByName(currentProcess.ProcessName);
            int numberOfProcess = runningProcess.Length;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            if (numberOfProcess == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (Startup app = new Startup())
                {
                    app.startApp();
                    Application.Run();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("I'm here already!", "Clock Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            CrashReporterUI reportWindow = new CrashReporterUI(ex);
            reportWindow.ShowDialog();
            Application.Exit();
        }
        
    }
}
