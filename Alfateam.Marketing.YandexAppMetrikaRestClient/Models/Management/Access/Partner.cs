using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access
{
    public class Partner
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon_url")]
        public string IconURL { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteURL { get; set; }

        [JsonProperty("campaigns_count")]
        public int CampaignsCount { get; set; }

        [JsonProperty("ownership")]
        public PartnerOwnership Ownership { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
