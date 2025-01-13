using Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Toggle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Set
{
    public class BidModifiersSetParamsBody
    {
        [JsonProperty("BidModifiers")]
        public List<BidModifierSetItem> BidModifiers { get; set; } = new List<BidModifierSetItem>();
    }
}
