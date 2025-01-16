using Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ProductCatalogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductSets
{
    public class ProductSet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("auto_creation_url")]
        public string AutoCreationURL { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("latest_metadata")]
        public ProductSetMetadata LatestMetadata { get; set; }

        [JsonProperty("live_metadata")]
        public ProductSetMetadata LiveMetadata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product_catalog")]
        public ProductCatalog ProductCatalog { get; set; }

        [JsonProperty("product_count")]
        public uint ProductCount { get; set; }

        [JsonProperty("retailer_id")]
        public string RetailerId { get; set; }
    }
}
