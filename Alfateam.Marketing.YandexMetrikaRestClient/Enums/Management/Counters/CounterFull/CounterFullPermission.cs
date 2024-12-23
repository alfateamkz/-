using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters.CounterFull
{
    public enum CounterFullPermission
    {
        [Description("own")]
        Own = 1,
        [Description("view")]
        View = 2,
        [Description("edit")]
        Edit = 3,
        [Description("analyst")]
        Analyst = 4,
        [Description("view_access_filter")]
        ViewAccessFilter = 5,
        [Description("analyst_access_filter")]
        AnalystAccessFilter = 6,
    }
}
