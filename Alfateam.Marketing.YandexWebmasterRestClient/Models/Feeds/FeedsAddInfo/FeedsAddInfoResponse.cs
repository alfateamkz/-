using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsAddInfo
{
    public class FeedsAddInfoResponse
    {
        [JsonProperty("processStatus")]
        public FeedLoadingStatus ProcessStatus { get; set; }
    }
}
