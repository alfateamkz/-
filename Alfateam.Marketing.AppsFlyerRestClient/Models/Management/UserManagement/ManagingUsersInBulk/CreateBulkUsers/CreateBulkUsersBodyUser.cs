using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.CreateBulkUsers
{
    public class CreateBulkUsersBodyUser
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("allow_access_to_all_future_apps")]
        public bool AllowAccessToAllFutureApps { get; set; }

        [JsonProperty("app_ids")]
        public List<string> AppIds { get; set; } = new List<string>();

        [JsonProperty("geos")]
        public List<string> Geos { get; set; } = new List<string>();

        [JsonProperty("media_sources")]
        public List<string> MediaSources { get; set; } = new List<string>();
    }
}
