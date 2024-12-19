using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Audiences.Identifiers
{
    public enum AIHRemoveIdentifierBodyDataIdentifierType
    {
        [Description("hashed_emails")]
        HashedEmails = 1,
        [Description("phone_number_sha256")]
        PhoneNumberSha256 = 2,
        [Description("phone_number_e164_sha256")]
        PhoneNumberE164Sha256 = 3,
    }
}
