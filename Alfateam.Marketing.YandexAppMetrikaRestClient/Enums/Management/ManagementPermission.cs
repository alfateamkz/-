using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Management
{
    public enum ManagementPermission
    {
        [Description("view")]
        View = 1,
        [Description("edit")]
        Edit = 2,
        [Description("agency_view")]
        AgencyView = 3,
        [Description("agency_edit")]
        AgencyEdit = 4,
        [Description("own")]
        Own = 5
    }
}
