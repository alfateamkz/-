using Alfateam.SMSGateways.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Countries.Mongolia
{
    public class UniSMSGateway : AbsSMSGateway
    {
        public override async Task<GetBalanceStatus> GetBalance()
        {
            throw new NotImplementedException();
        }

        public override async Task<SentSmsStatus> Send(string phone, string message)
        {
            throw new NotImplementedException();
        }
    }
}
