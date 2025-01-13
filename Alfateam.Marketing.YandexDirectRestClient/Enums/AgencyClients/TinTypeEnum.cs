using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum TinTypeEnum
    {
        [Description("PHYSICAL")]
        Physical = 1,
        [Description("FOREIGN_PHYSICAL")]
        ForeignPhysical = 2,
        [Description("LEGAL")]
        Legal = 3,
        [Description("FOREIGN_LEGAL")]
        ForeignLegal = 4,
        [Description("INDIVIDUAL")]
        Individual = 5,
    }
}
