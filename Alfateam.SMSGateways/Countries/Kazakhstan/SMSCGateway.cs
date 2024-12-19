using Alfateam.SMSGateways.Abstractions;
using Alfateam.SMSGateways.Countries.Russia;
using Alfateam.SMSGateways.Enums;
using Alfateam.SMSGateways.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Countries.Kazakhstan
{
    public class SMSCGateway : AbsSMSGateway
    {
        protected readonly string API_KEY;
        protected const string BaseUrl = "https://smsc.kz/";
        public SMSCGateway(string apiKey)
        {
            API_KEY = apiKey;
        }
        public override async Task<GetBalanceStatus> GetBalance()
        {
            string url = $"{BaseUrl}/sys/balance.php?apikey={API_KEY}&fmt=3&cur=true";
            var response = await RequestsHelper.Send<SMSCGetBalanceModel>(HttpMethod.Get, url);

            if (response.Data.ErrorCode == null)
            {
                return new GetBalanceStatus(GetBalanceStatusType.Success, "", response.Data.Currency, (double)response.Data.Balance);
            }
            else if (response.Data.Error == "bad api-key")
            {
                return new GetBalanceStatus(GetBalanceStatusType.Unauthorized, response.Data.Error);
            }

            return new GetBalanceStatus(GetBalanceStatusType.ServiceError, response.Data.Error);
        }

        public override async Task<SentSmsStatus> Send(string phone, string message)
        {
            var baseCheckStatus = this.CheckParameters(phone, message);
            if (baseCheckStatus != null)
            {
                return baseCheckStatus;
            }

            string url = $"{BaseUrl}/sys/send.php?apikey={API_KEY}&phones={phone}&mes={message}&fmt=3";
            var response = await RequestsHelper.Send<SMSCSendSMSModel>(HttpMethod.Get, url);


            if (response.Data.ErrorCode == null)
            {
                return new SentSmsStatus(SentSmsStatusType.Success, "");
            }
            else if (response.Data.ErrorCode == 8) //Cообщение на указанный номер не может быть доставлено - 8
            {
                return new SentSmsStatus(SentSmsStatusType.PhoneNumberDoesNotExist, response.Data.Error);
            }
            else if (response.Data.ErrorCode == 3) //Недостаточно средств на счете Клиента - 3
            {
                return new SentSmsStatus(SentSmsStatusType.InsufficientFunds, response.Data.Error);
            }
            else if (response.Data.ErrorCode == 2) //Неверный логин или пароль. Или апи ключ
            {
                return new SentSmsStatus(SentSmsStatusType.Unauthorized, response.Data.Error);
            }
            else if (response.Data.ErrorCode == 6) //	Сообщение запрещено (по тексту или по имени отправителя). Также данная ошибка возникает при попытке отправки массовых и (или) рекламных сообщений без заключенного договора.
            {
                return new SentSmsStatus(SentSmsStatusType.MessageTextValidationErrorFromGateway, response.Data.Error);
            }
            else if (response.Data.ErrorCode == 9) //	Отправка более одного одинакового запроса на передачу SMS-сообщения либо более пяти одинаковых запросов на получение стоимости сообщения в течение минуты.
            {
                return new SentSmsStatus(SentSmsStatusType.LimitExceeded, response.Data.Error);
            }

            return new SentSmsStatus(SentSmsStatusType.ServiceError, response.Data.Error);
        }
    }


    internal class SMSCGetBalanceModel

    {
        public string? Error { get; set; }

        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }


        public double? Balance { get; set; }
        public string? Currency { get; set; }
    }

    internal class SMSCSendSMSModel
    {
        public string? Error { get; set; }

        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }


        public int? Cnt { get; set; }


        public int Id { get; set; }
    }
}
