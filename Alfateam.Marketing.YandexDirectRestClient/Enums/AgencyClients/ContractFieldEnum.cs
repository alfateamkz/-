using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum ContractFieldEnum
    {
        [Description("Number")]
        Number = 1,
        [Description("Date")]
        Date = 2,
        [Description("Price")]
        Price = 3,
        [Description("Type")]
        Type = 4,
        [Description("ActionType")]
        ActionType = 5,
        [Description("SubjectType")]
        SubjectType = 6,
    }
}
