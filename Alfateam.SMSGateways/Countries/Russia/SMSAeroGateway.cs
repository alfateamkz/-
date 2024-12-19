using Alfateam.SMSGateways.Abstractions;
using Alfateam.SMSGateways.Enums;
using Alfateam.SMSGateways.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Countries.Russia
{
    public class SMSAeroGateway : AbsSMSGateway
    {
        protected readonly string BaseUrl;
        protected readonly string From;
        
        public SMSAeroGateway(string smsAeroLogin, string smsAeroApiKey, string from = "SMS Aero")
        {
            BaseUrl = $"https://{smsAeroLogin}:{smsAeroApiKey}@gate.smsaero.ru/v2";
            From = from;
        }


        public override async Task<GetBalanceStatus> GetBalance()
        {
            var response = await RequestsHelper.Send<SMSAeroAPIResponse<SMSAeroAPIGetBalanceModel>>(HttpMethod.Get, $"{BaseUrl}/balance");

            if (response.Data.Success)
            {
                return new GetBalanceStatus(GetBalanceStatusType.Success, response.Data.Message, "RUB", response.Data.Data.SumDouble);
            }
            else if(response.StatusCode == 401)
            {
                return new GetBalanceStatus(GetBalanceStatusType.Unauthorized, response.Data.Message);
            }

            return new GetBalanceStatus(GetBalanceStatusType.ServiceError, response.Data.Message);
        }
        public override async Task<SentSmsStatus> Send(string phone, string message)
        {
            var baseCheckStatus = this.CheckParameters(phone, message);
            if (baseCheckStatus != null)
            {
                return baseCheckStatus;
            }

            string url = $"{BaseUrl}/sms/send?number={phone}&text={message}&sign={From}";
            var response = await RequestsHelper.Send<SMSAeroAPIResponse<object>>(HttpMethod.Get, url);

            if (response.Data.Success)
            {
                return new SentSmsStatus(SentSmsStatusType.Success, response.Data.Message);
            }
            else if (response.StatusCode == 401)
            {
                return new SentSmsStatus(SentSmsStatusType.Unauthorized, response.Data.Message);
            }

            SentSmsStatusType statusType = SentSmsStatusType.ServiceError;
            if (response.Data.Message == "Not enough money")
            {
                statusType = SentSmsStatusType.InsufficientFunds;
            }

            return new SentSmsStatus(statusType, response.Data.Message);
        }
    }

    internal class SMSAeroAPIResponse<T> where T : class 
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public T Data { get; set; }
    }

    internal class SMSAeroAPIGetBalanceModel
    {
        public int Sum { get; set; }
        public double SumDouble => (double)Sum / 100;
    }
}
