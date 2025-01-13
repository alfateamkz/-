using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get
{
    public class BidGetItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("KeywordId")]
        public long KeywordId { get; set; }

        [JsonProperty("ServingStatus")]
        public ServingStatusEnum ServingStatus { get; set; }

        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("AutotargetingSearchBidIsAuto")]
        public YesNoEnum AutotargetingSearchBidIsAuto { get; set; }

        [JsonProperty("ContextBid")]
        public long ContextBid { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }

        [JsonProperty("CompetitorsBids")]
        public List<long> CompetitorsBids { get; set; } = new List<long>();

        [JsonProperty("SearchPrices")]
        public List<SearchPrices> SearchPrices { get; set; } = new List<SearchPrices>();

        [JsonProperty("ContextCoverage")]
        public ContextCoverage ContextCoverage { get; set; }

        [JsonProperty("MinSearchPrice")]
        public long MinSearchPrice { get; set; }

        [JsonProperty("CurrentSearchPrice")]
        public long CurrentSearchPrice { get; set; }

        [JsonProperty("AuctionBids")]
        public List<AuctionBidItem> AuctionBids { get; set; } = new List<AuctionBidItem>();
    }
}
