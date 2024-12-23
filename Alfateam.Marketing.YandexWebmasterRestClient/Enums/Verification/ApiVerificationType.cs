using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification
{
    public enum ApiVerificationType
    {
        [Description("DNS")]
        DNS = 1,
        [Description("HTMLFile")]
        HTML_FILE = 2,
        [Description("MetaTag")]
        META_TAG = 3,
        [Description("Whois")]
        WHOIS = 4,
    }
}
