using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Get
{
    public class SerpLayoutAdjustmentGet
    {
        [JsonProperty("SerpLayout")]
        public SerpLayoutEnum SerpLayout { get; set; }

        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }

        [JsonProperty("Enabled")]
        public YesNoEnum Enabled { get; set; }
    }
}
