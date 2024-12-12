using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Lettering.Lib.Enums
{
    public enum SendMessageResponseType
    {
        Success = 1,
        ContactNotFound = 2,
        SMS_InsufficientFunds = 3,
        ContactBannedUs = 4,
        ContactPrivacyError = 5,

        InvalidData = 999
    }
}
