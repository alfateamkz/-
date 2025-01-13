using Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies;
using Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Get
{
    public class StrategiesGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("AttributionModel")]
        public AttributionModelEnum AttributionModel { get; set; }

        [JsonProperty("Type")]
        public StrategyTypeEnum Type { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CounterIds")]
        public ArrayOfLong CounterIds { get; set; }

        [JsonProperty("PriorityGoals")]
        public PriorityGoalsArray PriorityGoals { get; set; }

        [JsonProperty("WbMaximumClicks")]
        public StrategyMaximumClicksGet WbMaximumClicks { get; set; }

        [JsonProperty("WbMaximumConversionRate")]
        public StrategyMaximumConversionRateGet WbMaximumConversionRate { get; set; }

        [JsonProperty("AverageCpc")]
        public StrategyAverageCpcGet AverageCpc { get; set; }

        [JsonProperty("AverageCpa")]
        public StrategyAverageCpaGet AverageCpa { get; set; }

        [JsonProperty("PayForConversion")]
        public StrategyPayForConversionGet PayForConversion { get; set; }

        [JsonProperty("AverageCpaPerCampaign")]
        public StrategyAverageCpaPerCampaignGet AverageCpaPerCampaign { get; set; }

        [JsonProperty("PayForConversionPerCampaign")]
        public StrategyPayForConversionPerCampaignGet PayForConversionPerCampaign { get; set; }

        [JsonProperty("PayForConversionPerFilter")]
        public StrategyPayForConversionPerFilterGet PayForConversionPerFilter { get; set; }

        [JsonProperty("AverageCpaPerFilter")]
        public StrategyAverageCpaPerFilterGet AverageCpaPerFilter { get; set; }

        [JsonProperty("AverageCpcPerCampaign")]
        public StrategyAverageCpcPerCampaignGet AverageCpcPerCampaign { get; set; }

        [JsonProperty("AverageCpcPerFilter")]
        public StrategyAverageCpcPerFilterGet AverageCpcPerFilter { get; set; }

        [JsonProperty("AverageCrr")]
        public StrategyAverageCrrGet AverageCrr { get; set; }

        [JsonProperty("PayForConversionCrr")]
        public StrategyPayForConversionCrrGet PayForConversionCrr { get; set; }
    }
}
