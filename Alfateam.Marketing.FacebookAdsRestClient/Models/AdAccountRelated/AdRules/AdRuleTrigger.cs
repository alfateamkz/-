using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdRules
{
    public class AdRuleTrigger
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("operator")]
        public AdRuleEvaluationSpecType Operator { get; set; }

        [JsonProperty("type")]
        public AdRuleTriggerType Type { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; } //(list) or (map) or (string)
    }
}
