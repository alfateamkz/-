using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchAdd
{
    public class FeedsBatchAddResponseResult
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("status")]
        public FeedLoadedStatus Status { get; set; } 
    }
}
