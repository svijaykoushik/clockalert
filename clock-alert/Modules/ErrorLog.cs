using System;

namespace ClockAlert.Modules
{
    internal class ErrorLog
    {
        /// <summary>
        /// Parts of the log message.
        /// </summary>
        static string header, message, footer, path, folderpath;

        /// <summary>
        /// Logs the error or exception to a file.
        /// </summary>
        /// <param name="ex">The Exception object of the Exception thrown for logging.</param>
        /// <returns></returns>
        public static string logError(Exception ex)
        {
            header = DateTime.Now.ToString() + "\r\n";
            message = "Source:\r\n\n" + ex.Source + "\r\n\nMessage:\r\n\n" + ex.Message + "\r\n\nStack Trace:\r\n\n" + ex.StackTrace;
            footer = "\n\n\n";
            folderpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + System.IO.Path.DirectorySeparatorChar + "Moon01Man" + System.IO.Path.DirectorySeparatorChar + "Clock Alert" + System.IO.Path.DirectorySeparatorChar;
            if (!System.IO.Directory.Exists(folderpath))
            {
                System.IO.Directory.CreateDirectory(folderpath);
            }
            path = folderpath + "ClockALert Log" + DateTime.Now.ToShortDateString() + ".txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true);
            try
            {
                sw.WriteLine(header);
                sw.WriteLine(message);
                sw.WriteLine(footer);
                sw.Close();
                return path;
            }
            catch (Exception exp)
            {
                return exp.ToString();
            }
        }
    }
}
