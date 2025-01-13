using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes.Check
{
    public class CampaignStatItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("BorderDate")]
        public DateTime BorderDate { get; set; }
    }
}
