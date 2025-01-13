using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class HasLeadAccess
    {
        [JsonProperty("app_has_leads_permission")]
        public bool AppHasLeadsPermission { get; set; }

        [JsonProperty("can_access_lead")]
        public bool CanAccessLead { get; set; }

        [JsonProperty("enabled_lead_access_manager")]
        public bool EnabledLeadAccessManager { get; set; }

        [JsonProperty("failure_reason")]
        public string FailureReason { get; set; }

        [JsonProperty("failure_resolution")]
        public string FailureResolution { get; set; }

        [JsonProperty("is_page_admin")]
        public bool IsPageAdmin { get; set; }

        [JsonProperty("page_id")]
        public long PageId { get; set; }

        [JsonProperty("user_has_leads_permission")]
        public bool UserHasLeadsPermission { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}
