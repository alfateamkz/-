using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Enums
{
    public enum AuthResultType
    {
        Success = 1,
        TwoFARequired = 2,
        AccountBanned = 3,
        ChallengeRequired = 4,
        InvalidCredentials = 5,
        Invalid2FACode = 6
    }
}
