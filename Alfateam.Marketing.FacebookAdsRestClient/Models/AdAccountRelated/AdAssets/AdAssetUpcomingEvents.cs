using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetUpcomingEvents
    {
        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("event_id")]
        public long EventId { get; set; }

        [JsonProperty("event_title")]
        public string EventTitle { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("updated_time")]
        public long UpdatedTime { get; set; }
    }
}
