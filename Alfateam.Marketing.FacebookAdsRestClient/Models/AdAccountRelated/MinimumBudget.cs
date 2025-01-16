using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class MinimumBudget
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("min_daily_budget_high_freq")]
        public int MinDailyBudgetHighFreq { get; set; }

        [JsonProperty("min_daily_budget_imp")]
        public int MinDailyBudgetImp { get; set; }

        [JsonProperty("min_daily_budget_low_freq")]
        public int MinDailyBudgetLowFreq { get; set; }

        [JsonProperty("min_daily_budget_video_views")]
        public int MinDailyBudgetVideoViews { get; set; }
    }
}
