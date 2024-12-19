using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Onelink.DeepLinking.iOS
{
    public enum DeepLinkingForiOSBodyIdfaType
    {
        [Description("unhashed")]
        Unhashed = 1,
        [Description("sha1")]
        SHA1 = 2,
        [Description("md5")]
        MD5 = 3,
    }
}
