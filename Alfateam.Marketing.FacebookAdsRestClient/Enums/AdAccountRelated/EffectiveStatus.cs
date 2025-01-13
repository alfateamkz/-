using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum EffectiveStatus
    {
        [Description("ACTIVE")]
        Active = 1,
        [Description("PAUSED")]
        Paused = 2,
        [Description("DELETED")]
        Deleted = 3,
        [Description("ARCHIVED")]
        Archived = 4,
        [Description("IN_PROCESS")]
        InProgress = 5,
        [Description("WITH_ISSUES")]
        WithIssues = 6,
    }
}
