using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Get
{
    public class RetargetingAdjustmentGet
    {
        [JsonProperty("RetargetingConditionId")]
        public long RetargetingConditionId { get; set; }

        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }

        [JsonProperty("Accessible")]
        public YesNoEnum Accessible { get; set; }

        [JsonProperty("Enabled")]
        public YesNoEnum Enabled { get; set; }
    }
}
