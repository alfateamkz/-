using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums
{
    public enum ConnectionType
    {
        [Description("wifi")]
        WiFi = 1,
        [Description("cell")]
        Cell = 2,
        [Description("unknown")]
        Unknown = 3
    }
}

