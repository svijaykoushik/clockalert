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
using System.Threading;
//using System.Diagnostics;

namespace Clock_Alert
{
    static class Program
    {
        /// <summary>
        /// The named mutual exclusion object that is
        /// owned by the first instance of the app that is created.
        /// It holds the first application instance (process) 
        /// and prevents the app from running in a new instace (process).
        /// </summary>
        static Mutex mutExcl;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool firstInstance = false;
            /*
             * New mutual exclusion object is created with
             * the current thread as owner.
             * It is given the same name as the app.
             * If the object was succesfully created with the current thread as owner,
             * firstInstance variable is set to true.
             */
            mutExcl = new Mutex(true, Application.ProductName.ToString(), out firstInstance);
            /*
             * If the Mutual exclusion object was succesfully created
             * then we start the application
             * If not
             * It means that the mutex object is owned by the first instance
             * and a second instance trying to start the application.
             * So we show a message that the application is already running.
             */ 
            if(firstInstance)
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
                System.Windows.Forms.MessageBox.Show("Clock Alert is already running!", "Clock Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            /*
             * Comenting this code because it sometimes prevent
             * the app from restarting when the settings are
             * changed by the user. and the app closes.
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
            }*/
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
