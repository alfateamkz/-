using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdRules
{
    public class AdRuleExecutionSpec
    {
        [JsonProperty("execution_options")]
        public List<AdRuleExecutionOptions> ExecutionOptions { get; set; } = new List<AdRuleExecutionOptions>();

        [JsonProperty("execution_type")]
        public AdRuleExecutionSpecType ExecutionType { get; set; }
    }
}
