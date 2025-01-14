using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives
{
    public enum AdCreativeAuthorizationCategory
    {
        [Description("NONE")]
        None = 1,
        [Description("POLITICAL")]
        Political = 2,
        [Description("POLITICAL_WITH_DIGITALLY_CREATED_MEDIA")]
        PoliticalWithDigitallyCreatedMedia = 3,
    }
}
