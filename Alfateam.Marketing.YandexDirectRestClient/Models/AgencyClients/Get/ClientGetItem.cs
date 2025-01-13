using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class ClientGetItem
    {
        [JsonProperty("AccountQuality")]
        public decimal AccountQuality { get; set; }

        [JsonProperty("Archived")]
        public YesNoEnum Archived { get; set; }

        [JsonProperty("ClientId")]
        public long ClientId { get; set; }

        [JsonProperty("ClientInfo")]
        public string ClientInfo { get; set; }

        [JsonProperty("CountryId")]
        public int CountryId { get; set; }

        [JsonProperty("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Grants")]
        public List<GrantGetItem> Grants { get; set; } = new List<GrantGetItem>();

        [JsonProperty("Bonuses")]
        public BonusesGet Bonuses { get; set; }

        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Notification")]
        public NotificationGet Notification { get; set; }

        [JsonProperty("OverdraftSumAvailable")]
        public long OverdraftSumAvailable { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Representatives")]
        public List<Representative> Representatives { get; set; } = new List<Representative>();

        [JsonProperty("Restrictions")]
        public List<ClientRestrictionItem> Restrictions { get; set; } = new List<ClientRestrictionItem>();

        [JsonProperty("Settings")]
        public List<ClientSettingGetItem> Settings { get; set; } = new List<ClientSettingGetItem>();

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("VatRate")]
        public decimal VATRate { get; set; }

        [JsonProperty("ForbiddenPlatform")]
        public ForbiddenPlatformEnum ForbiddenPlatform { get; set; }

        [JsonProperty("AvailableCampaignTypes")]
        public AvailableCampaignTypesEnum AvailableCampaignTypes { get; set; }

        [JsonProperty("TinInfo")]
        public TinInfoGet TinInfo { get; set; }

        [JsonProperty("ErirAttributes")]
        public ErirAttributesGet ErirAttributes { get; set; }
    }
}
