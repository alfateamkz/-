using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicFeedAdTargets.SetBids
{
    public class SetBidsItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("ContextBid")]
        public long ContextBid { get; set; }
    }
}
