using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Filters
{
    public enum FilterStatus
    {
        [Description("active")]
        Active = 1,
        [Description("disabled")]
        Disabled = 2
    }
}
