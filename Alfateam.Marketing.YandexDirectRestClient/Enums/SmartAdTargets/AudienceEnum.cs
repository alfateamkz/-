using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.SmartAdTargets
{
    public enum AudienceEnum
    {
        [Description("INTERESTED_IN_SIMILAR_PRODUCTS")]
        InterestedInSimilarProducts = 1,
        [Description("VISITED_PRODUCT_PAGE")]
        VisitedProductPage = 2,
        [Description("ALL_SEGMENTS")]
        AllSegments = 3,
    }
}
