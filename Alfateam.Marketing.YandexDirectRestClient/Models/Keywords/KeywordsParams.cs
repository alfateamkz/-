using Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords;
using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordsResearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords
{
    public class KeywordsParams<T>
    {
        [JsonProperty("method")]
        public KeywordsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
