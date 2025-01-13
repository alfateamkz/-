using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum ContractTypeEnum
    {
        [Description("CONTRACT")]
        Contract = 1,
        [Description("INTERMEDIARY_CONTRACT")]
        IntermediaryContract = 2,
        [Description("ADDITIONAL_AGREEMENT")]
        AdditionalAgreement = 3,
    }
}
