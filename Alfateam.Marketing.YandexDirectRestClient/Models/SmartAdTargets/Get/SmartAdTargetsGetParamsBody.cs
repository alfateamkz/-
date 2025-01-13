using Alfateam.Marketing.YandexDirectRestClient.Enums.SmartAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.Get
{
    public class SmartAdTargetsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public SmartAdTargetsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<SmartAdTargetFieldEnum> FieldNames { get; set; } = Enum.GetValues<SmartAdTargetFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
