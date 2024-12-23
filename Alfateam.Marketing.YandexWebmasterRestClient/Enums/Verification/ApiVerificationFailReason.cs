using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification
{
    public enum ApiVerificationFailReason
    {
        [Description("DELEGATION_CANCELLED")]
        DelegationCancelled = 1,
        [Description("DNS_RECORD_NOT_FOUND")]
        DNSRecordNotFound = 2,
        [Description("META_TAG_NOT_FOUND")]
        MetaTagNotFound = 3,
        [Description("WHOIS_EMAIL_NOT_FOUND")]
        WhoisEmailNotFound = 4,
        [Description("WRONG_HTML_PAGE_CONTENT")]
        WrongHTMLPageContent = 5
    }
}
