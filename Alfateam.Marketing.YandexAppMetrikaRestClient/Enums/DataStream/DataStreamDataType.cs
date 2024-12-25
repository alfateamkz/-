using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.DataStream
{
    public enum DataStreamDataType
    {
        [Description("event")]
        Event = 1,
        [Description("installation")]
        Installation = 2,
        [Description("session_start")]
        SessionStart = 3,
        [Description("session_end")]
        SessionEnd = 4,
        [Description("push_token")]
        PushToken = 5,
        [Description("crash")]
        Crash = 6,
        [Description("error")]
        Error = 7,
        [Description("click")]
        Click = 8,
        [Description("revenue")]
        Revenue = 9,
        [Description("ecommerce")]
        ECommerce = 10,
        [Description("ecommerce")]
        AdRevenue = 11
    }
}
