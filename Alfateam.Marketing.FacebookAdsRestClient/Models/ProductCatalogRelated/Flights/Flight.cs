using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.Flights
{
    public class Flight
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("applinks")]
        public CatalogItemAppLinks Applinks { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("destination_airport")]
        public string DestinationAirport { get; set; }

        [JsonProperty("destination_city")]
        public string DestinationCity { get; set; }

        [JsonProperty("flight_id")]
        public string FlightId { get; set; }

        [JsonProperty("image_fetch_status")]
        public MediaFetchStatus ImageFetchStatus { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; } = new List<string>();

        [JsonProperty("oneway_currency")]
        public string OnewayCurrency { get; set; }

        [JsonProperty("oneway_price")]
        public string OnewayPrice { get; set; }

        [JsonProperty("origin_airport")]
        public string OriginAirport { get; set; }

        [JsonProperty("origin_city")]
        public string OriginCity { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("sanitized_images")]
        public List<string> SanitizedImages { get; set; } = new List<string>();

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonProperty("unit_price")]
        public FlightCatalogItemUnitPrice UnitPrice { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("visibility")]
        public FlightVisibility Visibility { get; set; }
    }
}
