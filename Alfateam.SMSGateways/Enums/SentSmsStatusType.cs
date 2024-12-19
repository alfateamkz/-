using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Enums
{
    public enum SentSmsStatusType
    {
        Success = 1,
        IncorrectPhoneNumber = 2,
        CountryNotAllowed = 3,
        EmptyMessage = 4,
        MessageTextValidationErrorFromGateway = 5,
        InsufficientFunds = 6,
        PhoneNumberDoesNotExist = 7,
        MessageTooLong = 8,
        LimitExceeded = 9,
        AccountBlockedOrDeleted = 10,

        ServiceError = 998,
        Unauthorized = 999,
    }
}
