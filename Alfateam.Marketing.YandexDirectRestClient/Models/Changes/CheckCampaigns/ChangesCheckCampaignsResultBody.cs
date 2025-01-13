using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes.CheckCampaigns
{
    public class ChangesCheckCampaignsResultBody
    {
        [JsonProperty("Campaigns")]
        public List<CampaignChangesItem> Campaigns { get; set; } = new List<CampaignChangesItem>();

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
