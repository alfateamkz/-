using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductItemReviewStatus
    {
        [Description("NO_REVIEW")]
        NoReview = 1,
        [Description("PENDING")]
        Pending = 2,
        [Description("REJECTED")]
        Rejected = 3,
        [Description("APPROVED")]
        Approved = 4,
        [Description("OUTDATED")]
        Outdated = 5,
    }
}
