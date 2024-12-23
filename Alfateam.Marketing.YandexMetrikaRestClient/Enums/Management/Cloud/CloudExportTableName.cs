using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Cloud
{
    public enum CloudExportTableName
    {
        [Description("HITS")]
        Hits = 1,
        [Description("HITS_V2")]
        HitsV2 = 2,
        [Description("VISITS")]
        Visits = 3
    }
}
