using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace ClockAlert.Modules
{
    internal class Email
    {
        /// <summary>
        /// Sender email address.
        /// </summary>
        private string sender;
        /// <summary>
        /// Receiver email address.
        /// </summary>
        private string receiver;
        /// <summary>
        /// Subject of the message.
        /// </summary>
        private string subject;
        /// <summary>
        /// Body of the message.
        /// </summary>
        private string body;
        /// <summary>
        /// Name or IP address of the SMTP host.
        /// </summary>
        private string SMTPHost;
        /// <summary>
        /// User name for the SMTP transactions.
        /// </summary>
        private string userName;
        /// <summary>
        /// Password for the SMTP transactions.
        /// </summary>
        private string password;
        /// <summary>
        /// Port number to connect to SMTP host for transactions.
        /// </summary>
        private int port;
        /// <summary>
        /// Specify whether the SMTP client uses the Secure Socket Layer (SSL) to encrypt the connection.
        /// </summary>
        private bool enableSSL;

        private SmtpClient mailClient;

        private Progress _progress;

        /// <summary>
        /// Initializes the Email class instance
        /// </summary>
        public Email()
        {
            sender = string.Empty;
            receiver = string.Empty;
            subject = string.Empty;
            body = string.Empty;
            SMTPHost = string.Empty;
            userName = string.Empty;
            password = string.Empty;
            port = 25;
            enableSSL = false;
            mailClient = null;
        }

        /// <summary>
        /// Configures the SMTP client for E-Mail transactions.
        /// </summary>
        /// <param name="SMTPHostName">Name or IP address of the SMTP host.</param>
        /// <param name="userName">User name for the SMTP transactions.</param>
        /// <param name="password">Password for the SMTP transactions.</param>
        /// <param name="enableSSL">pecify whether the SMTP client uses the Secure Socket Layer (SSL) to encrypt the connection.</param>
        /// <param name="port">Port number to connect to SMTP host for transactions.</param>
        public void configure(string SMTPHostName, string userName, string password, bool enableSSL, int port)
        {
            SMTPHost = SMTPHostName;
            this.userName = userName;
            this.password = password;
            this.enableSSL = enableSSL;
            this.port = port;
            mailClient = new SmtpClient(SMTPHost);
            mailClient.Port = this.port;
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.Credentials = new System.Net.NetworkCredential(this.userName, this.password);
            mailClient.EnableSsl = this.enableSSL;
        }

        /// <summary>
        /// Sets the E-mail fields required for sending an E-mail.
        /// </summary>
        /// <param name="fromAddress">Sender email address.</param>
        /// <param name="toAddress">Receiver email address</param>
        /// <param name="subject">Subject of the message</param>
        /// <param name="body">Body of the message</param>
        public void setFields(string fromAddress, string toAddress, string subject, string body)
        {
            sender = fromAddress;
            receiver = toAddress;
            this.subject = subject;
            this.body = body;
        }

        /// <summary>
        /// Send the email with the specified configuration and fields.
        /// </summary>
        public void sendMail()
        {

            if (mailClient != null)
            {

                MailMessage mail = new MailMessage(sender, receiver);
                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = body;
                //mailClient.Send(mail);
                mailClient.SendCompleted += new SendCompletedEventHandler(mailClient_SendCompleted);
                mailClient.SendAsync(mail, "Crash Report");
                _progress = new Progress();
                _progress.ShowDialog();
            }
            else
            {
                throw new Exception("Email server has not been configured. please call configure method first");
            }
        }

        void mailClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(App));
            _progress.Close();
            if (e.Error != null)
            {
                ErrorLog.logError(e.Error);
                System.Windows.Forms.MessageBox.Show(resourceManager.GetString("crashReportErrorTitle"), resourceManager.GetString("crashReportErrMsgP1") + '\"' + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + System.IO.Path.DirectorySeparatorChar + "Moon01Man" + System.IO.Path.DirectorySeparatorChar + "Clock Alert" + System.IO.Path.DirectorySeparatorChar + '\"' + resourceManager.GetString("crashReportErrMsgP2"), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            else
            {
                _progress.Close();
                System.Windows.Forms.MessageBox.Show(resourceManager.GetString("crashReportSentMessage"), resourceManager.GetString("crashReportSentTitle"), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
    }
}
