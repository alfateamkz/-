using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Diagnostics
{
    public enum SiteProblemState
    {
        [Description("PRESENT")]
        Present = 1,
        [Description("ABSENT")]
        Absent = 2,
        [Description("UNDEFINED")]
        Undefined = 3,
    }
}
