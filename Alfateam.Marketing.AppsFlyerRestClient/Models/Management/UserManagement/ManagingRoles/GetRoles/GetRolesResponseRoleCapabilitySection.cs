using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingRoles.GetRoles
{
    public class GetRolesResponseRoleCapabilitySection
    {
        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("capabilities")]
        public List<GetRolesResponseRoleCapability> Capabilities { get; set; } = new List<GetRolesResponseRoleCapability>();
    }
}
