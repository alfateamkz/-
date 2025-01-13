using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Get
{
    public class MobileAdjustmentGet
    {
        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }

        [JsonProperty("OperatingSystemType")]
        public OperatingSystemTypeEnum? OperatingSystemType { get; set; }
    }
}
