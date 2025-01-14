using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdRules
{
    public class AdRuleEvaluationSpec
    {
        [JsonProperty("evaluation_type")]
        public AdRuleEvaluationSpecType EvaluationType { get; set; }

        [JsonProperty("filters")]
        public List<AdRuleFilters> Filters { get; set; } = new List<AdRuleFilters>();

        [JsonProperty("trigger")]
        public AdRuleTrigger Trigger { get; set; }
    }
}
