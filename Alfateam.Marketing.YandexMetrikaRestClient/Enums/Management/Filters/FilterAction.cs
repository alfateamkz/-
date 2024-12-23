using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Filters
{
    public enum FilterAction
    {
        [Description("exclude")]
        Exclude = 1,
        [Description("include")]
        Include = 2
    }
}
