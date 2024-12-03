using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Enums
{
    public enum LetteringSentResultType
    {
        Sent = 1,
        ContactDoesNotExist = 2,
        ContactBannedUs = 3,


        InsufficientFunds = 9,
        FailedOther = 999
    }
}
