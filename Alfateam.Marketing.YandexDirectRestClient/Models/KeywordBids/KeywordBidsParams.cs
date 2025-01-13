using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordBids;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids
{
    public class KeywordBidsParams<T>
    {
        [JsonProperty("method")]
        public KeywordBidsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
