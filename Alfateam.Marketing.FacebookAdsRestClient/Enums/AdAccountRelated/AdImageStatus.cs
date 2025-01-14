using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum AdImageStatus
    {
        [Description("ACTIVE")]
        Active = 1,
        [Description("INTERNAL")]
        Internal = 2,
        [Description("DELETED")]
        Deleted = 3,
    }
}
