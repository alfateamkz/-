using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingRoles.GetRoles
{
    public class GetRolesResponse
    {
        [JsonProperty("roles")]
        public List<GetRolesResponseRole> Roles { get; set; } = new List<GetRolesResponseRole>();

        [JsonProperty("users")]
        public List<GetRolesResponseUser> Users { get; set; } = new List<GetRolesResponseUser>();
    }
}
