using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductCatalogDiagnosticGroupSeverity
    {
        [Description("MUST_FIX")]
        MustFix = 1,
        [Description("OPPORTUNITY")]
        Opportunity = 2,
    }
}
