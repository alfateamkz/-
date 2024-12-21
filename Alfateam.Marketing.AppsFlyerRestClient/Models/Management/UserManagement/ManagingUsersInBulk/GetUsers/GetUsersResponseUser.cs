using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.GetUsers
{
    public class GetUsersResponseUser
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("apps")]
        public string Apps { get; set; }

        [JsonProperty("media_sources")]
        public string MediaSources { get; set; }

        [JsonProperty("geos")]
        public string Geos { get; set; }

        [JsonProperty("last_login")]
        public string LastLogin { get; set; }
    }
}
