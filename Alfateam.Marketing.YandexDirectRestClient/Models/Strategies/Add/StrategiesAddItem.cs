using Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Add
{
    public class StrategiesAddItem
    {
        [JsonProperty("AttributionModel")]
        public AttributionModelEnum AttributionModel { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CounterIds")]
        public ArrayOfLong CounterIds { get; set; }

        [JsonProperty("PriorityGoals")]
        public PriorityGoalsArray PriorityGoals { get; set; }

        [JsonProperty("WbMaximumClicks")]
        public StrategyMaximumClicksAdd WbMaximumClicks { get; set; }

        [JsonProperty("WbMaximumConversionRate")]
        public StrategyMaximumConversionRateAdd WbMaximumConversionRate { get; set; }

        [JsonProperty("AverageCpc")]
        public StrategyAverageCpcAdd AverageCpc { get; set; }

        [JsonProperty("AverageCpa")]
        public StrategyAverageCpaAdd AverageCpa { get; set; }

        [JsonProperty("PayForConversion")]
        public StrategyPayForConversionAdd PayForConversion { get; set; }

        [JsonProperty("AverageCpaPerCampaign")]
        public StrategyAverageCpaPerCampaignAdd AverageCpaPerCampaign { get; set; }

        [JsonProperty("PayForConversionPerCampaign")]
        public StrategyPayForConversionPerCampaignAdd PayForConversionPerCampaign { get; set; }

        [JsonProperty("PayForConversionPerFilter")]
        public StrategyPayForConversionPerFilterAdd PayForConversionPerFilter { get; set; }

        [JsonProperty("AverageCpaPerFilter")]
        public StrategyAverageCpaPerFilterAdd AverageCpaPerFilter { get; set; }

        [JsonProperty("AverageCpcPerCampaign")]
        public StrategyAverageCpcPerCampaignAdd AverageCpcPerCampaign { get; set; }

        [JsonProperty("AverageCpcPerFilter")]
        public StrategyAverageCpcPerFilterAdd AverageCpcPerFilter { get; set; }

        [JsonProperty("AverageCrr")]
        public StrategyAverageCrrAdd AverageCrr { get; set; }

        [JsonProperty("PayForConversionCrr")]
        public StrategyPayForConversionCrrAdd PayForConversionCrr { get; set; }
    }
}
