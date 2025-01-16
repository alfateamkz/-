using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum IngestionSourceType
    {
        [Description("primary_feed")]
        PrimaryFeed = 1,
        [Description("supplementary_feed")]
        SupplementaryFeed = 2,
    }
}
