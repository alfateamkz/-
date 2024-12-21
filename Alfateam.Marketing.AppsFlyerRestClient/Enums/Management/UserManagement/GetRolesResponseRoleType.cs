using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.UserManagement
{
    public enum GetRolesResponseRoleType
    {
        [Description("predefined")]
        Predefined = 1,
        [Description("custom")]
        Custom = 2,
    }
}
