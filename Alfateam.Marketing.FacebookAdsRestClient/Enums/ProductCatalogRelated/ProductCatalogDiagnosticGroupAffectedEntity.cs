using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductCatalogDiagnosticGroupAffectedEntity
    {
        [Description("product_item")]
        ProductItem = 1,
        [Description("product_catalog")]
        ProductCatalog = 2,
        [Description("product_set")]
        ProductSet = 3,
        [Description("product_event")]
        ProductEvent = 4,
    }
}
