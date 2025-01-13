using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Add
{
    public class KeywordAddItem
    {
        [JsonProperty("Keyword")]
        public string Keyword { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("AutotargetingSearchBidIsAuto")]
        public YesNoEnum AutotargetingSearchBidIsAuto { get; set; }

        [JsonProperty("ContextBid")]
        public long ContextBid { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }

        [JsonProperty("UserParam1")]
        public string UserParam1 { get; set; }

        [JsonProperty("UserParam2")]
        public string UserParam2 { get; set; }

        [JsonProperty("AutotargetingCategories")]
        public List<AutotargetingCategoriesItem> AutotargetingCategories { get; set; } = new List<AutotargetingCategoriesItem>();
    }
}
