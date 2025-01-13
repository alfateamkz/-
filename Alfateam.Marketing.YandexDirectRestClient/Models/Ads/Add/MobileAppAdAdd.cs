using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class MobileAppAdAdd
    {
        [JsonProperty("AdImageHash")]
        public string AdImageHash { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("TrackingUrl")]
        public string TrackingUrl { get; set; }

        [JsonProperty("Action")]
        public MobileAppAdActionEnum Action { get; set; }

        [JsonProperty("Features")]
        public List<MobileAppAdFeatureItem> Features { get; set; } = new List<MobileAppAdFeatureItem>();

        [JsonProperty("AgeLabel")]
        public MobAppAgeLabelEnum AgeLabel { get; set; }

        [JsonProperty("VideoExtension")]
        public VideoExtensionAddItem VideoExtension { get; set; }

        [JsonProperty("ErirAdDescription")]
        public string ErirAdDescription { get; set; }
    }
}
