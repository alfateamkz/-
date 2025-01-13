using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Add
{
    public class StrategyAverageCpaPerCampaignAdd
    {
        [JsonProperty("AverageCpa")]
        public long AverageCpa { get; set; }

        [JsonProperty("GoalId")]
        public long GoalId { get; set; }

        [JsonProperty("WeeklySpendLimit")]
        public long WeeklySpendLimit { get; set; }

        [JsonProperty("CustomPeriodBudget")]
        public CustomPeriodBudget CustomPeriodBudget { get; set; }

        [JsonProperty("BidCeiling")]
        public long BidCeiling { get; set; }

        [JsonProperty("ExplorationBudget")]
        public ExplorationBudget ExplorationBudget { get; set; }
    }
}
