using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Enums
{
    public enum LetteringStatus 
    {
        NotActive = 1,
        Active = 2,
        Paused = 3,

        InvalidCredentials = 4,
        SMS_InsufficientFunds = 5,
        AccountBanned = 6,
        ChallengeRequired = 7,
        TwoFARequired = 8,
        Invalid2FACode = 9,


        Stopped = 998,
        Finished = 999
    }
}
