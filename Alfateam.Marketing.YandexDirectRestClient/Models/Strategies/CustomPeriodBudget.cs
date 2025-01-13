using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies
{
    public class CustomPeriodBudget
    {
        [JsonProperty("SpendLimit")]
        public long SpendLimit { get; set; }

        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("EndDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("AutoContinue")]
        public YesNoEnum AutoContinue { get; set; }
    }
}
