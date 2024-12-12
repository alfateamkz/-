using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Enums
{
    public enum AutopostingAccountStatus
    {
        NotAuthorized = 1,
        TwoFARequired = 2,
        Authorized = 3,
        Banned = 4,
        InvalidCredentials = 5,
        CredentialsChanged = 6,
    }
}
