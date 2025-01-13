using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicFeedAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicFeedAdTargets.Get
{
    public class DynamicFeedAdTargetsGetParamsBody
    {
        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }

        [JsonProperty("SelectionCriteria")]
        public DynamicFeedAdTargetsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<DynamicFeedAdTargetFieldEnum> FieldNames { get; set; } = Enum.GetValues<DynamicFeedAdTargetFieldEnum>().ToList();
    }
}
