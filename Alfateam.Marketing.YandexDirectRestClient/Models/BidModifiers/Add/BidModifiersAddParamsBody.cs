using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add
{
    public class BidModifiersAddParamsBody
    {
        [JsonProperty("BidModifiers")]
        public List<BidModifierAddItem> BidModifiers { get; set; } = new List<BidModifierAddItem>();
    }
}
