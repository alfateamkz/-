using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification
{
    public enum ApiExplicitVerificationType
    {
        [Description("AUTO")]
        Auto = 1,
        [Description("DELEGATED")]
        Delegated = 2,
        [Description("DNS")]
        DNS = 3,
        [Description("HTML_FILE")]
        HTMLFile = 4,
        [Description("META_TAG")]
        MetaTag = 5,
        [Description("TXT_FILE")]
        TXTFile = 6,
        [Description("WHOIS")]
        Whois = 7
    }
}
