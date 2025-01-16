using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductItemCondition
    {
        [Description("new")]
        New = 1,
        [Description("refurbished")]
        Refurbished = 2,
        [Description("used")]
        Used = 3,
        [Description("used_like_new")]
        UsedLikeNew = 4,
        [Description("used_good")]
        IsedGood = 5,
        [Description("used_fair")]
        UsedFair = 6,
        [Description("cpo")]
        CPO = 7,
        [Description("open_box_new")]
        OpenBoxNew = 8,
    }
}
