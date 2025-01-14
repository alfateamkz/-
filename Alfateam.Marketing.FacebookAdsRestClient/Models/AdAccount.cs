using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models
{
    public class AdAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_status")]
        public AdAccountStatus AccountStatus { get; set; }

        [JsonProperty("ad_account_promotable_objects")]
        public AdAccountPromotableObjects AdAccountPromotableObjects { get; set; }

        [JsonProperty("age")]
        public float Age { get; set; }

        [JsonProperty("agency_client_declaration")]
        public AgencyClientDeclaration AgencyClientDeclaration { get; set; }

        [JsonProperty("amount_spent")]
        public double AmountSpent { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("brand_safety_content_filter_levels")]
        public List<string> BrandSafetyContentFilterLevels { get; set; } = new List<string>();

        [JsonProperty("business")]
        public Business Business { get; set; }

        [JsonProperty("business_city")]
        public string BusinessCity { get; set; }

        [JsonProperty("business_country_code")]
        public string BusinessCountryCode { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("business_state")]
        public string BusinessState { get; set; }

        [JsonProperty("business_street")]
        public string BusinessStreet { get; set; }

        [JsonProperty("business_street2")]
        public string BusinessStreet2 { get; set; }

        [JsonProperty("business_zip")]
        public string BusinessZip { get; set; }

        [JsonProperty("can_create_brand_lift_study")]
        public bool CanCreateBrandLiftStudy { get; set; }

        [JsonProperty("capabilities")]
        public List<string> Capabilities { get; set; } = new List<string>();

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("custom_audience_info")]
        public CustomAudienceGroup CustomAudienceInfo { get; set; }

        [JsonProperty("default_dsa_beneficiary")]
        public string DefaultDSABeneficiary { get; set; }

        [JsonProperty("default_dsa_payor")]
        public string DefaultDSAPayor { get; set; }

        [JsonProperty("direct_deals_tos_accepted")]
        public bool DirectDealsTOSAccepted { get; set; }

        [JsonProperty("disable_reason")]
        public AdAccountDisableReason DisableReason { get; set; }

        [JsonProperty("end_advertiser")]
        public long EndAdvertiser { get; set; }

        [JsonProperty("end_advertiser_name")]
        public string EndAdvertiserName { get; set; }

        [JsonProperty("existing_customers")]
        public List<string> ExistingCustomers { get; set; } = new List<string>();

        [JsonProperty("expired_funding_source_details")]
        public FundingSourceDetails ExpiredFundingSourceDetails { get; set; }

        [JsonProperty("extended_credit_invoice_group")]
        public ExtendedCreditInvoiceGroup ExtendedCreditInvoiceGroup { get; set; }

        [JsonProperty("failed_delivery_checks")]
        public List<DeliveryCheck> FailedDeliveryChecks { get; set; } = new List<DeliveryCheck>();

        [JsonProperty("fb_entity")]
        public uint FBEntity { get; set; }

        [JsonProperty("funding_source")]
        public long FundingSource { get; set; }

        [JsonProperty("funding_source_details")]
        public FundingSourceDetails FundingSourceDetails { get; set; }

        [JsonProperty("has_migrated_permissions")]
        public bool HasMigratedPermissions { get; set; }

        [JsonProperty("has_page_authorized_adaccount")]
        public bool HasPageAuthorizedAdAccount { get; set; }

        [JsonProperty("io_number")]
        public long IONumber { get; set; }

        [JsonProperty("is_attribution_spec_system_default")]
        public bool IsAttributionSpecSystemDefault { get; set; }

        [JsonProperty("is_direct_deals_enabled")]
        public bool IsDirectDealsEnabled { get; set; }

        [JsonProperty("is_in_3ds_authorization_enabled_market")]
        public bool IsIn3dsAuthorizationEnabledMarket { get; set; }

        [JsonProperty("is_notifications_enabled")]
        public bool IsNotificationsEnabled { get; set; }

        [JsonProperty("is_personal")]
        public bool IsPersonal { get; set; }

        [JsonProperty("is_prepay_account")]
        public bool IsPrepayAccount { get; set; }

        [JsonProperty("is_tax_id_required")]
        public bool IsTaxIdRequired { get; set; }

        [JsonProperty("line_numbers")]
        public List<int> LineNumbers { get; set; } = new List<int>();

        [JsonProperty("media_agency")]
        public string MediaAgency { get; set; }

        [JsonProperty("min_campaign_group_spend_cap")]
        public double MinCampaignGroupSpendCap { get; set; }

        [JsonProperty("min_daily_budget")]
        public uint MinDailyBudget { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("offsite_pixels_tos_accepted")]
        public bool OffsitePixelsTOSAccepted { get; set; }

        [JsonProperty("owner")]
        public long Owner { get; set; }

        [JsonProperty("partner")]
        public string Partner { get; set; }

        [JsonProperty("rf_spec")]
        public ReachFrequencySpec RFSpec { get; set; }

        [JsonProperty("show_checkout_experience")]
        public bool ShowCheckoutExperience { get; set; }

        [JsonProperty("spend_cap")]
        public string SpendCap { get; set; }

        [JsonProperty("tax_id")]
        public string TaxId { get; set; }

        [JsonProperty("tax_id_status")]
        public TaxIdStatus TaxIdStatus { get; set; }

        [JsonProperty("tax_id_type")]
        public string TaxIdType { get; set; }

        [JsonProperty("timezone_id")]
        public uint TimezoneId { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("timezone_offset_hours_utc")]
        public float TimezoneOffsetHoursUTC { get; set; }

        [JsonProperty("tos_accepted")]
        public Dictionary<string, int> TOSAccepted { get; set; } = new Dictionary<string, int>();

        [JsonProperty("user_tasks")]
        public List<string> UserTasks { get; set; } = new List<string>();

        [JsonProperty("user_tos_accepted")]
        public Dictionary<string, int> UserTOSAccepted { get; set; } = new Dictionary<string, int>();
    }
}
