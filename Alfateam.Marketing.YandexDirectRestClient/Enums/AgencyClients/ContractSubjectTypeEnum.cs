using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum ContractSubjectTypeEnum
    {
        [Description("REPRESENTATION")]
        Representation = 1,
        [Description("MEDIATION")]
        Mediation = 2,
        [Description("DISTRIBUTION")]
        Distribution = 3,
        [Description("ORG_DISTRIBUTION")]
        OrgDistribution = 4,
        [Description("OTHER")]
        Other = 5,
    }
}
