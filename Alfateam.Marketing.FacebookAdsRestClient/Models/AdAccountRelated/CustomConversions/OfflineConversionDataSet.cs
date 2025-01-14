using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.CustomConversions;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdsPixels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.CustomConversions
{
    public class OfflineConversionDataSet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("automatic_matching_fields")]
        public List<OfflineConversionDataSetAutomaticMatchingField> AutomaticMatchingFields { get; set; } = new List<OfflineConversionDataSetAutomaticMatchingField>();

        [JsonProperty("business")]
        public Business Business { get; set; }

        [JsonProperty("can_proxy")]
        public bool CanProxy { get; set; }

        [JsonProperty("config")]
        public string Config { get; set; }

        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("data_use_setting")]
        public OfflineConversionDataSetDataUseSetting DataUseSetting { get; set; }

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
        public OfflineConversionFirstPartyCookieStatus FirstPartyCookieStatus { get; set; }

        [JsonProperty("is_consolidated_container")]
        public bool IsConsolidatedContainer { get; set; }

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

        [JsonProperty("usage")]
        public OfflineConversionDataSetUsage Usage { get; set; }

        [JsonProperty("valid_entries")]
        public int ValidEntries { get; set; }
    }
}
