using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.Hotels
{
    public class Hotel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("applinks")]
        public CatalogItemAppLinks Applinks { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("guest_ratings")]
        public string GuestRatings { get; set; }

        [JsonProperty("hotel_id")]
        public string HotelId { get; set; }

        [JsonProperty("image_fetch_status")]
        public MediaFetchStatus ImageFetchStatus { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; } = new List<string>();

        [JsonProperty("lowest_base_price")]
        public string LowestBasePrice { get; set; }

        [JsonProperty("loyalty_program")]
        public string LoyaltyProgram { get; set; }

        [JsonProperty("margin_level")]
        public uint MarginLevel { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("product_priority_0")]
        public float ProductPriority0 { get; set; }

        [JsonProperty("product_priority_1")]
        public float ProductPriority1 { get; set; }

        [JsonProperty("product_priority_2")]
        public float ProductPriority2 { get; set; }

        [JsonProperty("product_priority_3")]
        public float ProductPriority3 { get; set; }

        [JsonProperty("product_priority_4")]
        public float ProductPriority4 { get; set; }

        [JsonProperty("sale_price")]
        public string SalePrice { get; set; }

        [JsonProperty("sanitized_images")]
        public List<string> SanitizedImages { get; set; } = new List<string>();

        [JsonProperty("star_rating")]
        public float StarRating { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonProperty("unit_price")]
        public HotelCatalogItemUnitPrice UnitPrice { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("visibility")]
        public HotelVisibility Visibility { get; set; }
    }
}
