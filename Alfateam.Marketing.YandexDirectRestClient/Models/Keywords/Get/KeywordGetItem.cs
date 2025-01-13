using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Get
{
    public class KeywordGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Keyword")]
        public string Keyword { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("UserParam1")]
        public string UserParam1 { get; set; }

        [JsonProperty("UserParam2")]
        public string UserParam2 { get; set; }

        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("AutotargetingSearchBidIsAuto")]
        public YesNoEnum AutotargetingSearchBidIsAuto { get; set; }

        [JsonProperty("ContextBid")]
        public long ContextBid { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }

        [JsonProperty("State")]
        public KeywordStatusSelectionEnum State { get; set; }

        [JsonProperty("Status")]
        public KeywordStatusEnum Status { get; set; }

        [JsonProperty("ServingStatus")]
        public ServingStatusEnum ServingStatus { get; set; }

        [JsonProperty("Productivity")]
        public object Productivity { get; set; }

        [JsonProperty("StatisticsSearch")]
        public KeywordStatistics StatisticsSearch { get; set; }

        [JsonProperty("StatisticsNetwork")]
        public KeywordStatistics StatisticsNetwork { get; set; }

        [JsonProperty("AutotargetingCategories")]
        public AutotargetingCategoriesList AutotargetingCategories { get; set; }

        [JsonProperty("AutotargetingSettings")]
        public AutotargetingSettingsGetItem AutotargetingSettings { get; set; }
    }
}
