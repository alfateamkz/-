using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductItemAvailability
    {
        [Description("in stock")]
        InStock = 1,
        [Description("out of stock")]
        OutOfStock = 2,
        [Description("preorder")]
        Preorder = 3,
        [Description("available for order")]
        AvailableForOrder = 4,
        [Description("discontinued")]
        Discontinued = 5,
        [Description("pending")]
        Pending = 6,
        [Description("mark_as_sold")]
        MarkAsSold = 7,
    }
}
