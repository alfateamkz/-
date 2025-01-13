using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Toggle
{
    public class BidModifiersToggleParamsBody
    {
        [JsonProperty("BidModifierToggleItems")]
        public List<BidModifierToggleItem> BidModifierToggleItems { get; set; } = new List<BidModifierToggleItem>();
    }
}
