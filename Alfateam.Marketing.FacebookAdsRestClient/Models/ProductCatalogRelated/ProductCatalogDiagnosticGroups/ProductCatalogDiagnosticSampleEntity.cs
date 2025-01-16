using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductCatalogDiagnosticGroups
{
    public class ProductCatalogDiagnosticSampleEntity
    {
        [JsonProperty("content_id")]
        public string ContentId { get; set; }

        [JsonProperty("feed_name")]
        public string FeedName { get; set; }

        [JsonProperty("feed_row_number")]
        public int FeedRowNumber { get; set; }

        [JsonProperty("highlighted_property_values")]
        public List<ProductCatalogDiagnosticAttribute> HighlightedPropertyValues { get; set; } = new List<ProductCatalogDiagnosticAttribute>();

        [JsonProperty("product_catalog_id")]
        public long ProductCatalogId { get; set; }

        [JsonProperty("product_item_id")]
        public long ProductItemId { get; set; }

        [JsonProperty("product_set_id")]
        public long ProductSetId { get; set; }
    }
}
