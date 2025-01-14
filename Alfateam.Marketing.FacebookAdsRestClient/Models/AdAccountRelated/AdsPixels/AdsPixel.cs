using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdsPixels;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdsPixels
{
    public class AdsPixel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("automatic_matching_fields")]
        public AdsPixelAutomaticMatchingField AutomaticMatchingFields { get; set; }

        [JsonProperty("can_proxy")]
        public bool CanProxy { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("config")]
        public string Config { get; set; }

        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("creator")]
        public User Creator { get; set; }

        [JsonProperty("data_use_setting")]
        public AdsPixelDataUseSetting DataUseSetting { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("duplicate_entries")]
        public int DuplicateEntries { get; set; }

        [JsonProperty("enable_auto_assign_to_accounts")]
        public bool EnableAutoAssignToAccounts { get; set; }

        [JsonProperty("enable_automatic_matching")]
        public bool EnableAutomaticMatching { get; set; }

        [JsonProperty("event_stats")]
        public string EventStats { get; set; }

        [JsonProperty("event_time_max")]
        public int EventTimeMax { get; set; }

        [JsonProperty("event_time_min")]
        public int EventTimeMin { get; set; }

        [JsonProperty("first_party_cookie_status")]
        public AdsPixelFirstPartyCookieStatus FirstPartyCookieStatus { get; set; }

        [JsonProperty("has_1p_pixel_event")]
        public bool Has1pPixelEvent { get; set; }

        [JsonProperty("is_consolidated_container")]
        public bool IsCnsolidatedContainer { get; set; }

        [JsonProperty("is_created_by_business")]
        public bool IsCreatedByBusiness { get; set; }

        [JsonProperty("is_crm")]
        public bool IsCRM { get; set; }

        [JsonProperty("is_mta_use")]
        public bool IsMTAUse { get; set; }

        [JsonProperty("is_restricted_use")]
        public bool IsRestrictedUse { get; set; }

        [JsonProperty("is_unavailable")]
        public bool IsUnavailable { get; set; }

        [JsonProperty("last_fired_time")]
        public DateTime LastFiredTime { get; set; }

        [JsonProperty("last_upload_app")]
        public string LastUploadApp { get; set; }

        [JsonProperty("last_upload_app_changed_time")]
        public int LastUploadAppChangedTime { get; set; }

        [JsonProperty("match_rate_approx")]
        public int MatchRateApprox { get; set; }

        [JsonProperty("matched_entries")]
        public int MatchedEntries { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_ad_account")]
        public AdAccount OwnerAdAccount { get; set; }

        [JsonProperty("owner_business")]
        public Business OwnerBusiness { get; set; }

        [JsonProperty("usage")]
        public OfflineConversionDataSetUsage Usage { get; set; }

        [JsonProperty("valid_entries")]
        public int ValidEntries { get; set; }
    }
}
