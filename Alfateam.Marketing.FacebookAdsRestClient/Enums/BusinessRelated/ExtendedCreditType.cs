using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated
{
    public enum ExtendedCreditType
    {
        [Description("ADS_BUSINESS")]
        AdsBusiness = 1,
        [Description("ADS_SEQUENTIAL")]
        AdsSequential = 2,
        [Description("WHATSAPP_BUSINESS")]
        WhatsAppBusiness = 3,
    }
}
