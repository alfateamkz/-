using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Add
{
    public class AgencyClientAdd
    {
        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Grants")]
        public List<GrantItem> Grants { get; set; } = new List<GrantItem>();

        [JsonProperty("Notification")]
        public NotificationAdd Notification { get; set; }

        [JsonProperty("Settings")]
        public List<ClientSettingAddItem> Settings { get; set; } = new List<ClientSettingAddItem>();

        [JsonProperty("TinInfo")]
        public TinInfoAdd TinInfo { get; set; }
    }
}
