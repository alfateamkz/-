using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class ProductFeedSchedule
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("day_of_month")]
        public int DayOfMonth { get; set; }

        [JsonProperty("day_of_week")]
        public FacebookDayOfWeek DayOfWeek { get; set; }

        [JsonProperty("hour")]
        public int Hour { get; set; }

        [JsonProperty("interval")]
        public ProductFeedScheduleInterval Interval { get; set; }

        [JsonProperty("interval_count")]
        public int IntervalCount { get; set; }

        [JsonProperty("minute")]
        public int Minute { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
