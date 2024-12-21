using Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.UserManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingRoles.GetRoles
{
    public class GetRolesResponseRoleCapability
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("access_level")]
        public GetRolesResponseRoleCapabilityAccessLevel AccessLevel { get; set; }
    }
}
