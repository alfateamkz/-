using Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Update
{
    public class AgencyClientUpdateItem
    {
        [JsonProperty("ClientId")]
        public long ClientId { get; set; }

        [JsonProperty("ClientInfo")]
        public string ClientInfo { get; set; }

        [JsonProperty("Grants")]
        public List<GrantItem> Grants { get; set; } = new List<GrantItem>();

        [JsonProperty("Notification")]
        public NotificationUpdate Notification { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Settings")]
        public List<ClientSettingUpdateItem> Settings { get; set; } = new List<ClientSettingUpdateItem>();

        [JsonProperty("TinInfo")]
        public TinInfoUpdate TinInfo { get; set; }

        [JsonProperty("ErirAttributes")]
        public ErirAttributesUpdate ErirAttributes { get; set; }
    }
}
