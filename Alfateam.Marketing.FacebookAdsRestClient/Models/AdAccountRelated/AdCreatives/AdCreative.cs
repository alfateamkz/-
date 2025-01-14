using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreative
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("actor_id")]
        public long ActorId { get; set; }

        [JsonProperty("ad_disclaimer_spec")]
        public AdCreativeAdDisclaimer AdDisclaimerSpec { get; set; }

        [JsonProperty("adlabels")]
        public List<AdLabel> AdLabels { get; set; } = new List<AdLabel>();

        [JsonProperty("applink_treatment")]
        public AdCreativeApplinkTreatment ApplinkTreatment { get; set; }

        [JsonProperty("asset_feed_spec")]
        public AdAssetFeedSpec AssetFeed_Spec { get; set; }

        [JsonProperty("authorization_category")]
        public AdCreativeAuthorizationCategory AuthorizationCategory { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("branded_content")]
        public AdCreativeBrandedContentAds BrandedContent { get; set; }

        [JsonProperty("branded_content_sponsor_page_id")]
        public long BrandedContentSponsorPageId { get; set; }

        [JsonProperty("bundle_folder_id")]
        public long BundleFolderId { get; set; }

        [JsonProperty("call_to_action_type")]
        public CallToActionType CallToActionType { get; set; }

        [JsonProperty("categorization_criteria")]
        public AdCreativeCategorizationCriteria CategorizationCriteria { get; set; }

        [JsonProperty("category_media_source")]
        public AdCreativeCategoryMediaSource CategoryMediaSource { get; set; }

        [JsonProperty("collaborative_ads_lsb_image_bank_id")]
        public long CollaborativeAdsLSBImageBankId { get; set; }

        [JsonProperty("contextual_multi_ads")]
        public AdCreativeContextualMultiAds ContextualMultiAds { get; set; }

        [JsonProperty("creative_sourcing_spec")]
        public AdCreativeSourcingSpec CreativeSourcing_spec { get; set; }

        [JsonProperty("degrees_of_freedom_spec")]
        public AdCreativeDegreesOfFreedomSpec DegreesOfFreedomSpec { get; set; }

        [JsonProperty("destination_set_id")]
        public long DestinationSetId { get; set; }

        [JsonProperty("dynamic_ad_voice")]
        public string DynamicAdVoice { get; set; }

        [JsonProperty("effective_authorization_category")]
        public AdCreativeEffectiveAuthorizationCategory EffectiveAuthorizationCategory { get; set; }

        [JsonProperty("effective_instagram_media_id")]
        public long EffectiveInstagramMediaId { get; set; }

        [JsonProperty("effective_instagram_story_id")]
        public long EffectiveInstagramStoryId { get; set; }

        [JsonProperty("effective_object_story_id")]
        public string EffectiveObjectStoryId { get; set; }

        [JsonProperty("enable_direct_install")]
        public bool EnableDirectInstall { get; set; }

        [JsonProperty("enable_launch_instant_app")]
        public bool EnableLaunchInstantApp { get; set; }

        [JsonProperty("facebook_branded_content")]
        public AdCreativeFacebookBrandedContent FacebookBrandedContent { get; set; }

        [JsonProperty("image_crops")]
        public AdsImageCrops ImageCrops { get; set; }

        [JsonProperty("image_hash")]
        public string ImageHash { get; set; }

        [JsonProperty("image_url")]
        public string ImageURL { get; set; }

        [JsonProperty("instagram_actor_id")]
        public long InstagramActorId { get; set; }

        [JsonProperty("instagram_permalink_url")]
        public string InstagramPermalinkURL { get; set; }

        [JsonProperty("instagram_story_id")]
        public long InstagramStoryId { get; set; }

        [JsonProperty("instagram_user_id")]
        public long InstagramUserId { get; set; }

        [JsonProperty("interactive_components_spec")]
        public AdCreativeInteractiveComponentsSpec InteractiveComponentsSpec { get; set; }

        [JsonProperty("link_destination_display_url")]
        public string LinkDestinationDisplayURL { get; set; }

        [JsonProperty("link_og_id")]
        public string LinkOGId { get; set; }

        [JsonProperty("link_url")]
        public string LinkURL { get; set; }

        [JsonProperty("messenger_sponsored_message")]
        public string MessengerSponsoredMessage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("object_id")]
        public long ObjectId { get; set; }

        [JsonProperty("object_store_url")]
        public string ObjectStoreURL { get; set; }

        [JsonProperty("object_story_id")]
        public string ObjectStoryId { get; set; }

        [JsonProperty("object_story_spec")]
        public AdCreativeObjectStorySpec ObjectStorySpec { get; set; }

        [JsonProperty("object_type")]
        public ObjectType ObjectType { get; set; }

        [JsonProperty("object_url")]
        public string ObjectURL { get; set; }

        [JsonProperty("page_welcome_message")]
        public string PageWelcomeMessage { get; set; }

        [JsonProperty("photo_album_source_object_story_id")]
        public string PhotoAlbumSourceObjectStoryId { get; set; }

        [JsonProperty("place_page_set_id")]
        public long PlacePageSetId { get; set; }

        [JsonProperty("platform_customizations")]
        public AdCreativePlatformCustomization PlatformCustomizations { get; set; }

        [JsonProperty("playable_asset_id")]
        public long PlayableAssetId { get; set; }

        [JsonProperty("portrait_customizations")]
        public AdCreativePortraitCustomizations PortraitCustomizations { get; set; }

        [JsonProperty("product_data")]
        public List<AdCreativeProductData> ProductData { get; set; } = new List<AdCreativeProductData>();

        [JsonProperty("product_set_id")]
        public long ProductSetId { get; set; }

        [JsonProperty("recommender_settings")]
        public AdCreativeRecommenderSettings RecommenderSettings { get; set; }

        [JsonProperty("referral_id")]
        public long ReferralId { get; set; }

        [JsonProperty("source_instagram_media_id")]
        public long SourceInstagramMediaId { get; set; }

        [JsonProperty("status")]
        public AdCreativeStatus Status { get; set; }

        [JsonProperty("template_url")]
        public string TemplateURL { get; set; }

        [JsonProperty("template_url_spec")]
        public AdCreativeTemplateURLSpec TemplateURLSpec { get; set; }

        [JsonProperty("thumbnail_id")]
        public long ThumbnailId { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailURL { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url_tags")]
        public string URLTags { get; set; }

        [JsonProperty("use_page_actor_override")]
        public bool UsePageActorOverride { get; set; }

        [JsonProperty("video_id")]
        public long VideoId { get; set; }
    }
}
