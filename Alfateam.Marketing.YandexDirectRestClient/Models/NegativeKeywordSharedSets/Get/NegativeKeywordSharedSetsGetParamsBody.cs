using Alfateam.Marketing.YandexDirectRestClient.Enums.NegativeKeywordSharedSets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.NegativeKeywordSharedSets.Get
{
    public class NegativeKeywordSharedSetsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public IdsCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<NegativeKeywordSharedSetFieldEnum> FieldNames { get; set; } = new List<NegativeKeywordSharedSetFieldEnum>();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
