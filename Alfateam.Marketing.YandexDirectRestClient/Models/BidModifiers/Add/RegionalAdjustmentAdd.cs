using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add
{
    public class RegionalAdjustmentAdd
    {
        [JsonProperty("RegionId")]
        public long RegionId { get; set; }

        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }
    }
}
