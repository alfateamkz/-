using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.Applications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Applications
{
    public class Application
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("aam_rules")]
        public string AAMRules { get; set; }

        [JsonProperty("an_ad_space_limit")]
        public int ANAdSpaceLimit { get; set; }

        [JsonProperty("an_platforms")]
        public List<ApplicationANPlatform> ANPlatforms { get; set; } = new List<ApplicationANPlatform>();

        [JsonProperty("app_domains")]
        public List<string> AppDomains { get; set; } = new List<string>();

        [JsonProperty("app_events_config")]
        public ApplicationAppEventsConfig AppEventsConfig { get; set; }

        [JsonProperty("app_install_tracked")]
        public bool AppInstallTracked { get; set; }

        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("app_signals_binding_ios")]
        public List<Binding> AppSignalsBindingiOS { get; set; } = new List<Binding>();

        [JsonProperty("app_type")]
        public uint AppType { get; set; }

        [JsonProperty("auth_dialog_data_help_url")]
        public string AuthDialogDataHelpURL { get; set; }

        [JsonProperty("auth_dialog_headline")]
        public string AuthDialogHeadline { get; set; }

        [JsonProperty("auth_dialog_perms_explanation")]
        public string AuthDialogPermsExplanation { get; set; }

        [JsonProperty("auth_referral_default_activity_privacy")]
        public string AuthReferralDefaultActivityPrivacy { get; set; }

        [JsonProperty("auth_referral_enabled")]
        public uint AuthReferralEnabled { get; set; }

        [JsonProperty("auth_referral_extended_perms")]
        public List<string> AuthReferralExtendedPerms { get; set; } = new List<string>();

        [JsonProperty("auth_referral_friend_perms")]
        public List<string> AuthReferralFriendPerms { get; set; } = new List<string>();

        [JsonProperty("auth_referral_response_type")]
        public string AuthReferralResponseType { get; set; }

        [JsonProperty("auth_referral_user_perms")]
        public List<string> AuthReferralUserPerms { get; set; } = new List<string>();

        [JsonProperty("canvas_fluid_height")]
        public bool CanvasFluidHeight { get; set; }

        [JsonProperty("canvas_fluid_width")]
        public uint Canvas_FluidWidth { get; set; }

        [JsonProperty("canvas_url")]
        public string CanvasURL { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("client_config")]
        public string ClientConfig { get; set; } //TODO: find structure

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("configured_ios_sso")]
        public bool ConfigurediOSSSO { get; set; }

        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("creator_uid")]
        public long CreatorUID { get; set; }

        [JsonProperty("daily_active_users")]
        public long DailyActiveUsers { get; set; }

        [JsonProperty("daily_active_users_rank")]
        public int DailyActiveUsersRank { get; set; }

        [JsonProperty("deauth_callback_url")]
        public string DeauthCallbackURL { get; set; }

        [JsonProperty("default_share_mode")]
        public string DefaultShareMode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("financial_id")]
        public string FinancialId { get; set; }

        [JsonProperty("hosting_url")]
        public string HostingURL { get; set; }

        [JsonProperty("icon_url")]
        public string IconURL { get; set; }

        [JsonProperty("ios_bundle_id")]
        public List<string> iOSBundleId { get; set; } = new List<string>();

        [JsonProperty("ios_supports_native_proxy_auth_flow")]
        public bool iOSSupportsNativeProxyAuthFlow { get; set; }

        [JsonProperty("ios_supports_system_auth")]
        public bool iOSSupportsSystemAuth { get; set; }

        [JsonProperty("ipad_app_store_id")]
        public string iPadAppStoreId { get; set; }

        [JsonProperty("iphone_app_store_id")]
        public string iPhoneAppStoreId { get; set; }

        [JsonProperty("latest_sdk_version")]
        public ApplicationSDKInfo LatestSDKVersion { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("logging_token")]
        public string LoggingToken { get; set; }

        [JsonProperty("logo_url")]
        public string LogoURL { get; set; }

        [JsonProperty("migrations")]
        public Dictionary<string, bool> Migrations { get; set; } = new Dictionary<string, bool>();

        [JsonProperty("mobile_profile_section_url")]
        public string MobileProfileSectionURL { get; set; }

        [JsonProperty("mobile_web_url")]
        public string MobileWebURL { get; set; }

        [JsonProperty("monthly_active_users")]
        public long MonthlyActiveUsers { get; set; }

        [JsonProperty("monthly_active_users_rank")]
        public uint MonthlyActiveUsersRank { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("object_store_urls")]
        public ApplicationObjectStoreURLs ObjectStoreURLs { get; set; }

        [JsonProperty("page_tab_default_name")]
        public string PageTabDefaultName { get; set; }

        [JsonProperty("page_tab_url")]
        public string PageTabURL { get; set; }

        [JsonProperty("photo_url")]
        public string PhotoURL { get; set; }

        [JsonProperty("privacy_policy_url")]
        public string PrivacyPolicyURL { get; set; }

        [JsonProperty("profile_section_url")]
        public string ProfileSectionURL { get; set; }

        [JsonProperty("property_id")]
        public string PropertyId { get; set; }

        [JsonProperty("protected_mode_rules")]
        public ApplicationProtectedModeRules ProtectedModeRules { get; set; }

        [JsonProperty("real_time_mode_devices")]
        public List<string> RealTimeModeDevices { get; set; } = new List<string>();

        [JsonProperty("restrictions")]
        public ApplicationRestrictionInfo Restrictions { get; set; }

        [JsonProperty("restrictive_data_filter_params")]
        public string RestrictiveDataFilterParams { get; set; }

        [JsonProperty("secure_canvas_url")]
        public string SecureCanvasURL { get; set; }

        [JsonProperty("secure_page_tab_url")]
        public string SecurePageTabURL { get; set; }

        [JsonProperty("server_ip_whitelist")]
        public string ServerIPWhitelist { get; set; }

        [JsonProperty("social_discovery")]
        public uint SocialDiscovery { get; set; }

        [JsonProperty("subcategory")]
        public string SubCategory { get; set; }

        [JsonProperty("suggested_events_setting")]
        public string SuggestedEventsSetting { get; set; }

        [JsonProperty("supported_platforms")]
        public List<ApplicationSupportedPlatform> SupportedPlatforms { get; set; } = new List<ApplicationSupportedPlatform>();

        [JsonProperty("terms_of_service_url")]
        public string TermsOfServiceURL { get; set; }

        [JsonProperty("url_scheme_suffix")]
        public string URLSchemeSuffix { get; set; }

        [JsonProperty("user_support_email")]
        public string UserSupportEmail { get; set; }

        [JsonProperty("user_support_url")]
        public string UserSupportURL { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteURL { get; set; }

        [JsonProperty("weekly_active_users")]
        public long WeeklyActiveUsers { get; set; }
    }
}
