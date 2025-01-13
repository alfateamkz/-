using Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Update
{
    public class FeedUpdateItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("UrlFeed")]
        public UrlFeedUpdate UrlFeed { get; set; }

        [JsonProperty("FileFeed")]
        public FileFeedUpdate FileFeed { get; set; }
    }
}
