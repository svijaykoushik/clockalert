using System;
using System.Threading;
using System.Xml;

namespace ClockAlert.Modules
{
    internal class AppUpdate
    {
        private Version newVersion, currentVersion;
        private XmlTextReader reader;
        private string url, elementName, xmlUrl;
        private Thread updateCheckerThread, autoUpdateCheckerTherad;

        public AppUpdate()
        {
            newVersion = null;
            currentVersion = null;
            reader = null;
            url = string.Empty;
            elementName = string.Empty;
            xmlUrl = string.Empty;
            updateCheckerThread = null;
        }

        /// <summary>
        /// Gets the current version available for download.
        /// </summary>
        private void getVersion()
        {
            xmlUrl = "https://clockalert.sourceforge.io/version.xml";
            try
            {
                reader = new XmlTextReader(xmlUrl);
                reader.MoveToContent();
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "clockalert")
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            if (reader.NodeType == XmlNodeType.Text && reader.HasValue)
                            {
                                switch (elementName)
                                {
                                    case "version":
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        url = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                    throw new XmlException("Unable to parse the XML resource. Please check for the correct XML resource");
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response == null)
                    System.Windows.Forms.MessageBox.Show("Update operation has been terminated abruptly because Clock Alert could not communicate with the server", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                else
                {
                    if (ex.Status == System.Net.WebExceptionStatus.ProtocolError)
                    {
                        if (((System.Net.HttpWebResponse)ex.Response).StatusCode == System.Net.HttpStatusCode.NotFound)
                            System.Windows.Forms.MessageBox.Show("Update operation has been terminated abruptly because Clock Alert could not find the requested resource\n Please check for updates from http://www.clockalert.co.nr", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        else
                            System.Windows.Forms.MessageBox.Show("Update operation has been terminated abruptly because an error occured while trying to communicate with the server", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    else
                        System.Windows.Forms.MessageBox.Show("Update operation has been terminated abruptly because an unknown error occured while trying to communicate with the server\nStatus:" + ((System.Net.HttpWebResponse)ex.Response).StatusCode + "\n Description" + ((System.Net.HttpWebResponse)ex.Response).StatusDescription, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                newVersion = null;
                url = string.Empty;
                ErrorLog.logError(ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                System.Windows.Forms.MessageBox.Show("Update operation has been terminated abruptly because Clock Alert could not find the requested resource\n Please check for updates from http://www.clockalert.co.nr", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                ErrorLog.logError(ex);
                newVersion = null;
                url = string.Empty;
            }
            catch (XmlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Update operation has been terminated abruptly because Clock Alert could not parse the requested resource\n Please check for updates from http://www.clockalert.co.nr", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                ErrorLog.logError(ex);
                newVersion = null;
                url = string.Empty;
            }
            catch (Exception ex)
            {
                CrashReporterUI reporter = new CrashReporterUI(ex);
                reporter.ShowDialog();
                ErrorLog.logError(ex);
                newVersion = null;
                url = string.Empty;
            }
        }

        /// <summary>
        /// Checks for updates and informs if there is an update. This method is only used
        /// with manual update check operation.
        /// </summary>
        private void updateChecker()
        {
            System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(App));
            if (InternetConnection.checkConntection())
            {
                getVersion();
                if (newVersion != null)
                {
                    currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                    if (currentVersion.CompareTo(newVersion) < 0)
                    {
                        if (System.Windows.Forms.DialogResult.Yes == System.Windows.Forms.MessageBox.Show(resourceManager.GetString("updateAvailable"), resourceManager.GetString("updateAvailableTitle"), System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question))
                        {
                            System.Diagnostics.Process.Start(url);
                        }
                    }
                    else
                        System.Windows.Forms.MessageBox.Show(resourceManager.GetString("updateNotAvailable"), resourceManager.GetString("updateNotAvailableTitle"), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (System.Windows.Forms.DialogResult.Retry == System.Windows.Forms.MessageBox.Show(resourceManager.GetString("noInternetMessage"), resourceManager.GetString("noInternetTitle"), System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Exclamation))
                {
                    updateChecker();
                }
                else
                {
                    InternetConnection.InternettConnectionStateCanged += InternetConnection_InternettConnectionStateCanged;
                }
            }
        }

        /// <summary>
        /// Event to notify when computer gets connected to the internet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InternetConnection_InternettConnectionStateCanged(object sender, InternetConnectionStateChangedEventArgs e)
        {
            if (e.IsConnected)
            {
                checkForUpdate();
                InternetConnection.InternettConnectionStateCanged -= InternetConnection_InternettConnectionStateCanged;
            }
        }

        /// <summary>
        /// Checks for updates for the application and informs weather or not an update is
        /// available.
        /// </summary>
        public void checkForUpdate()
        {
            /* Disabling the inbuilt update check
             * new updates will be checked mannually by visiting website
             */   
            /*updateCheckerThread = new Thread(this.updateChecker);
            updateCheckerThread.Name = "Clock alert update checker";
            updateCheckerThread.Start();*/

            /*
             * Opens the default browser to show the latest version of clock alert
             */

            currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string message = "To get the latest version of Clock Alert please visit the project webpage. Would you like to visit the project page?\n" + Properties.Settings.Default.ProjectHome + "\n Current version is " + currentVersion;
            if (System.Windows.Forms.DialogResult.Yes == System.Windows.Forms.MessageBox.Show(message, "Visit Project page to update the app", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question))
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.ProjectReleaseURL);
            }
        }

        /// <summary>
        /// Checks for updates and informs if there is an update. This method is only used
        /// with auto update check operation.
        /// </summary>
        private void autoUpdateCheck()
        {
            if (InternetConnection.checkConntection())
            {
                getVersion();
                if (newVersion != null)
                {
                    System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(App));
                    currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                    if (currentVersion.CompareTo(newVersion) < 0)
                    {
                        if (System.Windows.Forms.DialogResult.Yes == System.Windows.Forms.MessageBox.Show(resources.GetString("updateAvailable"), resources.GetString("updateAvailableTitle"), System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question))
                        {
                            System.Diagnostics.Process.Start(url);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Performs update check periodically. Call this method only on a periodic basis.
        /// Do not use this method for manual update checking.
        /// </summary>
        public void autoUpdateChecker()
        {
            autoUpdateCheckerTherad = new Thread(autoUpdateCheck);
            autoUpdateCheckerTherad.Name = "Clock alert auto updater";
            autoUpdateCheckerTherad.Start();
        }
    }
}
