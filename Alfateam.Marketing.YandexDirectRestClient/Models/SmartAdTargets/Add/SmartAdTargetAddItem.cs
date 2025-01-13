using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.SmartAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.Add
{
    public class SmartAdTargetAddItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("AverageCpc")]
        public long AverageCpc { get; set; }

        [JsonProperty("AverageCpa")]
        public long AverageCpa { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }

        [JsonProperty("Audience")]
        public AudienceEnum Audience { get; set; }

        [JsonProperty("Conditions")]
        public ConditionsArray Conditions { get; set; }

        [JsonProperty("AvailableItemsOnly")]
        public YesNoEnum AvailableItemsOnly { get; set; }
    }
}
