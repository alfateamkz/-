using Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Get
{
    public class FeedsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public FeedSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<FeedFieldEnum> FieldNames { get; set; } = Enum.GetValues<FeedFieldEnum>().ToList();

        [JsonProperty("FileFeedFieldNames")]
        public List<FileFeedFieldEnum> FileFeedFieldNames { get; set; } = Enum.GetValues<FileFeedFieldEnum>().ToList();

        [JsonProperty("UrlFeedFieldNames")]
        public List<UrlFeedFieldEnum> UrlFeedFieldNames { get; set; } = Enum.GetValues<UrlFeedFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
