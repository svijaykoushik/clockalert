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
using System.Web;
using System.Reflection;

namespace Clock_Alert
{
    class CrashReporter:ICrashReporter
    {
        /// <summary>
        /// Version of Windows Operating system.
        /// </summary>
        private string winVer;

        /// <summary>
        /// Version of Common Language Runtime (CLR).
        /// </summary>
        private string CLRVer;

        /// <summary>
        /// Type of exception occured.
        /// </summary>
        private string exceptionType;
        
        /// <summary>
        /// Message of the exception.
        /// </summary>
        private string exceptionMessage;
        
        /// <summary>
        /// exception's stacktrace.
        /// </summary>
        private string exceptionStackTrace;

        /// <summary>
        /// Source causing the exception.
        /// </summary>
        private string exceptionSource;

        /// <summary>
        /// The Exception's inner exception.
        /// </summary>
        private string innerException;

        /// <summary>
        /// A report containing exception and its details.
        /// </summary>
        private string exceptionReport;

        /// <summary>
        /// name of the application.
        /// </summary>
        private string applicationName;

        /// <summary>
        /// Version of the application.
        /// </summary>
        private string applicationVersion;

        /// <summary>
        /// Creates instance of the crash reporter.
        /// </summary>
        public CrashReporter()
        {
            winVer = Environment.OSVersion.VersionString;
            CLRVer = Environment.Version.ToString();
            exceptionMessage = string.Empty;
            exceptionSource = string.Empty;
            exceptionStackTrace = string.Empty;
            exceptionType = string.Empty;
            innerException = string.Empty;
            applicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        
        /// <summary>
        /// Gets the unhandled exception that has occured.
        /// </summary>
        /// <param name="exception">The exception object of the unhandled exception.</param>
        public void getException(Exception exception)
        {
            exceptionMessage = exception.Message;
            exceptionSource = exception.Source;
            exceptionStackTrace = exception.StackTrace;
            exceptionType = exception.GetType().ToString();
            /*if (exception.InnerException.ToString() != null || exception.InnerException.ToString() != string.Empty)
            {
                innerException = exception.InnerException.ToString();
            }
            else
            {
                innerException = string.Empty;
            }*/
            var mainAssembly = Assembly.GetEntryAssembly();
            string appTitle = null;
            var attributes = mainAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), true);
            if (attributes.Length > 0)
            {
                appTitle = ((AssemblyTitleAttribute)attributes[0]).Title;
            }
            applicationName = !string.IsNullOrEmpty(appTitle) ? appTitle : mainAssembly.GetName().Name;

            /*createReport();
            sendReport();*/
        }

        /// <summary>
        /// Creates a html report from the exception occured.
        /// </summary>
        public void createReport()
        {
            exceptionReport = string.Format(@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                    <html xmlns=""http://www.w3.org/1999/xhtml"">
                    <head>
                    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
                    <title>{0} {1} Crash Report</title>
                    <style type=""text/css"">
                    .message {{
                    padding-top:5px;
                    padding-bottom:5px;
                    padding-right:20px;
                    padding-left:20px;
                    font-family:'Segoe UI';
                    font-size:14px;
                    }}
                    .content
                    {{
                    border-style:dashed;
                    border-width:1px;
                    }}
                    .title
                    {{
                    padding-top:1px;
                    padding-bottom:1px;
                    padding-right:10px;
                    padding-left:10px;
                    font-family:'Segoe UI';
                    font-size:20px;
                    }}
                    </style>
                    </head>
                    <body>
                    <div class=""title"" style=""background-color: #FFCC99"">
                    <h2>{0} {1} Crash Report</h2>
                    </div>
                    <br/>
                    <div class=""content"">
                    <div class=""title"" style=""background-color: #66CCFF;"">
                    <h3>Windows Version</h3>
                    </div>
                    <div class=""message"">
                    <p>{2}</p>
                    </div>
                    </div>
                    <br/>
                    <div class=""content"">
                    <div class=""title"" style=""background-color: #66CCFF;"">
                    <h3>CLR Version</h3>
                    </div>
                    <div class=""message"">
                    <p>{3}</p>
                    </div>
                    </div>
                    <br/>    
                    <div class=""content"">
                    <div class=""title"" style=""background-color: #66CCFF;"">
                    <h3>Exception</h3>
                    </div>
                    <div class=""message"">
                    <br/>
                        <div class=""content"">
                        <div class=""title"" style=""background-color: #66CCFF;"">
                        <h3>Exception Type</h3>
                        </div>
                        <div class=""message"">
                        <p>{4}</p>
                        </div>
                        </div><br/>
                        <div class=""content"">
                        <div class=""title"" style=""background-color: #66CCFF;"">
                        <h3>Error Message</h3>
                        </div>
                        <div class=""message"">
                        <p>{5}</p>
                        </div>
                        </div><br/>
                        <div class=""content"">
                        <div class=""title"" style=""background-color: #66CCFF;"">
                        <h3>Source</h3>
                        </div>
                        <div class=""message"">
                        <p>{6}</p>
                        </div>
                        </div><br/>
                        <div class=""content"">
                        <div class=""title"" style=""background-color: #66CCFF;"">
                        <h3>Stack Trace</h3>
                        </div>
                        <div class=""message"">
                        <p>{7}</p>
                        </div>
                        </div>""
                    </div>
                    </div>", HttpUtility.HtmlEncode(applicationName),
                              HttpUtility.HtmlEncode(applicationVersion),
                              HttpUtility.HtmlEncode(winVer),
                              HttpUtility.HtmlEncode(CLRVer),
                              HttpUtility.HtmlEncode(exceptionType),
                              HttpUtility.HtmlEncode(exceptionMessage),
                              HttpUtility.HtmlEncode(exceptionSource),
                              HttpUtility.HtmlEncode(exceptionStackTrace).Replace("\r\n", "<br/>"));
        }

        /// <summary>
        /// Sends the crash report to the developer
        /// </summary>
        public void sendReport()
        {
            Email mail = new Email();
            mail.configure("smtp.gmail.com", "crashreporterforclockalert", "123clockalert456", true, 587);
            if (exceptionReport != string.Empty)
            {
                mail.setFields("crashreporterforclockalert@gmail.com", "moon01man@gmail.com", "Crash report " + applicationName + " " + applicationVersion, exceptionReport);
                try
                {
                    //throw new Exception("Error Test");
                    mail.sendMail();
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.ToString());
                    System.Windows.Forms.MessageBox.Show(Contents.crashReportErrMsgP1 + '\"' + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + System.IO.Path.DirectorySeparatorChar + "Moon01Man" + System.IO.Path.DirectorySeparatorChar + "Clock Alert" + System.IO.Path.DirectorySeparatorChar + '\"' + Contents.crashReportErrMsgP2);
                    ErrorLog.logError(ex);
                }
            }
            else
                throw new Exception("Crash report cannot be empty. please create a report using the createReport method.");
        }
    }
}
