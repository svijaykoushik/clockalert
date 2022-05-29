using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace ClockAlert.Modules
{
    internal static class InternetConnection
    {
        private static bool isConnected;

        /// <summary>
        /// Initializes InternetConnetction class
        /// </summary>
        static InternetConnection()
        {
            isConnected = checkConntection();
        }

        public enum PingStatus
        {
            Success,
            Cancelled,
            NotSupported,
            Failed
        };

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int Reserved);
        /// <summary>
        /// Checks wether the computer is connected to the internet
        /// </summary>
        /// <returns>True if connected to the internet and false if not</returns>
        public static bool checkConntection()
        {
            /*int desc;
            return InternetGetConnectedState(out desc, 0);*/
            int desc;
            bool retVal = InternetGetConnectedState(out desc, 0);
            System.Diagnostics.Debug.WriteLine("internet description " + desc);
            return retVal;
        }

        /// <summary>
        /// Pings predefined servers and retruns the status of the operation
        /// </summary>
        /// <returns>Success if Internet is Up</returns>
        private static PingStatus pingServer()
        {
            string[] serverHostname = { "www.clockalert.co.nr", "clockalert.sourceforge.net", "www.google.com", "www.bing.com", "sourceforge.net" };
            Random random = new Random();
            foreach (string hosts in serverHostname)
            {
                if (doPing(hosts))
                    return PingStatus.Success;
            }
            return PingStatus.Failed;
        }

        /// <summary>
        /// Performs Ping operation on the specified server
        /// </summary>
        /// <param name="hostName">IP Address or host name</param>
        /// <returns></returns>
        public static bool doPing(string hostName)
        {
            if (hostName == null)
            {
                throw new ArgumentNullException("hostName", "The method doPing received null expected string");
            }
            else if (hostName == "")
            {
                throw new ArgumentOutOfRangeException("hostName", "The method doPing received null expected string");
            }
            Uri url;
            Ping pingObj = new Ping();
            byte[] buffer = new byte[32];
            int timeOut = 1000;
            try
            {
                url = new Uri(hostName);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException("The method doPing received an invalid argument", "hostName", ex);
            }
            string hostUrl = string.Format("{0}", url.Host);
            PingOptions pingOptionsObject = new PingOptions(45, false);
            try
            {
                PingReply pingReplyObj = pingObj.Send(hostUrl, timeOut, buffer, pingOptionsObject);
                //System.Diagnostics.Debug.WriteLine("Ping status for " + hostUrl + "is " + pingReplyObj.Status.ToString());
                if (pingReplyObj.Status == IPStatus.Success)
                    return true;
            }
            catch (NotSupportedException ex)
            {
                System.Windows.Forms.MessageBox.Show("Application is running in an unsupported version of Windows", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                ErrorLog.logError(ex);
            }
            catch (PingException ex)
            {
                ErrorLog.logError(ex);
            }
            return false;
        }


        /// <summary>
        /// Handles the Internet connection state changed event.
        /// </summary>
        private static event EventHandler<InternetConnectionStateChangedEventArgs> handler;

        /// <summary>
        /// Handles the Internet connection state changed event.
        /// </summary>
        public static event EventHandler<InternetConnectionStateChangedEventArgs> InternettConnectionStateCanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            //Custom accessor for InternetConnectionStateChanged event
            add
            {
                if (handler == null)
                {
                    NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(OnNetworkAvailabilityChanged);
                    NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(OnNetworkAddressChanged);
                }
                handler = (EventHandler<InternetConnectionStateChangedEventArgs>)Delegate.Combine(handler, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                handler = (EventHandler<InternetConnectionStateChangedEventArgs>)Delegate.Remove(handler, value);
                if (handler == null)
                {
                    NetworkChange.NetworkAvailabilityChanged -= new NetworkAvailabilityChangedEventHandler(OnNetworkAvailabilityChanged);
                    NetworkChange.NetworkAddressChanged -= new NetworkAddressChangedEventHandler(OnNetworkAddressChanged);
                }
            }
        }

        /// <summary>
        /// Called when IP address gets changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnNetworkAddressChanged(object sender, EventArgs e)
        {
            notifyInternetConnectionChange(sender);
        }

        /// <summary>
        /// Called when availability of network gets changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnNetworkAvailabilityChanged(object sender, EventArgs e)
        {
            notifyInternetConnectionChange(sender);
        }

        /// <summary>
        /// Notifys the event subscribers about change in the Internet connection state
        /// </summary>
        /// <param name="sender">Initiator of the event</param>
        private static void notifyInternetConnectionChange(object sender)
        {
            bool change = checkConntection();
            if (change != isConnected)
            {
                isConnected = change;
                if (handler != null)
                    handler(sender, new InternetConnectionStateChangedEventArgs(isConnected));
            }
        }

        /// <summary>
        ///  Sends a HTTP POST request to the host provided.
        /// </summary>
        /// <param name="request">The request to be sent</param>
        /// <param name="requestContent">The content of the request</param>
        /// <returns>Response to the request sent</returns>
        public static WebResponse postRequest(WebRequest request, byte[] requestContent)
        {
            WebResponse response = null;
            if (request == null)
            {
                throw new ArgumentNullException("request", "The method postRequest received null as argument");
            }
            else if (requestContent == null)
            {
                throw new ArgumentNullException("requestContent", "The method postRequest received null as argument");
            }
            try
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(requestContent, 0, requestContent.Length);
                dataStream.Close();
                response = request.GetResponse();
            }
            catch (WebException ex)
            {
                response = null;
                ErrorLog.logError(ex);
                MessageBox.Show("Unable to send data to the server", "Error: At posting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                response = null;
                ErrorLog.logError(ex);
                MessageBox.Show("Unable to open stream to send data", "Error: At posting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                response = null;
                ErrorLog.logError(ex);
                MessageBox.Show("Unknown error occured", "Error: At posting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return response;
        }

        /// <summary>
        /// Initializes a new instance of System.Net.WebRequest with the specified arguments.
        /// </summary>
        /// <param name="hostUrl">URL to the host</param>
        /// <param name="requestMethod">The method in which request is to be sent</param>
        /// <param name="requsetContentType">The content type of the request</param>
        /// <param name="requestBody">The body of the request</param>
        /// <returns></returns>
        public static WebRequest formWebRequest(string hostUrl, string requestMethod, string requsetContentType, string requestBody)
        {
            if ((hostUrl != null && hostUrl != "") && (requestMethod != null && requestMethod != "") && (requsetContentType != null && requsetContentType != "") && (requestBody != "" && requestBody != null))
            {
                WebRequest request = WebRequest.Create(hostUrl);
                request.Method = requestMethod;
                request.ContentType = requsetContentType;
                byte[] reqBody = Encoding.UTF8.GetBytes(requestBody);
                request.ContentLength = reqBody.Length;
                return request;
            }
            else
            {
                throw new ArgumentException("The method formWebRequest received invalid arguments");
            }
        }


    }

    /// <summary>
    /// Describes all information about the change in internet connection state
    /// </summary>
    public class InternetConnectionStateChangedEventArgs : EventArgs
    {
        private bool isConnected;

        /// <summary>
        /// Initializes the InternetConnectionStateChangedEventArgs event data
        /// </summary>
        /// <param name="connectedState">The current connection state of the Internet</param>
        public InternetConnectionStateChangedEventArgs(bool connectedState)
        {
            isConnected = connectedState;
        }

        /// <summary>
        /// Gets the current status of Internet connection
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
        }
    }
}
