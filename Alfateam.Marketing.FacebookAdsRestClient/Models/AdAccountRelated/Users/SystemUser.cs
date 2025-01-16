using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users
{
    public class SystemUser : AbsUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_by")]
        public User CreatedBy { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("finance_permission")]
        public string FinancePermission { get; set; }

        [JsonProperty("ip_permission")]
        public string IPPermission { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
