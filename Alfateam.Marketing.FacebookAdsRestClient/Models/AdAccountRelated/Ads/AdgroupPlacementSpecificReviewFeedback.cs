using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Ads
{
    public class AdgroupPlacementSpecificReviewFeedback
    {
        [JsonProperty("account_admin")]
        public Dictionary<string, string> AccountAdmin { get; set; } = new Dictionary<string, string>();

        [JsonProperty("ad")]
        public Dictionary<string, string> Ad { get; set; } = new Dictionary<string, string>();

        [JsonProperty("ads_conversion_experiences")]
        public Dictionary<string, string> AdsConversionExperiences { get; set; } = new Dictionary<string, string>();

        [JsonProperty("b2c")]
        public Dictionary<string, string> B2C { get; set; } = new Dictionary<string, string>();

        [JsonProperty("b2c_commerce_unified")]
        public Dictionary<string, string> B2CCommerceUnified { get; set; } = new Dictionary<string, string>();

        [JsonProperty("bsg")]
        public Dictionary<string, string> BSG { get; set; } = new Dictionary<string, string>();

        [JsonProperty("city_community")]
        public Dictionary<string, string> CityCommunity { get; set; } = new Dictionary<string, string>();

        [JsonProperty("commerce")]
        public Dictionary<string, string> Commerce { get; set; } = new Dictionary<string, string>();

        [JsonProperty("compromise")]
        public Dictionary<string, string> Compromise { get; set; } = new Dictionary<string, string>();

        [JsonProperty("daily_deals")]
        public Dictionary<string, string> DailyDeals { get; set; } = new Dictionary<string, string>();

        [JsonProperty("daily_deals_legacy")]
        public Dictionary<string, string> DailyDealsLegacy { get; set; } = new Dictionary<string, string>();

        [JsonProperty("dpa")]
        public Dictionary<string, string> DPA { get; set; } = new Dictionary<string, string>();

        [JsonProperty("dri_copyright")]
        public Dictionary<string, string> DRICopyright { get; set; } = new Dictionary<string, string>();

        [JsonProperty("dri_counterfeit")]
        public Dictionary<string, string> DRICounterfeit { get; set; } = new Dictionary<string, string>();

        [JsonProperty("facebook")]
        public Dictionary<string, string> Facebook { get; set; } = new Dictionary<string, string>();

        [JsonProperty("facebook_pages_live_shopping")]
        public Dictionary<string, string> FacebookPagesLiveShopping { get; set; } = new Dictionary<string, string>();

        [JsonProperty("independent_work")]
        public Dictionary<string, string> IndependentWork { get; set; } = new Dictionary<string, string>();

        [JsonProperty("instagram")]
        public Dictionary<string, string> Instagram { get; set; } = new Dictionary<string, string>();

        [JsonProperty("instagram_shop")]
        public Dictionary<string, string> InstagramShop { get; set; } = new Dictionary<string, string>();

        [JsonProperty("job_search")]
        public Dictionary<string, string> JobSearch { get; set; } = new Dictionary<string, string>();

        [JsonProperty("lead_gen_honeypot")]
        public Dictionary<string, string> LeadGenHoneypot { get; set; } = new Dictionary<string, string>();

        [JsonProperty("marketplace")]
        public Dictionary<string, string> Marketplace { get; set; } = new Dictionary<string, string>();

        [JsonProperty("marketplace_home_rentals")]
        public Dictionary<string, string> MarketplaceHomeRentals { get; set; } = new Dictionary<string, string>();

        [JsonProperty("marketplace_home_sales")]
        public Dictionary<string, string> MarketplaceHomeSales { get; set; } = new Dictionary<string, string>();

        [JsonProperty("marketplace_motors")]
        public Dictionary<string, string> MarketplaceMotors { get; set; } = new Dictionary<string, string>();

        [JsonProperty("marketplace_shops")]
        public Dictionary<string, string> MarketplaceShops { get; set; } = new Dictionary<string, string>();

        [JsonProperty("neighborhoods")]
        public Dictionary<string, string> Neighborhoods { get; set; } = new Dictionary<string, string>();

        [JsonProperty("page_admin")]
        public Dictionary<string, string> PageAdmin { get; set; } = new Dictionary<string, string>();

        [JsonProperty("product")]
        public Dictionary<string, string> Product { get; set; } = new Dictionary<string, string>();

        [JsonProperty("product_service")]
        public Dictionary<string, string> ProductService { get; set; } = new Dictionary<string, string>();

        [JsonProperty("profile")]
        public Dictionary<string, string> Profile { get; set; } = new Dictionary<string, string>();

        [JsonProperty("seller")]
        public Dictionary<string, string> Seller { get; set; } = new Dictionary<string, string>();

        [JsonProperty("shops")]
        public Dictionary<string, string> Shops { get; set; } = new Dictionary<string, string>();

        [JsonProperty("traffic_quality")]
        public Dictionary<string, string> TrafficQuality { get; set; } = new Dictionary<string, string>();

        [JsonProperty("unified_commerce_content")]
        public Dictionary<string, string> UnifiedCommerceContent { get; set; } = new Dictionary<string, string>();

        [JsonProperty("whatsapp")]
        public Dictionary<string, string> Whatsapp { get; set; } = new Dictionary<string, string>();
    }
}
