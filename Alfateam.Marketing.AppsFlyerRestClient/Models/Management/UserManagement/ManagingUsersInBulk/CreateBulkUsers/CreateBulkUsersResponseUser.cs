using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.CreateBulkUsers
{
    public class CreateBulkUsersResponseUser
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
