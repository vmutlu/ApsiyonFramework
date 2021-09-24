using Apsiyon.Entities.Abstract;
using Apsiyon.Utilities.Results;
using System;
using System.Net;
using System.Net.Mail;

namespace Apsiyon.Utilities.Mail
{
    /// <summary>
    /// Helper class used for sending mail
    /// </summary>
    public class MailHelper
    {
        /// <summary>
        /// Helper method of helper class used in mail sendings
        /// </summary>
        /// <param name="mail">Email sender account information</param>
        /// <param name="smtp">SMTP fields required for sending mail</param>
        /// <returns></returns>
        public static IResult SendEMail(IMail mail, ISmtp smtp)
        {
            MailMessage Email = new();
            Email.From = new MailAddress(smtp.Mail, smtp.Name);

            var mailadress = mail.Address.Split(',');
            foreach (string adress in mailadress)
                Email.To.Add(adress);

            Email.Subject = mail.Subject;
            Email.Body = mail.Message;
            Email.IsBodyHtml = mail.IsBody;
            SmtpClient Client = new();

            try
            {
                Client.Host = smtp.Host;
                Client.Port = smtp.Port;
                Client.DeliveryMethod = smtp.DeliveryMethod;
                Client.UseDefaultCredentials = smtp.UseDefaultCredentials;
                Client.Credentials = new NetworkCredential(smtp.Mail, smtp.Password);
                Client.EnableSsl = smtp.EnableSSL;
                Client.Send(Email);

                return new SuccessResult("Mail has sended.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Failed to send mail. Error: {ex.Message}");
            }
        }
    }
}
