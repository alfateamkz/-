using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.AppManagementAPIV2
{
    public enum AddAppBodyStatus
    {
        [Description("available")]
        Available = 1,
        [Description("pending")]
        Pending = 2,
        [Description("out_of_store")]
        OutOfStore = 3
    }
}
