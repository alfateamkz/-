using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedSpec
    {
        [JsonProperty("ad_formats")]
        public List<AdFormat> AdFormats { get; set; } = new List<AdFormat>();

        [JsonProperty("additional_data")]
        public AdAssetFeedAdditionalData AdditionalData { get; set; }

        [JsonProperty("app_product_page_id")]
        public string AppProductPageId { get; set; }

        [JsonProperty("asset_customization_rules")]
        public List<AdAssetFeedSpecAssetCustomizationRule> AssetCustomizationRules { get; set; } = new List<AdAssetFeedSpecAssetCustomizationRule>();

        [JsonProperty("audios")]
        public List<AdAssetAudios> Audios { get; set; } = new List<AdAssetAudios>();

        [JsonProperty("autotranslate")]
        public List<string> Autotranslate { get; set; } = new List<string>();

        [JsonProperty("bodies")]
        public List<AdAssetFeedSpecBody> Bodies { get; set; } = new List<AdAssetFeedSpecBody>();

        [JsonProperty("call_ads_configuration")]
        public AdAssetCallAdsConfigurationFeedSpec CallAdsConfiguration { get; set; }

        [JsonProperty("call_to_action_types")]
        public CallToActionType CallToActionTypes { get; set; }

        [JsonProperty("call_to_actions")]
        public List<AdAssetFeedSpecCallToAction> CallToActions { get; set; } = new List<AdAssetFeedSpecCallToAction>();

        [JsonProperty("captions")]
        public List<AdAssetFeedSpecCaption> Captions { get; set; } = new List<AdAssetFeedSpecCaption>();

        [JsonProperty("ctwa_consent_data")]
        public List<AdAssetCtwaConsentData> CTWAConsentData { get; set; } = new List<AdAssetCtwaConsentData>();

        [JsonProperty("descriptions")]
        public List<AdAssetFeedSpecDescription> Descriptions { get; set; } = new List<AdAssetFeedSpecDescription>();

        [JsonProperty("events")]
        public List<AdAssetFeedSpecEvents> Events { get; set; } = new List<AdAssetFeedSpecEvents>();

        [JsonProperty("groups")]
        public List<AdAssetFeedSpecGroupRule> Groups { get; set; } = new List<AdAssetFeedSpecGroupRule>();

        [JsonProperty("images")]
        public List<AdAssetFeedSpecImage> Images { get; set; } = new List<AdAssetFeedSpecImage>();

        [JsonProperty("link_urls")]
        public List<AdAssetFeedSpecLinkURL> LinkURLs { get; set; } = new List<AdAssetFeedSpecLinkURL>();

        [JsonProperty("message_extensions")]
        public List<AdAssetMessageExtensions> MessageExtensions { get; set; } = new List<AdAssetMessageExtensions>();

        [JsonProperty("onsite_destinations")]
        public List<AdAssetOnsiteDestinations> OnsiteDestinations { get; set; } = new List<AdAssetOnsiteDestinations>();

        [JsonProperty("optimization_type")]
        public AssetFeedOptimizationType OptimizationType { get; set; }

        [JsonProperty("promotional_metadata")]
        public AdAssetPromotionalMetadata PromotionalMetadata { get; set; }

        [JsonProperty("reasons_to_shop")]
        public bool ReasonsToShop { get; set; }

        [JsonProperty("shops_bundle")]
        public bool ShopsBundle { get; set; }

        [JsonProperty("titles")]
        public List<AdAssetFeedSpecTitle> Titles { get; set; } = new List<AdAssetFeedSpecTitle>();

        [JsonProperty("upcoming_events")]
        public List<AdAssetUpcomingEvents> UpcomingEvents { get; set; } = new List<AdAssetUpcomingEvents>();

        [JsonProperty("videos")]
        public List<AdAssetFeedSpecVideo> Videos { get; set; } = new List<AdAssetFeedSpecVideo>();
    }

}
