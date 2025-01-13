using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class PageRestaurantSpecialties
    {
        [JsonProperty("breakfast")]
        public bool Breakfast { get; set; }

        [JsonProperty("coffee")]
        public bool Coffee { get; set; }

        [JsonProperty("dinner")]
        public bool Dinner { get; set; }

        [JsonProperty("drinks")]
        public bool Drinks { get; set; }

        [JsonProperty("lunch")]
        public bool Lunch { get; set; }
    }
}
