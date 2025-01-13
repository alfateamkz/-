using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Add
{
    public class FeedAddItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("BusinessType")]
        public BusinessTypeEnum BusinessType { get; set; }

        [JsonProperty("SourceType")]
        public SourceTypeEnum SourceType { get; set; }

        [JsonProperty("UrlFeed")]
        public UrlFeedAdd UrlFeed { get; set; }

        [JsonProperty("FileFeed")]
        public FileFeedAdd FileFeed { get; set; }
    }
}
