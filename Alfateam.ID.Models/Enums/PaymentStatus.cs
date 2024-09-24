using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.ID.Models.Enums
{
    public enum PaymentStatus
    {
        NotPaidYet = 1,
        InsufficientFunds = 2,
        CardError = 3,
        Paid = 4,
        Canceled = 5,
    }
}
