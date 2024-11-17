using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.PaymentGateways.Enums
{
    public enum PaymentStatusType
    {
        Paid = 1,
        UnpaidYet = 2,
        Cancelled = 3,
        CardError = 4,
    }
}
