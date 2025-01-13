using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class CpmVideoAdBuilderAdAdd
    {
        [JsonProperty("Creative")]
        public AdBuilderAdAddItem Creative { get; set; }

        [JsonProperty("ErirAdDescription")]
        public string ErirAdDescription { get; set; }

        [JsonProperty("Href")]
        public string Href { get; set; }

        [JsonProperty("TrackingPixels")]
        public CpmBannerAdBuilderAdTrackingPixels TrackingPixels { get; set; }

        [JsonProperty("TurboPageId")]
        public long TurboPageId { get; set; }
    }
}
