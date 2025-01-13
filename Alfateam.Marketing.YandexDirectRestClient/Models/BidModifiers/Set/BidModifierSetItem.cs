using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Set
{
    public class BidModifierSetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }
    }
}
