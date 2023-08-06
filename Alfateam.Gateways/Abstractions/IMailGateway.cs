using Alfateam.Gateways.Helpers;
using Alfateam.Gateways.Models.Credentials;
using Alfateam.Gateways.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Gateways.Abstractions
{
    public interface IMailGateway
    {

        void SendMail(EmailCredentials credentials, EmailMessage message);


        void SendOfficialMail(EmailMessage message);
        void SendSupportMail(EmailMessage message);
        void SendRestoreMail(EmailMessage message);
        void SendNotificationMail(EmailMessage message);


       


    }
}
