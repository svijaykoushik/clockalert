using System;
using System.Collections.Generic;
using System.Text;

namespace Clock_Alert
{
    class ErrorLog
    {
        static string header, message, footer, path, folderpath;
        public static string logError(Exception ex)
        {
            header = DateTime.Now.ToString() + "\n\n";
            message = ex.Message;
            footer = "\n\n\n";
            folderpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path=folderpath+ @"\ClockALert Log" + DateTime.Now.ToShortDateString()+".txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true);
            try
            {
                sw.WriteLine(header);
                sw.WriteLine(message);
                sw.WriteLine(footer);
                return "A serious error occured check error log at" + path;
            }
            catch (Exception exp)
            {
                return exp.ToString();
            }
        }
    }
}
