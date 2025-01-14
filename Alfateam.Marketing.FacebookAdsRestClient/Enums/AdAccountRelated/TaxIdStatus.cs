using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum TaxIdStatus
    {
        Unknown = 0,
        VATNotRequired = 1,
        VATInformationRequired = 2,
        VATInformationSubmitted = 3,
        OfflineVATValidationFailed = 4,
        AccountIsAPersonalAccount = 5,
    }
}
