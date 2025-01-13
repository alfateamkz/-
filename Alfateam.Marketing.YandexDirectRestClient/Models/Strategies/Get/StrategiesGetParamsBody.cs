using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Get
{
    public class StrategiesGetParamsBody
    {
        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }

        [JsonProperty("SelectionCriteria")]
        public StrategiesGetSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<CampaignFieldEnum> FieldNames { get; set; } = Enum.GetValues<CampaignFieldEnum>().ToList();

        [JsonProperty("StrategyMaximumClicksFieldNames")]
        public List<StrategyMaximumClicksFieldNames> StrategyMaximumClicksFieldNames { get; set; } = Enum.GetValues<StrategyMaximumClicksFieldNames>().ToList();

        [JsonProperty("StrategyMaximumConversionRateFieldNames")]
        public List<StrategyMaximumConversionRateFieldNames> StrategyMaximumConversionRateFieldNames { get; set; } = Enum.GetValues<StrategyMaximumConversionRateFieldNames>().ToList();

        [JsonProperty("StrategyAverageCpcFieldNames")]
        public List<StrategyAverageCpcFieldNames> StrategyAverageCpcFieldNames { get; set; } = Enum.GetValues<StrategyAverageCpcFieldNames>().ToList();

        [JsonProperty("StrategyAverageCpaFieldNames")]
        public List<StrategyAverageCpaFieldNames> StrategyAverageCpaFieldNames { get; set; } = Enum.GetValues<StrategyAverageCpaFieldNames>().ToList();

        [JsonProperty("StrategyPayForConversionFieldNames")]
        public List<StrategyPayForConversionFieldNames> StrategyPayForConversionFieldNames { get; set; } = Enum.GetValues<StrategyPayForConversionFieldNames>().ToList();

        [JsonProperty("StrategyAverageCpaPerCampaignFieldNames")]
        public List<StrategyAverageCpaPerCampaignFieldNames> StrategyAverageCpaPerCampaignFieldNames { get; set; } = Enum.GetValues<StrategyAverageCpaPerCampaignFieldNames>().ToList();

        [JsonProperty("StrategyPayForConversionPerCampaignFieldNames")]
        public List<StrategyPayForConversionPerCampaignFieldNames> StrategyPayForConversionPerCampaignFieldNames { get; set; } = Enum.GetValues<StrategyPayForConversionPerCampaignFieldNames>().ToList();

        [JsonProperty("StrategyPayForConversionPerFilterFieldNames")]
        public List<StrategyPayForConversionPerFilterFieldNames> StrategyPayForConversionPerFilterFieldNames { get; set; } = Enum.GetValues<StrategyPayForConversionPerFilterFieldNames>().ToList();

        [JsonProperty("StrategyAverageCpaPerFilterFieldNames")]
        public List<StrategyAverageCpaPerFilterFieldNames> StrategyAverageCpaPerFilterFieldNames { get; set; } = Enum.GetValues<StrategyAverageCpaPerFilterFieldNames>().ToList();

        [JsonProperty("StrategyAverageCpcPerCampaignFieldNames")]
        public List<StrategyAverageCpcPerCampaignFieldNames> StrategyAverageCpcPerCampaignFieldNames { get; set; } = Enum.GetValues<StrategyAverageCpcPerCampaignFieldNames>().ToList();

        [JsonProperty("StrategyAverageCpcPerFilterFieldNames")]
        public List<StrategyAverageCpcPerFilterFieldNames> StrategyAverageCpcPerFilterFieldNames { get; set; } = Enum.GetValues<StrategyAverageCpcPerFilterFieldNames>().ToList();

        [JsonProperty("StrategyAverageCrrFieldNames")]
        public List<StrategyAverageCrrFieldNames> StrategyAverageCrrFieldNames { get; set; } = Enum.GetValues<StrategyAverageCrrFieldNames>().ToList();

        [JsonProperty("StrategyPayForConversionCrrFieldNames")]
        public List<StrategyPayForConversionCrrFieldNames> StrategyPayForConversionCrrFieldNames { get; set; } = Enum.GetValues<StrategyPayForConversionCrrFieldNames>().ToList();
    }
}
