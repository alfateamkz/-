using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum ContractActionTypeEnum
    {
        [Description("COMMERCIAL")]
        Commercial = 1,
        [Description("DISTRIBUTION")]
        Distribution = 2,
        [Description("CONCLUDE")]
        Conclude = 3,
        [Description("OTHER")]
        Other = 4,
    }
}
