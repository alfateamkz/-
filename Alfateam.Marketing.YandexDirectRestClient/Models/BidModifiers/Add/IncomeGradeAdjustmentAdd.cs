using Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add
{
    public class IncomeGradeAdjustmentAdd
    {
        [JsonProperty("Grade")]
        public IncomeGradeEnum Grade { get; set; }

        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }
    }
}
