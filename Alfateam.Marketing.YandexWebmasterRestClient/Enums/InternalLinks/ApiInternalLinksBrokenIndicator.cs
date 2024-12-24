using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.InternalLinks
{
    public enum ApiInternalLinksBrokenIndicator
    {
        [Description("SITE_ERROR")]
        SiteError = 1,
        [Description("DISALLOWED_BY_USER")]
        DisallowedByUser = 2,
        [Description("UNSUPPORTED_BY_ROBOT")]
        UnsupportedByRobot = 3
    }
}
