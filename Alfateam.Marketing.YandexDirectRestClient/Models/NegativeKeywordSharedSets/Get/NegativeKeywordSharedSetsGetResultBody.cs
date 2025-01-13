using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.NegativeKeywordSharedSets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.NegativeKeywordSharedSets.Get
{
    public class NegativeKeywordSharedSetsGetResultBody
    {
        [JsonProperty("NegativeKeywordSharedSets")]
        public List<NegativeKeywordSharedSetGetItem> NegativeKeywordSharedSets { get; set; } = new List<NegativeKeywordSharedSetGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
