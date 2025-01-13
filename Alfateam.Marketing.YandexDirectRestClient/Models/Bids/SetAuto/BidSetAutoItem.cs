using Alfateam.Marketing.YandexDirectRestClient.Enums.Bids;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.SetAuto
{
    public class BidSetAutoItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("KeywordId")]
        public long KeywordId { get; set; }

        [JsonProperty("MaxBid")]
        public long MaxBid { get; set; }

        [JsonProperty("Position")]
        public BidPositionEnum Position { get; set; }

        [JsonProperty("IncreasePercent")]
        public long IncreasePercent { get; set; }

        [JsonProperty("CalculateBy")]
        public CalculateByEnum CalculateBy { get; set; }

        [JsonProperty("ContextCoverage")]
        public long ContextCoverage { get; set; }

        [JsonProperty("Scope")]
        public BidScopeEnum Scope { get; set; }
    }
}
