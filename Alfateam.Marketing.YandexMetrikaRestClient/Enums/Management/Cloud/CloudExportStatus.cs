using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Cloud
{
    public enum CloudExportStatus
    {
        [Description("ACTIVE")]
        Active = 1,
        [Description("DELETED")]
        Deleted = 2
    }
}
