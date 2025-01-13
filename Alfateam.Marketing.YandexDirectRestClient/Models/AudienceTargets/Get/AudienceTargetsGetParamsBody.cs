using Alfateam.Marketing.YandexDirectRestClient.Enums.AudienceTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets.Get
{
    public class AudienceTargetsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public AudienceTargetSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<AudienceTargetFieldEnum> FieldNames { get; set; } = Enum.GetValues<AudienceTargetFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
