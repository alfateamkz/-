using Alfateam.Gateways.Models.Credentials;
using Alfateam.Gateways.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Gateways.Abstractions
{
    public interface ISMSGateway
    {
        public void SendSMS(SMSCredentials credentials, SMSMessage message);
    }
}
