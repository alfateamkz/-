using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeLinkData
    {
        [JsonProperty("ad_context")]
        public string AdContext { get; set; }

        [JsonProperty("additional_image_index")]
        public int AdditionalImageIndex { get; set; }

        [JsonProperty("app_link_spec")]
        public AdCreativeLinkDataAppLinkSpec AppLinkSpec { get; set; }

        [JsonProperty("attachment_style")]
        public AdCreativeLinkDataAttachmentStyle AttachmentStyle { get; set; }

        [JsonProperty("automated_product_tags")]
        public bool AutomatedProductTags { get; set; }

        [JsonProperty("boosted_product_set_id")]
        public long BoostedProductSetId { get; set; }

        [JsonProperty("branded_content_shared_to_sponsor_status")]
        public string BrandedContentSharedToSponsorStatus { get; set; }

        [JsonProperty("branded_content_sponsor_page_id")]
        public long BrandedContentSponsorPageId { get; set; }

        [JsonProperty("branded_content_sponsor_relationship")]
        public string BrandedContentSponsorRelationship { get; set; }

        [JsonProperty("call_to_action")]
        public AdCreativeLinkDataCallToAction CallToAction { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("child_attachments")]
        public List<AdCreativeLinkDataChildAttachment> ChildAttachments { get; set; } = new List<AdCreativeLinkDataChildAttachment>();

        [JsonProperty("collection_thumbnails")]
        public List<AdCreativeCollectionThumbnailInfo> CollectionThumbnails { get; set; } = new List<AdCreativeCollectionThumbnailInfo>();

        [JsonProperty("customization_rules_spec")]
        public List<AdCustomizationRuleSpec> CustomizationRulesSpec { get; set; } = new List<AdCustomizationRuleSpec>();

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("event_id")]
        public long EventId { get; set; }

        [JsonProperty("force_single_link")]
        public bool ForceSingleLink { get; set; }

        [JsonProperty("format_option")]
        public AdCreativeLinkDataFormatOption FormatOption { get; set; }

        [JsonProperty("image_crops")]
        public AdsImageCrops ImageCrops { get; set; }

        [JsonProperty("image_hash")]
        public string ImageHash { get; set; }

        [JsonProperty("image_layer_specs")]
        public List<AdCreativeLinkDataImageLayerSpec> ImageLayerSpecs { get; set; } = new List<AdCreativeLinkDataImageLayerSpec>();

        [JsonProperty("image_overlay_spec")]
        public AdCreativeLinkDataImageOverlaySpec ImageOverlaySpec { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("multi_share_end_card")]
        public bool MultiShareEndCard { get; set; }

        [JsonProperty("multi_share_optimized")]
        public bool MultiShareOptimized { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("offer_id")]
        public long OfferId { get; set; }

        [JsonProperty("page_welcome_message")]
        public string PageWelcomeMessage { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("post_click_configuration")]
        public AdCreativePostClickConfiguration PostClickConfiguration { get; set; }

        [JsonProperty("preferred_image_tags")]
        public List<string> PreferredImageTags { get; set; } = new List<string>();

        [JsonProperty("preferred_video_tags")]
        public List<string> PreferredVideoTags { get; set; } = new List<string>();

        [JsonProperty("retailer_item_ids")]
        public List<string> RetailerItemIds { get; set; } = new List<string>();

        [JsonProperty("show_multiple_images")]
        public bool ShowMultipleImages { get; set; }

        [JsonProperty("sponsorship_info")]
        public AdCreativeLinkDataSponsorshipInfoSpec SponsorshipInfo { get; set; }

        [JsonProperty("static_fallback_spec")]
        public AdCreativeStaticFallbackSpec StaticFallbackSpec { get; set; }

        [JsonProperty("use_flexible_image_aspect_ratio")]
        public bool UseFlexibleImageAspectRatio { get; set; }
    }
}
