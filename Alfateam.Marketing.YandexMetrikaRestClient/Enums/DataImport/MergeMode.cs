using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum MergeMode
    {
        [Description("SAVE")]
        Save = 1,
        [Description("UPDATE")]
        Update = 2,
        [Description("APPEND")]
        Append = 3
    }
}
