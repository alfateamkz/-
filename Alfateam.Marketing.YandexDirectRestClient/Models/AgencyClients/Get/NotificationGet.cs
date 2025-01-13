using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class NotificationGet
    {
        [JsonProperty("Lang")]
        public string Lang { get; set; }

        [JsonProperty("SmsPhoneNumber")]
        public string SMSPhoneNumber { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("EmailSubscriptions")]
        public List<EmailSubscriptionItem> EmailSubscriptions { get; set; } = new List<EmailSubscriptionItem>();
    }
}
