using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Get
{
    public class BidModifiersGetResultBody
    {
        [JsonProperty("BidModifiers")]
        public List<BidModifierGetItem> BidModifiers { get; set; } = new List<BidModifierGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
