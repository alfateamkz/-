using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies
{
    public class ExplorationBudget
    {
        [JsonProperty("MinimumExplorationBudget")]
        public long MinimumExplorationBudget { get; set; }

        [JsonProperty("IsMinimumExplorationBudgetCustom")]
        public YesNoEnum IsMinimumExplorationBudgetCustom { get; set; }
    }
}
