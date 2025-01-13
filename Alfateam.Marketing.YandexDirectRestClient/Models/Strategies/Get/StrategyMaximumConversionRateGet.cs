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
    public class StrategyMaximumConversionRateGet : StrategyMaximumConversionRateAdd
    {
        [JsonProperty("BudgetType")]
        public BudgetTypeEnum BudgetType { get; set; }
    }
}
