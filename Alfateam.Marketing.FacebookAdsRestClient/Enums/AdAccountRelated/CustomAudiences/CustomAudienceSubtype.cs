using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.CustomAudiences
{
    public enum CustomAudienceSubtype
    {
        [Description("ANYTHING")]
        Anything = 1,
        [Description("NOTHING")]
        Nothing = 2,
        [Description("HASHES")]
        Hashes = 3,
        [Description("USER_IDS")]
        UserIds = 4,
        [Description("HASHES_OR_USER_IDS")]
        HashesOrUserIds = 5,
        [Description("MOBILE_ADVERTISER_IDS")]
        MobileAdvertiserIds = 6,
        [Description("EXTERNAL_IDS")]
        ExternalIds = 7,
        [Description("MULTI_HASHES")]
        MultiHashes = 8,
        [Description("TOKENS")]
        Tokens = 9,
        [Description("EXTERNAL_IDS_MIX")]
        ExternalIdsMix = 10,
        [Description("HOUSEHOLD_EXPANSION")]
        HouseholdExpansion = 11,
        [Description("SUBSCRIBER_LIST")]
        SubscriberList = 12,
        [Description("WEB_PIXEL_HITS")]
        WebPixelHits = 13,
        [Description("MOBILE_APP_EVENTS")]
        MobileAppEvents = 14,
        [Description("MOBILE_APP_COMBINATION_EVENTS")]
        MobileAppCombinationEvents = 15,
        [Description("VIDEO_EVENTS")]
        VideoEvents = 16,
        [Description("WEB_PIXEL_COMBINATION_EVENTS")]
        WebPixelCombinationEvents = 17,
        [Description("PLATFORM")]
        Platform = 18,
        [Description("MULTI_DATA_EVENTS")]
        MultiDataEvents = 19,
        [Description("IG_BUSINESS_EVENTS")]
        IGBusinessEvents = 20,
        [Description("STORE_VISIT_EVENTS")]
        StoreVisitEvents = 21,
        [Description("INSTANT_ARTICLE_EVENTS")]
        InstantArticleEvents = 22,
        [Description("FB_EVENT_SIGNALS")]
        FBEventSignals = 23,
        [Description("FACEBOOK_WIFI_EVENTS")]
        FacebookWiFiEvents = 24,
        [Description("AR_EXPERIENCE_EVENTS")]
        ARExperienceEvents = 25,
        [Description("AR_EFFECTS_EVENTS")]
        AREffectsEvents = 26,
        [Description("MESSENGER_ONSITE_SUBSCRIPTION")]
        MessengerOnsiteSubscription = 27,
        [Description("WHATSAPP_SUBSCRIBER_POOL")]
        WhatsAppSubscriberPool = 28,
        [Description("MARKETPLACE_LISTINGS")]
        MarketplaceListings = 29,
        [Description("AD_CAMPAIGN")]
        AdCampaign = 30,
        [Description("GROUP_EVENTS")]
        GroupEvents = 31,
        [Description("ENGAGEMENT_EVENT_USERS")]
        EngagementEventUsers = 32,
        [Description("CUSTOM_AUDIENCE_USERS")]
        CustomAudienceUsers = 33,
        [Description("PAGE_FANS")]
        PageFans = 34,
        [Description("CONVERSION_PIXEL_HITS")]
        ConversionPixelHits = 35,
        [Description("APP_USERS")]
        AppUsers = 36,
        [Description("S_EXPR")]
        SExpr = 37,
        [Description("DYNAMIC_RULE")]
        DynamicRule = 38,
        [Description("CAMPAIGN_CONVERSIONS")]
        CampaignConversions = 39,
        [Description("WEB_PIXEL_HITS_CUSTOM_AUDIENCE_USERS")]
        WebPixelHitsCustomAudienceUsers = 40,
        [Description("MOBILE_APP_CUSTOM_AUDIENCE_USERS")]
        MobileAppCustomAudienceUsers = 41,
        [Description("COMBINATION_CUSTOM_AUDIENCE_USERS")]
        CombinationCustomAudienceUsers = 42,
        [Description("VIDEO_EVENT_USERS")]
        VideoEventUsers = 43,
        [Description("FB_PIXEL_HITS")]
        FBPixelHits = 44,
        [Description("IG_PROMOTED_POST")]
        IGPromotedPost = 45,
        [Description("PLACE_VISITS")]
        PlaceVisits = 46,
        [Description("OFFLINE_EVENT_USERS")]
        OfflineEventUsers = 47,
        [Description("EXPANDED_AUDIENCE")]
        ExpandedAudience = 48,
        [Description("SEED_LIST")]
        SeedList = 49,
        [Description("PARTNER_CATEGORY_USERS")]
        PartnerCategoryUsers = 50,
        [Description("PAGE_SMART_AUDIENCE")]
        PageSmartAudience = 51,
        [Description("MULTICOUNTRY_COMBINATION")]
        MulticountryCombination = 52,
        [Description("PLATFORM_USERS")]
        PlatformUsers = 53,
        [Description("MULTI_EVENT_SOURCE")]
        MultiEventSource = 54,
        [Description("SMART_AUDIENCE")]
        SmartAudience = 55,
        [Description("LOOKALIKE_PLATFORM")]
        LookalikePlatform = 56,
        [Description("SIGNAL_SOURCE")]
        SignalSource = 57,
        [Description("MAIL_CHIMP_EMAIL_HASHES")]
        MailChimpEmailHashes = 58,
        [Description("CONSTANT_CONTACTS_EMAIL_HASHES")]
        ConstantContactsEmailHashes = 59,
        [Description("COPY_PASTE_EMAIL_HASHES")]
        CopyPasteEmailHashes = 60,
        [Description("CUSTOM_DATA_TARGETING")]
        CustomDataTargeting = 61,
        [Description("CONTACT_IMPORTER")]
        ContactImporter = 62,
        [Description("DATA_FILE")]
        DataFile = 62,
    }
}
