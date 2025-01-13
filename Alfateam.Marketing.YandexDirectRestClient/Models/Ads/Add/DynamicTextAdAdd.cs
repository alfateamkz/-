using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class DynamicTextAdAdd
    {
        [JsonProperty("VCardId")]
        public long VCardId { get; set; }

        [JsonProperty("AdImageHash")]
        public string AdImageHash { get; set; }

        [JsonProperty("SitelinkSetId")]
        public long SitelinkSetId { get; set; }

        [JsonProperty("AdExtensionIds")]
        public List<long> AdExtensionIds { get; set; } = new List<long>();

        [JsonProperty("Text")]
        public string Text { get; set; }
    }
}
