using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductCatalogDiagnosticGroupType
    {
        [Description("AR_VISIBILITY_ISSUES")]
        ARVisibilityIssues = 1,
        [Description("ATTRIBUTES_INVALID")]
        AttributesInvalid = 2,
        [Description("ATTRIBUTES_MISSING")]
        AttributesMissing = 3,
        [Description("CATEGORY")]
        Category = 4,
        [Description("CHECKOUT")]
        Checkout = 5,
        [Description("DA_VISIBILITY_ISSUES")]
        DAVisibilityIssues = 6,
        [Description("EVENT_SOURCE_ISSUES")]
        EventSourceIssues = 7,
        [Description("IMAGE_QUALITY")]
        ImageQuality = 8,
        [Description("LOW_QUALITY_TITLE_AND_DESCRIPTION")]
        LowQualityTitleAndDescription = 9,
        [Description("POLICY_VIOLATION")]
        PolicyViolation = 10,
        [Description("SHOPS_VISIBILITY_ISSUES")]
        ShopsVisibilityIssues = 11,
    }
}
