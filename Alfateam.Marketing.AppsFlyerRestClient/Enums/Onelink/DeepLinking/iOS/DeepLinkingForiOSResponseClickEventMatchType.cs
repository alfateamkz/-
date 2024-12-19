using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Onelink.DeepLinking.iOS
{
    public enum DeepLinkingForiOSResponseClickEventMatchType
    {
        [Description("referrer")]
        Referrer = 1,
        [Description("id_matching")]
        IdMatching = 2,
        [Description("srn")]
        SRN = 3,
        [Description("fingerprinting")]
        Fingerprinting = 4,
    }
}
