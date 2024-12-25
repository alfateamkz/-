using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Management
{
    public enum PartnerOwnership
    {
        [Description("common")]
        Common = 1,
        [Description("own")]
        Own = 2,
        [Description("guest")]
        Guest = 3
    }
}
