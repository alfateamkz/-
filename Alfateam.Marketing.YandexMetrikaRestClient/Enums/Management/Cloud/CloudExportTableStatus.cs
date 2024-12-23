using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Cloud
{
    public enum CloudExportTableStatus
    {
        [Description("NEW")]
        New = 1,
        [Description("ACTIVATING")]
        Activating = 2,
        [Description("ACTIVE")]
        Active = 3,
        [Description("DELETING")]
        Deleting = 4,
        [Description("DELETED")]
        Deleted = 5
    }
}
