using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Set
{
    public class KeywordBidSetItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("KeywordId")]
        public long KeywordId { get; set; }

        [JsonProperty("SearchBid")]
        public long SearchBid { get; set; }

        [JsonProperty("AutotargetingSearchBidIsAuto")]
        public YesNoEnum AutotargetingSearchBidIsAuto { get; set; }

        [JsonProperty("NetworkBid")]
        public long NetworkBid { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }
    }
}
