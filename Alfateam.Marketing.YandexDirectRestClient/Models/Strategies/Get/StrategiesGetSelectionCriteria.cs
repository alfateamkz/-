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
    public class StrategiesGetSelectionCriteria : IdsCriteria
    {
        [JsonProperty("Types")]
        public List<StrategyTypeEnum> Types { get; set; } = new List<StrategyTypeEnum>();

        [JsonProperty("IsArchived")]
        public YesNoEnum IsArchived { get; set; }
    }
}
