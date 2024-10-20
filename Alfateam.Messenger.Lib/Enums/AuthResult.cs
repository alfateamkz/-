using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Enums
{
    public enum AuthResult
    {
        Authorized = 1,
        InvalidCredentials = 2,
        TwoFARequired = 3,
        CaptchaRequired = 4,
    }
}
