using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated.ProductEventStats
{
    public enum ProductEventStatEvent
    {
        [Description("ViewContent")]
        ViewContent = 1,
        [Description("AddToCart")]
        AddToCart = 2,
        [Description("Purchase")]
        Purchase = 3,
        [Description("InitiateCheckout")]
        InitiateCheckout = 4,
        [Description("Search")]
        Search = 5,
        [Description("Lead")]
        Lead = 6,
        [Description("AddToWishlist")]
        AddToWishlist = 7,
        [Description("Subscribe")]
        Subscribe = 8,
    }
}
