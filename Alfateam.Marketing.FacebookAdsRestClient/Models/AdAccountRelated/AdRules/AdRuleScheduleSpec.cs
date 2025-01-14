using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdRules
{
    public class AdRuleScheduleSpec
    {
        [JsonProperty("schedule")]
        public List<AdRuleSchedule> Schedule { get; set; } = new List<AdRuleSchedule>();

        [JsonProperty("schedule_type")]
        public AdRuleScheduleSpecType ScheduleType { get; set; }
    }
}
