using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Onelink.DeepLinking.Android
{
    public enum DeepLinkingForAndroidBodyOaidType
    {
        [Description("unhashed")]
        Unhashed = 1,
        [Description("sha1")]
        SHA1 = 2,
        [Description("md5")]
        MD5 = 3,
    }
}
