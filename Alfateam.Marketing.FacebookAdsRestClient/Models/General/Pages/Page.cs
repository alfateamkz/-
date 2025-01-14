using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users;
using Alfateam.Marketing.FacebookAdsRestClient.Models.General.Videos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages
{
    public class Page
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("ad_campaign")]
        public AdSet AdCampaign { get; set; }

        [JsonProperty("affiliation")]
        public string Affiliation { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("artists_we_like")]
        public string ArtistsWeLike { get; set; }

        [JsonProperty("attire")]
        public string Attire { get; set; }

        [JsonProperty("available_promo_offer_ids")]
        public Dictionary<string, Dictionary<string, string>> AvailablePromoOfferIds { get; set; } = new Dictionary<string, Dictionary<string, string>>();

        [JsonProperty("awards")]
        public string Awards { get; set; }

        [JsonProperty("band_interests")]
        public string BandInterests { get; set; }

        [JsonProperty("band_members")]
        public string BandNembers { get; set; }

        [JsonProperty("best_page")]
        public Page BestPage { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("booking_agent")]
        public string BookingAgent { get; set; }

        [JsonProperty("built")]
        public string Built { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }

        [JsonProperty("can_checkin")]
        public bool CanCheckin { get; set; }

        [JsonProperty("can_post")]
        public bool CanPost { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("category_list")]
        public List<PageCategory> CategoryList { get; set; } = new List<PageCategory>();

        [JsonProperty("checkins")]
        public uint Checkins { get; set; }

        [JsonProperty("company_overview")]
        public string CompanyOverview { get; set; }

        [JsonProperty("connected_instagram_account")]
        public IGUser ConnectedInstagramAccount { get; set; }

        [JsonProperty("connected_page_backed_instagram_account")]
        public IGUser ConnectedPageBackedInstagramAccount { get; set; }

        [JsonProperty("contact_address")]
        public MailingAddress ContactAddress { get; set; }

        [JsonProperty("copyright_attribution_insights")]
        public CopyrightAttributionInsights CopyrightAttributionInsights { get; set; }

        [JsonProperty("copyright_whitelisted_ig_partners")]
        public List<string> CopyrightWhitelistedIGPartners { get; set; } = new List<string>();

        [JsonProperty("country_page_likes")]
        public uint CountryPageLikes { get; set; }

        [JsonProperty("cover")]
        public CoverPhoto Cover { get; set; }

        [JsonProperty("culinary_team")]
        public string CulinaryTeam { get; set; }

        [JsonProperty("current_location")]
        public string CurrentLocation { get; set; }

        [JsonProperty("delivery_and_pickup_option_info")]
        public List<string> DeliveryAndPickupOptionInfo { get; set; } = new List<string>();

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_html")]
        public string DescriptionHTML { get; set; }

        [JsonProperty("differently_open_offerings")]
        public Dictionary<DifferentlyOpenOfferingsEnum, bool> DifferentlyOpenOfferings { get; set; } = new Dictionary<DifferentlyOpenOfferingsEnum, bool>();

        [JsonProperty("directed_by")]
        public string DirectedBy { get; set; }

        [JsonProperty("display_subtext")]
        public string DisplaySubtext { get; set; }

        [JsonProperty("displayed_message_response_time")]
        public string DisplayedMessageResponseTime { get; set; }

        [JsonProperty("does_viewer_have_page_permission_link_ig")]
        public bool DoesViewerHavePagePermissionLinkIG { get; set; }

        [JsonProperty("emails")]
        public List<string> Emails { get; set; } = new List<string>();

        [JsonProperty("engagement")]
        public Engagement Engagement { get; set; }

        [JsonProperty("fan_count")]
        public uint FanCount { get; set; }

        [JsonProperty("featured_video")]
        public Video FeaturedVideo { get; set; }

        [JsonProperty("features")]
        public string Features { get; set; }

        [JsonProperty("followers_count")]
        public uint FollowersCount { get; set; }

        [JsonProperty("food_styles")]
        public List<string> FoodStyles { get; set; } = new List<string>();

        [JsonProperty("founded")]
        public string Founded { get; set; }

        [JsonProperty("general_info")]
        public string GeneralInfo { get; set; }

        [JsonProperty("general_manager")]
        public string GeneralManager { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("global_brand_page_name")]
        public string GlobalBrandPageName { get; set; }

        [JsonProperty("global_brand_root_id")]
        public long GlobalBrandRootId { get; set; }

        [JsonProperty("has_added_app")]
        public bool HasAddedApp { get; set; }

        [JsonProperty("has_lead_access")]
        public HasLeadAccess HasLeadAccess { get; set; }

        [JsonProperty("has_transitioned_to_new_page_experience")]
        public bool HasTransitionedToNewPageExperience { get; set; }

        [JsonProperty("has_whatsapp_business_number")]
        public bool HasWhatsappBusinessNumber { get; set; }

        [JsonProperty("has_whatsapp_number")]
        public bool HasWhatsappNumber { get; set; }

        [JsonProperty("hometown")]
        public string Hometown { get; set; }

        [JsonProperty("hours")]
        public Dictionary<string, string> Hours { get; set; } = new Dictionary<string, string>();

        [JsonProperty("impressum")]
        public string Impressum { get; set; }

        [JsonProperty("influences")]
        public string Influences { get; set; }

        [JsonProperty("instagram_business_account")]
        public IGUser InstagramBusinessAccount { get; set; }

        [JsonProperty("is_always_open")]
        public bool IsAlwaysOpen { get; set; }

        [JsonProperty("is_calling_eligible")]
        public bool IsCallingEligible { get; set; }

        [JsonProperty("is_chain")]
        public bool IsChain { get; set; }

        [JsonProperty("is_community_page")]
        public bool IsCommunityPage { get; set; }

        [JsonProperty("is_eligible_for_branded_content")]
        public bool IsEligibleForBrandedContent { get; set; }

        [JsonProperty("is_eligible_for_disable_connect_ig_btn_for_non_page_admin_am_web")]
        public bool IsEligibleForDisableConnectIGBtnForNonPageAdminAMWeb { get; set; }

        [JsonProperty("is_messenger_bot_get_started_enabled")]
        public bool IsMessengerBotGetStartedEnabled { get; set; }

        [JsonProperty("is_messenger_platform_bot")]
        public bool IsMessengerPlatformBot { get; set; }

        [JsonProperty("is_owned")]
        public bool IsOwned { get; set; }

        [JsonProperty("is_permanently_closed")]
        public bool IsPermanentlyClosed { get; set; }

        [JsonProperty("is_published")]
        public bool IsPublished { get; set; }

        [JsonProperty("is_unclaimed")]
        public bool IsUnclaimed { get; set; }

        [JsonProperty("is_webhooks_subscribed")]
        public bool IsWebhooksSubscribed { get; set; }

        [JsonProperty("leadgen_tos_acceptance_time")]
        public DateTime LeadgenTOSAcceptanceTime { get; set; }

        [JsonProperty("leadgen_tos_accepted")]
        public bool LeadgenTOSAccepted { get; set; }

        [JsonProperty("leadgen_tos_accepting_user")]
        public User LeadgenTOSAcceptingUser { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("members")]
        public string Members { get; set; }

        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("merchant_review_status")]
        public MerchantReviewStatus MerchantReviewStatus { get; set; }

        [JsonProperty("messaging_feature_status")]
        public MessagingFeatureStatus MessagingFeatureStatus { get; set; }

        [JsonProperty("messenger_ads_default_icebreakers")]
        public List<string> MessengerAdsDefaultIcebreakers { get; set; } = new List<string>();

        [JsonProperty("messenger_ads_default_quick_replies")]
        public List<string> MessengerAdsDefaultQuickReplies { get; set; } = new List<string>();

        [JsonProperty("messenger_ads_quick_replies_type")]
        public MessengerAdsQuickRepliesType MessengerAdsQuickRepliesType { get; set; }

        [JsonProperty("mission")]
        public string Mission { get; set; }

        [JsonProperty("mpg")]
        public string MPG { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_with_location_descriptor")]
        public string NameWithLocationDescriptor { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("new_like_count")]
        public uint NewLikeCount { get; set; }

        [JsonProperty("offer_eligible")]
        public bool OfferEligible { get; set; }

        [JsonProperty("overall_star_rating")]
        public float OverallStarRating { get; set; }

        [JsonProperty("page_token")]
        public string PageToken { get; set; }

        [JsonProperty("parent_page")]
        public Page ParentPage { get; set; }

        [JsonProperty("parking")]
        public PageParking Parking { get; set; }

        [JsonProperty("payment_options")]
        public PagePaymentOptions PaymentOptions { get; set; }

        [JsonProperty("personal_info")]
        public string PersonalInfo { get; set; }

        [JsonProperty("personal_interests")]
        public string PersonalInterests { get; set; }

        [JsonProperty("pharma_safety_info")]
        public string PharmaSafetyInfo { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("pickup_options")]
        public List<PagePickupOptionEnum> PickupOptions { get; set; } = new List<PagePickupOptionEnum>();

        [JsonProperty("place_type")]
        public PagePlaceType PlaceType { get; set; }

        [JsonProperty("plot_outline")]
        public string PlotOutline { get; set; }

        [JsonProperty("preferred_audience")]
        public Targeting PreferredAudience { get; set; }

        [JsonProperty("press_contact")]
        public string PressContact { get; set; }

        [JsonProperty("price_range")]
        public string PriceRange { get; set; }

        [JsonProperty("privacy_info_url")]
        public string PrivacyInfoURL { get; set; }

        [JsonProperty("produced_by")]
        public string ProducedBy { get; set; }

        [JsonProperty("products")]
        public string Products { get; set; }

        [JsonProperty("promotion_eligible")]
        public bool PromotionEligible { get; set; }

        [JsonProperty("promotion_ineligible_reason")]
        public string PromotionIneligibleReason { get; set; }

        [JsonProperty("public_transit")]
        public string PublicTransit { get; set; }

        [JsonProperty("rating_count")]
        public uint RatingCount { get; set; }

        [JsonProperty("recipient")]
        public double Recipient { get; set; }

        [JsonProperty("record_label")]
        public string RecordLabel { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("restaurant_services")]
        public PageRestaurantServices PageRestaurantServices { get; set; }

        [JsonProperty("restaurant_specialties")]
        public PageRestaurantSpecialties PageRestaurantSpecialties { get; set; }

        [JsonProperty("schedule")]
        public string Schedule { get; set; }

        [JsonProperty("screenplay_by")]
        public string ScreenplayBy { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("single_line_address")]
        public string SingleLineAddress { get; set; }

        [JsonProperty("starring")]
        public string Starring { get; set; }

        [JsonProperty("start_info")]
        public PageStartInfo StartInfo { get; set; }

        [JsonProperty("store_code")]
        public string StoreCode { get; set; }

        [JsonProperty("store_location_descriptor")]
        public string StoreLocationDescriptor { get; set; }

        [JsonProperty("store_number")]
        public uint StoreNumber { get; set; }

        [JsonProperty("studio")]
        public string Studio { get; set; }

        [JsonProperty("supports_donate_button_in_live_video")]
        public bool SupportsDonateButtonInLiveVideo { get; set; }

        [JsonProperty("talking_about_count")]
        public uint TalkingAboutCount { get; set; }

        [JsonProperty("temporary_status")]
        public PageTemporaryStatus TemporaryStatus { get; set; }

        [JsonProperty("unread_message_count")]
        public uint UnreadMessageCount { get; set; }

        [JsonProperty("unread_notif_count")]
        public uint UnreadNotifCount { get; set; }

        [JsonProperty("unseen_message_count")]
        public uint UnseenMessageCount { get; set; }

        [JsonProperty("user_access_expire_time")]
        public DateTime UserAccessExpireTime { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("verification_status")]
        public PageVerificationStatus VerificationStatus { get; set; }

        [JsonProperty("voip_info")]
        public VoipInfo VoipInfo { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("were_here_count")]
        public uint WereHereCount { get; set; }

        [JsonProperty("whatsapp_number")]
        public string WhatsappNumber { get; set; }

        [JsonProperty("written_by")]
        public string WrittenBy { get; set; }
    }
}
