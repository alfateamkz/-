using Alfateam.SMSGateways.Abstractions;
using Alfateam.SMSGateways.Enums;
using Alfateam.SMSGateways.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Countries.Russia
{
    public class SMSRuGateway : AbsSMSGateway
    {
        protected readonly string API_ID;
        protected const string BaseUrl = "https://sms.ru";
        public SMSRuGateway(string apiId)
        {
            API_ID = apiId;
        }

        public override async Task<GetBalanceStatus> GetBalance()
        {
            string url = $"{BaseUrl}/my/balance?api_id={API_ID}&json=1";
            var response = await RequestsHelper.Send<SMSRuAPIGetBalanceModel>(HttpMethod.Get, url);

            if (response.Data.Status == "OK")
            {
                return new GetBalanceStatus(GetBalanceStatusType.Success, "", "RUB", response.Data.Balance);
            }
            else if (response.StatusCode == 401)
            {
                return new GetBalanceStatus(GetBalanceStatusType.Unauthorized, response.Data.Status);
            }

            return new GetBalanceStatus(GetBalanceStatusType.ServiceError, response.Data.Status);
        }
        public override async Task<SentSmsStatus> Send(string phone, string message)
        {
            var baseCheckStatus = this.CheckParameters(phone, message);
            if (baseCheckStatus != null)
            {
                return baseCheckStatus;
            }

            string url = $"{BaseUrl}/sms/send?api_id={API_ID}&to={phone}&msg={message}&json=1";
            var response = await RequestsHelper.Send<SMSRuAPISendSMSModel>(HttpMethod.Get, url);


            if (response.Data.StatusCode == 100)
            {
                return new SentSmsStatus(SentSmsStatusType.Success, response.Data.Status);
            }
            //На этот номер нет маршрута для доставки сообщений - 207
            //Неправильно указан номер телефона получателя, либо на него нет маршрута - 202
            //Не может быть доставлено: не найден маршрут на данный номер - 150
            else if (response.Data.StatusCode == 207 || response.Data.StatusCode == 202 || response.Data.StatusCode == 150) 
            {
                return new SentSmsStatus(SentSmsStatusType.PhoneNumberDoesNotExist, response.Data.Status);
            }
            else if (response.Data.StatusCode == 201) //Не хватает средств на лицевом счету - 201
            {
                return new SentSmsStatus(SentSmsStatusType.InsufficientFunds, response.Data.Status);
            }
            //Неправильный api_id - 200
            //401 - наш код для проверки (а вдруг)
            //Неправильный token (возможно истек срок действия, либо ваш IP изменился) - 300
            //Неправильный api_id, либо логин/пароль - 301
            else if (response.Data.StatusCode == 401 || response.Data.StatusCode == 200 
                || response.Data.StatusCode == 300 || response.Data.StatusCode == 301)
            {
                return new SentSmsStatus(SentSmsStatusType.Unauthorized, response.Data.Status);
            }
            else if (response.Data.StatusCode == 214) //Номер находится зарубежом (включена настройка "Отправлять только на номера РФ") - 214
            {
                return new SentSmsStatus(SentSmsStatusType.CountryNotAllowed, response.Data.Status);
            }
            else if (response.Data.StatusCode == 216) //В тексте сообщения содержится запрещенное слово - 216
            {
                return new SentSmsStatus(SentSmsStatusType.MessageTextValidationErrorFromGateway, response.Data.Status);
            }
            //Превышен общий лимит количества сообщений на этот номер в день - 230	
            //Превышен лимит одинаковых сообщений на этот номер в минуту - 231
            //Превышен лимит одинаковых сообщений на этот номер в день - 232
            //Превышен лимит отправки повторных сообщений с кодом на этот номер за короткий промежуток времени ("защита от мошенников", можно отключить в разделе "Настройки") - 233
            else if (response.Data.StatusCode == 230 || response.Data.StatusCode == 231
                      || response.Data.StatusCode == 232 || response.Data.StatusCode == 233)
            {
                return new SentSmsStatus(SentSmsStatusType.LimitExceeded, response.Data.Status);
            }

            return new SentSmsStatus(SentSmsStatusType.ServiceError, response.Data.Status);
        }
    }

    internal class SMSRuAPIGetBalanceModel
    {
        public string Status { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        public double Balance { get; set; }
    }

    internal class SMSRuAPISendSMSModel
    {
        public string Status { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("sms")]
        public Dictionary<string, SMSRuAPISendSMSModelNumber> Numbers { get; set; } = new Dictionary<string, SMSRuAPISendSMSModelNumber>();

        public double Balance { get; set; }
    }

    internal class SMSRuAPISendSMSModelNumber
    {
        public string Status { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("status_text")]
        public string? StatusText { get; set; }

        [JsonProperty("sms_id")]
        public string? SMS_ID { get; set; }
    }
}
