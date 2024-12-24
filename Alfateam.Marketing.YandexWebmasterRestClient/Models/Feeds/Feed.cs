using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds
{
    public class Feed
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("type")]
        public FeedType Type { get; set; }

        [JsonProperty("regionIds")]
        public List<int> RegionIds { get; set; } = new List<int>();
    }
}
