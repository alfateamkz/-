using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.Destinations
{
    public class Destination
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("applinks")]
        public CatalogItemAppLinks Applinks { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("destination_id")]
        public string DestinationId { get; set; }

        [JsonProperty("image_fetch_status")]
        public MediaFetchStatus ImageFetchStatus { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; } = new List<string>();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("price_change")]
        public string PriceChange { get; set; }

        [JsonProperty("sanitized_images")]
        public List<string> SanitizedImages { get; set; } = new List<string>();

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonProperty("types")]
        public List<string> Types { get; set; } = new List<string>();

        [JsonProperty("unit_price")]
        public DestinationCatalogItemUnitPrice UnitPrice { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("visibility")]
        public DestinationVisibility Visibility { get; set; }
    }
}
