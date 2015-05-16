using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;

namespace Clock_Alert
{
    /// <summary>
    /// Reperesents the methods for connecting to the internet
    /// </summary>
    static class InternetConnection
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
            Ping pingObj = new Ping();
            byte[] buffer = new byte[32];
            int timeOut = 1000;
            PingOptions pingOptionsObject = new PingOptions(45, false);
            try
            {
                PingReply pingReplyObj = pingObj.Send(hostName, timeOut, buffer, pingOptionsObject);
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
    }

    /// <summary>
    /// Describes all information about the change in internet connection state
    /// </summary>
    class InternetConnectionStateChangedEventArgs : EventArgs
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
