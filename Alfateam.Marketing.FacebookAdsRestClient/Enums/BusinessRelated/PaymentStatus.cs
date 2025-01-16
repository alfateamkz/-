using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated
{
    public enum PaymentStatus
    {
        [Description("Paid")]
        Paid = 1,
        [Description("Partially Paid")]
        PartiallyPaid = 2,

        //TODO: PaymentStatus fields
    }
}
