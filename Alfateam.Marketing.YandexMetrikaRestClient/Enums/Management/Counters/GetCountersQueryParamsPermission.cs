using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters
{
    public enum GetCountersQueryParamsPermission
    {
        [Description("own")]
        Own = 1,
        [Description("view")]
        View = 2,
        [Description("edit")]
        Edit = 3,
    }
}
