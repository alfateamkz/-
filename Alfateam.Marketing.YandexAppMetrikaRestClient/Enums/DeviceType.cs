using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums
{
    public enum DeviceType
    {
        [Description("phone")]
        Phone = 1,
        [Description("tablet")]
        Tablet = 2,
        [Description("tablet")]
        Unknown = 3
    }
}
