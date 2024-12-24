using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchDelete
{
    public class FeedsBatchDeleteResponseResult
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("status")]
        public FeedDeletionStatus Status { get; set; }
    }
}
