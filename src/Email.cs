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
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Clock_Alert
{
    class Email : IEmail
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
                mailClient.Send(mail);
            }
            else
            {
                throw new Exception("Email server has not been configured. please call configure method first");
            }
        }
    }
}
