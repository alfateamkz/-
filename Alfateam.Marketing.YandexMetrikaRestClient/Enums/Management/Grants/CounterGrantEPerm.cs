using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Grants
{
    public enum CounterGrantEPerm
    {
        [Description("public_stat")]
        PublicStat = 1,
        [Description("view")]
        View = 2,
        [Description("edit")]
        Edit = 3,
        [Description("analyst")]
        Analyst = 4,
        [Description("analyst_access_filter")]
        AnalystAccessFilter = 5
    }
}
