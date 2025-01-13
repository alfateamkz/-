using Alfateam.Marketing.YandexDirectRestClient.Enums.NegativeKeywordSharedSets;
using Alfateam.Marketing.YandexDirectRestClient.Enums.RetargetingLists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.NegativeKeywordSharedSets
{
    public class NegativeKeywordSharedSetsParams<T>
    {
        [JsonProperty("method")]
        public NegativeKeywordSharedSetsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
