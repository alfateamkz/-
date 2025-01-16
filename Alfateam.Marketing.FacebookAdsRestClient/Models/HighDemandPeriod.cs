using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models
{
    public class HighDemandPeriod
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("budget_value")]
        public int BudgetValue { get; set; }

        [JsonProperty("budget_value_type")]
        public string BudgetValueType { get; set; }

        [JsonProperty("recurrence_type")]
        public string RecurrenceType { get; set; }

        [JsonProperty("time_end")]
        public DateTime TimeEnd { get; set; }

        [JsonProperty("time_start")]
        public DateTime TimeStart { get; set; }
    }
}
