using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums
{
    public enum MediaFetchStatus
    {
        [Description("NO_STATUS")]
        NoStatus = 1,
        [Description("DIRECT_UPLOAD")]
        DirectUpload = 2,
        [Description("FETCHED")]
        Fetched = 3,
        [Description("FETCH_FAILED")]
        FetchFailed = 4,
        [Description("OUTDATED")]
        Outdated = 5,
        [Description("PARTIAL_FETCH")]
        PartialFetch = 6,
    }
}
