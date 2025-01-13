using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Get
{
    public class FeedGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("BusinessType")]
        public BusinessTypeEnum BusinessType { get; set; }

        [JsonProperty("SourceType")]
        public SourceTypeEnum SourceType { get; set; }

        [JsonProperty("FilterSchema")]
        public string FilterSchema { get; set; }

        [JsonProperty("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("CampaignIds")]
        public ArrayOfLong CampaignIds { get; set; }

        [JsonProperty("FileFeed")]
        public FileFeedGet FileFeed { get; set; }

        [JsonProperty("NumberOfItems")]
        public int NumberOfItems { get; set; }

        [JsonProperty("Status")]
        public FeedStatusEnum Status { get; set; }

        [JsonProperty("UrlFeed")]
        public UrlFeedGet UrlFeed { get; set; }

        [JsonProperty("TitleAndTextSources")]
        public ArrayOfString TitleAndTextSources { get; set; }
    }
}
