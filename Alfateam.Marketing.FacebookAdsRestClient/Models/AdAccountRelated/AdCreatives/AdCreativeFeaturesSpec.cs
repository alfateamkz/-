using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeFeaturesSpec
    {
        [JsonProperty("adapt_to_placement")]
        public AdCreativeFeatureDetails AdaptToPlacement { get; set; }

        [JsonProperty("add_text_overlay")]
        public AdCreativeFeatureDetails AddTextOverlay { get; set; }

        [JsonProperty("ads_with_benefits")]
        public AdCreativeFeatureDetails AdsWithBenefits { get; set; }

        [JsonProperty("customize_product_recommendation")]
        public AdCreativeFeatureDetails CustomizeProductRecommendation { get; set; }

        [JsonProperty("description_automation")]
        public AdCreativeFeatureDetails DescriptionAutomation { get; set; }

        [JsonProperty("fb_feed_tag")]
        public AdCreativeFeatureDetails FBFeedTag { get; set; }

        [JsonProperty("fb_reels_tag")]
        public AdCreativeFeatureDetails FBReelsTag { get; set; }

        [JsonProperty("fb_story_tag")]
        public AdCreativeFeatureDetails FBStoryTag { get; set; }

        [JsonProperty("ig_feed_tag")]
        public AdCreativeFeatureDetails IGFeedTag { get; set; }

        [JsonProperty("ig_reels_tag")]
        public AdCreativeFeatureDetails IGReelsTag { get; set; }

        [JsonProperty("ig_stream_tag")]
        public AdCreativeFeatureDetails IGStreamTag { get; set; }

        [JsonProperty("image_animation")]
        public AdCreativeFeatureDetails ImageAnimation { get; set; }

        [JsonProperty("image_background_gen")]
        public AdCreativeFeatureDetails ImageBackgroundGen { get; set; }

        [JsonProperty("image_templates")]
        public AdCreativeFeatureDetails ImageTemplates { get; set; }

        [JsonProperty("image_touchups")]
        public AdCreativeFeatureDetails ImageTouchups { get; set; }

        [JsonProperty("inline_comment")]
        public AdCreativeFeatureDetails InlineComment { get; set; }

        [JsonProperty("local_store_extension")]
        public AdCreativeFeatureDetails LocalStoreExtension { get; set; }

        [JsonProperty("media_type_automation")]
        public AdCreativeFeatureDetails MediaTypeAutomation { get; set; }

        [JsonProperty("multi_photo_to_video")]
        public AdCreativeFeatureDetails MultiPhotoToVideo { get; set; }

        [JsonProperty("pac_relaxation")]
        public AdCreativeFeatureDetails PacRelaxation { get; set; }

        [JsonProperty("product_extensions")]
        public AdCreativeFeatureDetails ProductExtensions { get; set; }

        [JsonProperty("profile_card")]
        public AdCreativeFeatureDetails ProfileCard { get; set; }

        [JsonProperty("site_extensions")]
        public AdCreativeFeatureDetails SiteExtensions { get; set; }

        [JsonProperty("standard_enhancements")]
        public AdCreativeFeatureDetails StandardEnhancements { get; set; }

        [JsonProperty("standard_enhancements_catalog")]
        public AdCreativeFeatureDetails StandardEnhancementsCatalog { get; set; }

        [JsonProperty("text_optimizations")]
        public AdCreativeFeatureDetails TextOptimizations { get; set; }
    }
}
