using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum RepresentativeRoleEnum
    {
        [Description("CHIEF")]
        Chief = 1,
        [Description("DELEGATE")]
        Delegate = 2,
        [Description("READONLY")]
        Readonly = 3,
        [Description("UNKNOWN")]
        Unknown = 4,
    }
}
