using Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchAdd;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchDelete
{
    public class FeedsBatchDeleteResponse
    {
        [JsonProperty("feeds")]
        public List<FeedsBatchDeleteResponseResult> Feeds { get; set; } = new List<FeedsBatchDeleteResponseResult>();
    }
}
