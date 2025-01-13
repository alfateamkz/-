using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add
{
    public class DemographicsAdjustmentAdd
    {
        [JsonProperty("Gender")]
        public GenderEnum Gender { get; set; }

        [JsonProperty("Age")]
        public AgeRangeEnum Age { get; set; }

        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }
    }
}
