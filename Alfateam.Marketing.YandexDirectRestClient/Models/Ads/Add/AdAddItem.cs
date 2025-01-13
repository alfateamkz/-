using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class AdAddItem
    {
        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("TextAd")]
        public TextAdAdd TextAd { get; set; }

        [JsonProperty("DynamicTextAd")]
        public DynamicTextAdAdd DynamicTextAd { get; set; }

        [JsonProperty("MobileAppAd")]
        public MobileAppAdAdd MobileAppAd { get; set; }

        [JsonProperty("TextImageAd")]
        public TextImageAdAdd TextImageAd { get; set; }

        [JsonProperty("MobileAppImageAd")]
        public MobileAppImageAdAdd MobileAppImageAd { get; set; }

        [JsonProperty("TextAdBuilderAd")]
        public TextAdBuilderAdAdd TextAdBuilderAd { get; set; }

        [JsonProperty("MobileAppAdBuilderAd")]
        public MobileAppAdBuilderAdAdd MobileAppAdBuilderAd { get; set; }

        [JsonProperty("MobileAppCpcVideoAdBuilderAd")]
        public MobileAppCpcVideoAdBuilderAdAdd MobileAppCpcVideoAdBuilderAd { get; set; }

        [JsonProperty("CpmBannerAdBuilderAd")]
        public CpmBannerAdBuilderAdAdd CpmBannerAdBuilderAd { get; set; }

        [JsonProperty("CpcVideoAdBuilderAd")]
        public CpcVideoAdBuilderAdAdd CpcVideoAdBuilderAd { get; set; }

        [JsonProperty("CpmVideoAdBuilderAd")]
        public CpmVideoAdBuilderAdAdd CpmVideoAdBuilderAd { get; set; }

        [JsonProperty("SmartAdBuilderAd")]
        public SmartAdBuilderAdAdd SmartAdBuilderAd { get; set; }

        [JsonProperty("ShoppingAd")]
        public ShoppingAdAdd ShoppingAd { get; set; }

        [JsonProperty("ListingAd")]
        public ListingAdAdd ListingAd { get; set; }
    }
}
