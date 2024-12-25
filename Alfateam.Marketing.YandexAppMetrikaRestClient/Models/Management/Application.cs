using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management
{
    public class Application
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("time_zone_name")]
        public string TimeZoneName { get; set; }

        [JsonProperty("label_id")]
        public int LabelId { get; set; }

        [JsonProperty("hide_address")]
        public bool HideAddress { get; set; }

        [JsonProperty("gdpr_agreement_accepted")]
        public bool GDPRAgreementAccepted { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("bundle_id")]
        public string BundleId { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("use_universal_links")]
        public bool UseUniversalLinks { get; set; }

        [JsonProperty("universal_link")]
        public string UniversalLink { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("uid")]
        public int UID { get; set; }

        [JsonProperty("owner_login")]
        public string OwnerLogin { get; set; }

        [JsonProperty("api_key128")]
        public string APIKey128 { get; set; }

        [JsonProperty("import_token")]
        public string ImportToken { get; set; }

        [JsonProperty("permission")]
        public ManagementPermission Permission { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("time_zone_offset")]
        public int TimeZoneOffset { get; set; }

        [JsonProperty("permission_date")]
        public DateTime PermissionDate { get; set; }

        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }
    }
}
