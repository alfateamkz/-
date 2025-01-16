using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductItemAgeGroup
    {
        [Description("adult")]
        Adult = 1,
        [Description("all ages")]
        AllAges = 2,
        [Description("infant")]
        Infant = 3,
        [Description("kids")]
        Kids = 4,
        [Description("newborn")]
        Newborn = 5,
        [Description("teen")]
        Teen = 6,
        [Description("toddler")]
        Toddler = 7,
    }
}
