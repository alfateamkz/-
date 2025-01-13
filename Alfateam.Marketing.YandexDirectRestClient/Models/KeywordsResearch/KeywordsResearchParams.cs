using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordsResearch;
using Alfateam.Marketing.YandexDirectRestClient.Enums.NegativeKeywordSharedSets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch
{
    public class KeywordsResearchParams<T>
    {
        [JsonProperty("method")]
        public KeywordsResearchMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
