using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class PriceExtensionAddItem
    {
        [JsonProperty("Price")]
        public long Price { get; set; }

        [JsonProperty("OldPrice")]
        public long OldPrice { get; set; }

        [JsonProperty("PriceQualifier")]
        public PriceQualifier PriceQualifier { get; set; }

        [JsonProperty("PriceCurrency")]
        public string PriceCurrency { get; set; }
    }
}
