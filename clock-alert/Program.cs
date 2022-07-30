﻿using ClockAlert.Modules;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ClockAlert
{
    internal static class Program
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            App app = new App();

            /*
             * If the Mutual exclusion object was succesfully created
             * then we start the application
             * If not
             * It means that the mutex object is owned by the first instance
             * and a second instance trying to start the application.
             * So we show a message that the application is already running.
             */
            if (firstInstance)
            {
                Logger.LogAsync(LogLevel.Info, "Application started");
                Application.Run(app);
                Logger.LogAsync(LogLevel.Info, "Application exited");
            }
            else
            {
                app.ShowAlreadyRunningNotification();
            }
        }
    }
}
