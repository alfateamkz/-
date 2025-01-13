using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class ListingAdAdd
    {
        [JsonProperty("SitelinkSetId")]
        public long SitelinkSetId { get; set; }

        [JsonProperty("AdExtensionIds")]
        public List<long> AdExtensionIds { get; set; } = new List<long>();

        [JsonProperty("BusinessId")]
        public long BusinessId { get; set; }

        [JsonProperty("FeedId")]
        public long FeedId { get; set; }

        [JsonProperty("FeedFilterConditions")]
        public List<FeedFilterCondition> FeedFilterConditions { get; set; } = new List<FeedFilterCondition>();

        [JsonProperty("TitleSources")]
        public List<string> TitleSources { get; set; } = new List<string>();

        [JsonProperty("TextSources")]
        public List<string> TextSources { get; set; } = new List<string>();

        [JsonProperty("DefaultTexts")]
        public List<string> DefaultTexts { get; set; } = new List<string>();
    }
}
