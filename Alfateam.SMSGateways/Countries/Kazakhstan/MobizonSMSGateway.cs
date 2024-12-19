using Alfateam.SMSGateways.Abstractions;
using Alfateam.SMSGateways.Enums;
using Alfateam.SMSGateways.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Countries.Kazakhstan
{
    public class MobizonSMSGateway : AbsSMSGateway
    {
        protected readonly string API_KEY;
        protected readonly string From;
        protected readonly string BaseUrl = "https://api.mobizon.kz";
        public MobizonSMSGateway(string apiKey, string from = null)
        {
            API_KEY = apiKey;
            From = from;
        }
        public MobizonSMSGateway(string apiKey, string server, string from = null)
        {
            API_KEY = apiKey;
            From = from;
            BaseUrl = server;
        }

        public override async Task<GetBalanceStatus> GetBalance()
        {
            string url = $"{BaseUrl}/service/user/getownbalance/?apiKey={API_KEY}";
            var response = await RequestsHelper.Send<MobizonSMSGatewayResponse>(HttpMethod.Get, url);

            if (response.Data.Code == 0)
            {
                return new GetBalanceStatus(GetBalanceStatusType.Success, "", (string)response.Data.Data.currency, (double)response.Data.Data.balance);
            }
            else if (response.Data.Code == 8)
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


            string url = $"{BaseUrl}/service/Message/SendSmsMessage?apiKey={API_KEY}&recipient={phone}&text={message}&from={From}";
            var response = await RequestsHelper.Send<MobizonSMSGatewayResponse>(HttpMethod.Get, url);

            if (response.Data.Code == 0 || response.Data.Code == 100)
            {
                return new SentSmsStatus(SentSmsStatusType.Success, response.Data.Message);
            }
            else if (response.Data.Code == 8) //API authentication error - 8
            {
                return new SentSmsStatus(SentSmsStatusType.Unauthorized, response.Data.Message);
            }
            else if (response.Data.Code == 14) //Данная ошибка возникает в случае, если аккаунт пользователя заблокирован или удален - 14
            {
                return new SentSmsStatus(SentSmsStatusType.AccountBlockedOrDeleted, response.Data.Message);
            }
            else if (response.Data.Code == 30) //Ошибка превышения допустимого лимита скорости запросов - 30
            {
                return new SentSmsStatus(SentSmsStatusType.LimitExceeded, response.Data.Message);
            }
            else if(CheckInsufficientFunds(response))
            {
                return new SentSmsStatus(SentSmsStatusType.InsufficientFunds, response.Data.Message);
            }
            else if (CheckCountryNotAllowed(response))
            {
                return new SentSmsStatus(SentSmsStatusType.CountryNotAllowed, (string)response.Data.Data.recipient);
            }

            return new SentSmsStatus(SentSmsStatusType.ServiceError, response.Data.Message);
        }



        private bool CheckInsufficientFunds(Response<MobizonSMSGatewayResponse> response)
        {
            return response.Data.Message.Contains("Недостаточно средств")
                  || response.Data.Message.Contains("Бұл операцияны орындау үшін есепшотта жеткілікті қаражат жоқ")
                  || response.Data.Message.Contains("Account balance insufficient to perform this operation")
                  || response.Data.Message.Contains("Nicht genug Guthaben auf dem Konto um die gewünschte Aktion durchzuführen")
                  || response.Data.Message.Contains("Недостатньо коштів на рахунку для здійснення цієї операції")
                  || response.Data.Message.Contains("Saldo da conta insuficiente para executar esta operação");
        }
        private bool CheckCountryNotAllowed(Response<MobizonSMSGatewayResponse> response)
        {
            return DoesPropertyExist(response.Data.Data, "recipient") 
                && (response.Data.Data.recipient == "Отправка в страну назначения ограничена настройками."
                   || response.Data.Data.recipient == "Тағайындалған елге жіберу параметрлермен шектелген."
                   || response.Data.Data.recipient == "Sending SMS to this destination is prohibited."
                   || response.Data.Data.recipient == "SMS-Versand an dieses Ziel ist untersagt."
                   || response.Data.Data.recipient == "Відправлення в країну призначення обмежене налаштуваннями."
                   || response.Data.Data.recipient == "É proibido enviar SMS para este destino.");
        }
    }

    internal class MobizonSMSGatewayResponse
    {
        public int Code { get; set; }
        public dynamic Data { get; set; }
        public string? Message { get; set; }

    }


}
