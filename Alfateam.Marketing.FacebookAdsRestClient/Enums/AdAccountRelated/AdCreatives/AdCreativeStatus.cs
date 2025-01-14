using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives
{
    public enum AdCreativeStatus
    {
        [Description("ACTIVE")]
        Active = 1,
        [Description("IN_PROCESS")]
        InProgress = 2,
        [Description("WITH_ISSUES")]
        WithIssues = 3,
        [Description("DELETED")]
        Deleted = 4,
    }
}
