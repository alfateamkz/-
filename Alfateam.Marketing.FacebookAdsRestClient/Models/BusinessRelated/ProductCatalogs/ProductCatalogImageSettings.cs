using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ProductCatalogs
{
    public class ProductCatalogImageSettings
    {
        [JsonProperty("carousel_ad")]
        public ProductCatalogImageSettingsOperation CarouselAd { get; set; }

        [JsonProperty("single_ad")]
        public ProductCatalogImageSettingsOperation SingleAd { get; set; }
    }
}
