using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users
{
    public class BusinessUser : AbsUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("finance_permission")]
        public string FinancePermission { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("ip_permission")]
        public string IPPermission { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pending_email")]
        public string PendingEmail { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("two_fac_status")]
        public string TwoFacStatus { get; set; }
    }
}
