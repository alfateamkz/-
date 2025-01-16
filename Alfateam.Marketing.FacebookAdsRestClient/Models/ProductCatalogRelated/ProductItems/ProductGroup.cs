using Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ProductCatalogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class ProductGroup
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("product_catalog")]
        public ProductCatalog ProductCatalog { get; set; }

        [JsonProperty("retailer_id")]
        public string RetailerId { get; set; }

        [JsonProperty("variants")]
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
}
