using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users;
using Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class Business
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("block_offline_analytics")]
        public bool BlockOfflineAnalytics { get; set; }

        [JsonProperty("collaborative_ads_managed_partner_business_info")]
        public ManagedPartnerBusiness CollaborativeAdsManagedPartnerBusinessInfo { get; set; }

        [JsonProperty("collaborative_ads_managed_partner_eligibility")]
        public BusinessManagedPartnerEligibility CollaborativeAdsManagedPartnerEligibility { get; set; }

        [JsonProperty("created_by")]
        public AbsUser CreatedBy { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("extended_updated_time")]
        public DateTime ExtendedUpdatedTime { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("payment_account_id")]
        public long PaymentAccountId { get; set; }

        [JsonProperty("primary_page")]
        public Page PrimaryPage { get; set; }

        [JsonProperty("profile_picture_uri")]
        public string ProfilePictureURI { get; set; }

        [JsonProperty("timezone_id")]
        public long TimezoneId { get; set; }

        [JsonProperty("two_factor_type")]
        public BusinessTwoFactorType TwoFactorType { get; set; }

        [JsonProperty("updated_by")]
        public User UpdatedBy { get; set; } //TODO: BusinessUser|SystemUser

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("verification_status")]
        public BusinessVerificationStatus VerificationStatus { get; set; }

        [JsonProperty("vertical")]
        public string Vertical { get; set; }

        [JsonProperty("vertical_id")]
        public long VerticalId { get; set; }
    }
}
