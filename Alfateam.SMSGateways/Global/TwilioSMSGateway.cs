using Alfateam.SMSGateways.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Alfateam.SMSGateways.Global
{
    public class TwilioSMSGateway : AbsSMSGateway
    {

        protected const string BaseUrl = "https://api.twilio.com/";
        protected readonly string Username;
        protected readonly string Password;
        public TwilioSMSGateway(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public override async Task<GetBalanceStatus> GetBalance()
        {
            TwilioClient.Init("AC13f02292736a8736fbbb60ab07c84a1e", "69c721743d1de8ae799fef269bdb79d2");



            throw new NotImplementedException();
        }

        public override async Task<SentSmsStatus> Send(string phone, string message)
        {
       

            throw new NotImplementedException();
        }
    }
}
