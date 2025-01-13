using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum AdSetConfiguredStatus
    {
        [Description("ACTIVE")]
        Active = 1,
        [Description("PAUSED")]
        Paused = 2,
        [Description("DELETED")]
        Deleted = 3,
        [Description("ARCHIVED")]
        Archived = 4,
    }
}
