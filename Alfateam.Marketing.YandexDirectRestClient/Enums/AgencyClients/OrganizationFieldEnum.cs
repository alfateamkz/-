using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum OrganizationFieldEnum
    {
        [Description("Name")]
        Name = 1,
        [Description("EpayNumber")]
        EpayNumber = 2,
        [Description("RegNumber")]
        RegNumber = 3,
        [Description("OksmNumber")]
        OksmNumber = 4,
        [Description("OkvedCode")]
        OkvedCode = 5,
    }
}
