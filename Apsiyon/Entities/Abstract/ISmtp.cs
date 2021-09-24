using System.Net.Mail;

namespace Apsiyon.Entities.Abstract
{
    public interface ISmtp
    {
        string Mail { get; set; }
        string Name { get; set; }
        string Host { get; set; }
        bool EnableSSL { get; set; }
        int Port { get; set; }
        string Password { get; set; }
        bool UseDefaultCredentials { get; set; }
        SmtpDeliveryMethod DeliveryMethod { get; set; }
    }
}
