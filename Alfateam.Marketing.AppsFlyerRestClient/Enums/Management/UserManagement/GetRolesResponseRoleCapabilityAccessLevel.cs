using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.UserManagement
{
    public enum GetRolesResponseRoleCapabilityAccessLevel
    {
        [Description("blocked")]
        Blocked = 1,
        [Description("read")]
        Read = 2,
        [Description("all")]
        All = 3
    }
}
