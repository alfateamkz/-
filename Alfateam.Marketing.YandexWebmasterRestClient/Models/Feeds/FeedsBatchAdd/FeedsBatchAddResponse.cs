using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchAdd
{
    public class FeedsBatchAddResponse
    {
        [JsonProperty("feeds")]
        public List<FeedsBatchAddResponseResult> Feeds { get; set; } = new List<FeedsBatchAddResponseResult>();
    }
}
