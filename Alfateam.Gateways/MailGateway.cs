using System.Net.Mail;
using System.Net;
using Alfateam.Gateways.Helpers;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways.Models.Credentials;
using Alfateam.Gateways.Models.Messages;

namespace Alfateam.Gateways
{
    public class MailGateway : IMailGateway
    {
        private const string SMTP_HOST = "smtp.alfateam.co";
        private const int SMTP_PORT = 587;



        public void SendMail(EmailCredentials credentials, EmailMessage message)
        {
            MailAddress fromMailAddress = new MailAddress(credentials.Email, credentials.DisplayName);
            MailAddress toAddress = new MailAddress(message.ToEmail, message.ToDisplayName);

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                mailMessage.Subject = message.Subject;
                mailMessage.Body = message.Body;

                smtpClient.Host = SMTP_HOST;
                smtpClient.Port = SMTP_PORT;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, credentials.Password);

                smtpClient.Send(mailMessage);
            }
        }




        public void SendOfficialMail(EmailMessage message)
        {
            SendMail(StaticCredentials.OFFICIAL_EMAIL, message);
        }
        public void SendSupportMail(EmailMessage message)
        {
            SendMail(StaticCredentials.SUPPORT_EMAIL, message);
        }
        public void SendRestoreMail(EmailMessage message)
        {
            SendMail(StaticCredentials.RESTORE_EMAIL, message);
        }
        public void SendNotificationMail(EmailMessage message)
        {
            SendMail(StaticCredentials.NOTIFICATIONS_EMAIL, message);
        }

 
    }
}