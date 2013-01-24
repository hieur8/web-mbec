using System;
using System.Net;
using System.Net.Mail;
using MiBo.Domain.Common.Exceptions;
using Resources;

namespace MiBo.Domain.Common.Helper
{
    public static class MailHelper
    {
        /// <summary>
        /// Sends the specified message to an SMTP server for delivery.
        /// </summary>
        /// <param name="from">The address of the sender of the e-mail message.</param>
        /// <param name="to">The address of the recipient of the e-mail message.</param>
        /// <param name="subject">The subject line for this e-mail message</param>
        /// <param name="body">The message body.</param>
        /// <param name="host">The name or IP address of the host used for SMTP transactions.</param>
        public static void SendMail(string from, string to, string subject, string body, string host)
        {
            try
            {
                // Local variable declaration
                var mMessage = new MailMessage();
                var smtpClient = new SmtpClient();
                // Set value form MailMessage
                mMessage.From = new MailAddress(from);
                mMessage.To.Add(new MailAddress(to));
                mMessage.Subject = subject;
                mMessage.IsBodyHtml = true;
                mMessage.Body = body;
                mMessage.Priority = MailPriority.Normal;
                // Set value form SmtpClient
                smtpClient.Host = host;
                smtpClient.UseDefaultCredentials = true;
                // Send
                smtpClient.Send(mMessage);
                // Dispose
                mMessage.Dispose();
                smtpClient.Dispose();
            }
            catch (Exception)
            {
                var message = MessageHelper.GetMessageFatal(
                    "F_MSG_00002", Messages.F_MSG_00002_T, Messages.F_MSG_00002_H);
                throw new SysRuntimeException(message);
            }
        }

        /// <summary>
        /// Sends the specified message to an SMTP server for delivery.
        /// </summary>
        /// <param name="from">The address of the sender of the e-mail message.</param>
        /// <param name="to">The address of the recipient of the e-mail message.</param>
        /// <param name="subject">The subject line for this e-mail message</param>
        /// <param name="body">The message body.</param>
        /// <param name="host">The name or IP address of the host used for SMTP transactions.</param>
        /// <param name="password">The password for the user name associated with the credentials.</param>
        public static void SendMail(string from, string to, string subject, string body, string host, string password)
        {
            try
            {
                // Local variable declaration
                var mMessage = new MailMessage();
                var smtpClient = new SmtpClient();
                var credentials = new NetworkCredential();
                // Set value form NetworkCredential
                credentials.UserName = from;
                credentials.Password = password;
                // Set value form MailMessage
                mMessage.From = new MailAddress(from);
                mMessage.To.Add(new MailAddress(to));
                mMessage.Subject = subject;
                mMessage.IsBodyHtml = true;
                mMessage.Body = body;
                mMessage.Priority = MailPriority.Normal;
                // Set value form SmtpClient
                smtpClient.Host = host;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = credentials;
                // Send mail
                smtpClient.Send(mMessage);
                // Dispose
                mMessage.Dispose();
                smtpClient.Dispose();
            }
            catch (Exception)
            {
                var message = MessageHelper.GetMessageFatal(
                    "F_MSG_00002", Messages.F_MSG_00002_T, Messages.F_MSG_00002_H);
                throw new SysRuntimeException(message);
            }
        }
    }
}