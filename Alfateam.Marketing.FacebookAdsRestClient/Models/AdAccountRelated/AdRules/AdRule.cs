using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdRules
{
    public class AdRule
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("created_by")]
        public User CreatedBy { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("disable_error_code")]
        public int DisableErrorCode { get; set; }

        [JsonProperty("evaluation_spec")]
        public AdRuleEvaluationSpec EvaluationSpec { get; set; }

        [JsonProperty("execution_spec")]
        public AdRuleExecutionSpec ExecutionSpec { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("schedule_spec")]
        public AdRuleScheduleSpec ScheduleSpec { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
