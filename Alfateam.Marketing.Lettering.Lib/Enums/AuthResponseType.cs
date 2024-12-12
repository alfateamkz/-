using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Lettering.Lib.Enums
{
    public enum AuthResponseType
    {
        Success = 1,
        TwoFARequired = 2,
        AccountBanned = 3,
        ChallengeRequired = 4,
        InvalidCredentials = 5,
        Invalid2FACode = 6
    }
}
