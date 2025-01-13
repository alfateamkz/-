using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Enums
{
    public enum Request2FACodeResultType
    {
        Sent = 1,
        WaitSomeTime = 2,
        SentLimitReached = 3,
        CaptchaRequired = 4,
    }
}
