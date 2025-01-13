using Alfateam.Marketing.YandexDirectRestClient.Enums.Changes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes.CheckCampaigns
{
    public class CampaignChangesItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("ChangesIn")]
        public CampaignChangesInEnum ChangesIn { get; set; }
    }
}
