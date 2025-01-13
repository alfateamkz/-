using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class PageRestaurantServices
    {
        [JsonProperty("catering")]
        public bool Catering { get; set; }

        [JsonProperty("delivery")]
        public bool Delivery { get; set; }

        [JsonProperty("groups")]
        public bool Groups { get; set; }

        [JsonProperty("kids")]
        public bool Kids { get; set; }

        [JsonProperty("outdoor")]
        public bool Outdoor { get; set; }

        [JsonProperty("pickup")]
        public bool Pickup { get; set; }

        [JsonProperty("reserve")]
        public bool Reserve { get; set; }

        [JsonProperty("takeout")]
        public bool Takeout { get; set; }

        [JsonProperty("waiter")]
        public bool Waiter { get; set; }

        [JsonProperty("walkins")]
        public bool Walkins { get; set; }
    }
}
