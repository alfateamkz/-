using Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.UserManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingRoles.GetRoles
{
    public class GetRolesResponseRole
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public GetRolesResponseRoleType Type { get; set; }

        [JsonProperty("capabilities")]
        public List<GetRolesResponseRoleCapabilitySection> Capabilities { get; set; } = new List<GetRolesResponseRoleCapabilitySection>();
    }
}
