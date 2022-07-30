using System;
using System.IO;
using System.Threading;
using System.Xml;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClockAlert.Helpers;
using System.Xml.Serialization;
using ClockAlert.Exceptions;

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
            url = "https://clockalert.sourceforge.io/version.xml";
            elementName = string.Empty;
            xmlUrl = string.Empty;
            updateCheckerThread = null;
        }

        /// <summary>
        /// Downloads the Version Xml
        /// </summary>
        /// <param name="url">Url of xml</param>
        /// <returns>The Task object representing the stream containg the xml</returns>
        /// <exception cref="WebException"></exception>
        private async Task<MemoryStream> GetVersionXmlStream(string url)
        {

            Uri uri = new Uri(url);
            WebClient webClient = new WebClient();
            string xml = await webClient.DownloadStringTaskAsync(uri);
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return stream;
        }

        private VersionXml DeSerializeVersionXml(MemoryStream stream)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(VersionXml));
            VersionXml versionXml = (VersionXml)xmlSerializer.Deserialize(stream);
            return versionXml;
        }

        /// <summary>
        /// Gets the current version available for download asynchronously.
        /// </summary>
        /// <param name="url"></param>
        /// <returns> Instance of <see cref="Version"/> representing the latest version.</returns>
        /// <exception cref="WebException">Something went wrong when downloading the xml.</exception>
        private async Task<VersionXml> GetVersionAsync(string url)
        {
            MemoryStream stream = await GetVersionXmlStream(url);
            VersionXml version= DeSerializeVersionXml(stream);
            return version;
        }

        /// <summary>
        /// Checks if there is a newer version of Clock Alert asynchronously
        /// </summary>
        /// <returns>Boolen value representing whether a new update is available or not.</returns>
        /// <exception cref="InternetConnectionException">There is no internet connection</exception>
        /// <exception cref="WebException">Something went wrong when downloading the xml.</exception>
        public async Task<bool> HasUpdateAsync()
        {
            if(InternetConnection.checkConntection() == false)
            {
                throw new InternetConnectionException();
            }
            VersionXml versionXml= await GetVersionAsync(url);
            Version currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return currentVersion.CompareTo(versionXml.Version)<0;
        }

        /// <summary>
        /// Get the Uri to the installer of the latest version
        /// of clock alert.
        /// </summary>
        /// <returns>Uri to the latest version of clock alert.</returns>
        /// <exception cref="InternetConnectionException">There is no internet connection</exception>
        /// <exception cref="WebException">Something went wrong when downloading the xml.</exception>
        public async Task<Uri> GetDownloadUrlAsync()
        {
            if (InternetConnection.checkConntection() == false)
            {
                throw new InternetConnectionException();
            }
            VersionXml versionXml = await this.GetVersionAsync(url);
            return versionXml.Url;
        }
    }
}
