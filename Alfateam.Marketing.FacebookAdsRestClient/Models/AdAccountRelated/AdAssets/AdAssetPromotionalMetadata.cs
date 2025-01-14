using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetPromotionalMetadata
    {
        [JsonProperty("allowed_coupon_code_sources")]
        public List<AllowedCouponCodeSource> AllowedCouponCodeSources { get; set; } = new List<AllowedCouponCodeSource>();

        [JsonProperty("coupon_codes")]
        public AdAssetPromotionalMetadataCouponCodes CouponCodes { get; set; }

        [JsonProperty("excluded_offers")]
        public List<string> ExcludedOffers { get; set; } = new List<string>();

        [JsonProperty("manual_coupon_codes")]
        public List<string> ManualCouponCodes { get; set; } = new List<string>();
    }
}
