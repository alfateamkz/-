using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.GetUsers
{
    public class GetUsersResponse
    {
        [JsonProperty("users")]
        public List<GetUsersResponseUser> Users { get; set; } = new List<GetUsersResponseUser>();
    }
}
