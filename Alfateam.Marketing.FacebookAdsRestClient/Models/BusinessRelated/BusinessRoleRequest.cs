using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated
{
    public class BusinessRoleRequest
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_by")]
        public AbsUser CreatedBy { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("expiration_time")]
        public DateTime ExpirationTime { get; set; }

        [JsonProperty("finance_role")]
        public string FinanceRole { get; set; }

        [JsonProperty("invited_user_type")]
        public List<string> InvitedUserType { get; set; } = new List<string>();

        [JsonProperty("owner")]
        public Business Owner { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_by")]
        public AbsUser UpdatedBy { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
