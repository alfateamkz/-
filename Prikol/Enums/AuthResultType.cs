using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Enums
{
    public enum AuthResultType
    {
        Authorized = 1,
        InvalidCredentials = 2,
        TwoFARequired = 3,
        Invalid2FACode = 4,
        CaptchaRequired = 5,
    }
}
