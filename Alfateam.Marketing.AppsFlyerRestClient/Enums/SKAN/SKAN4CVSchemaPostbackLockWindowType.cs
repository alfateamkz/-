using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.SKAN
{
    public enum SKAN4CVSchemaPostbackLockWindowType
    {
        [Description("in-app")]
        InApp = 1,
        [Description("time")]
        Time = 2,
        [Description("high-coarse")]
        HighCoarse = 3,
        [Description("other")]
        Other = 4,
    }
}
