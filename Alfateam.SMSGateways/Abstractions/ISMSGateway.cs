using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Abstractions
{
    public interface ISMSGateway
    {
        SentSmsStatus Send(string phone, string message);
    }
}
