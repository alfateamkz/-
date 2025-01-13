using Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds;
using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordBids;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds
{
    public class FeedsParams<T>
    {
        [JsonProperty("method")]
        public FeedsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
