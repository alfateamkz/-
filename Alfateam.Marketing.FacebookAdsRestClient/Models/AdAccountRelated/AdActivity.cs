using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdActivity
    {
        [JsonProperty("actor_id")]
        public long ActorId { get; set; }

        [JsonProperty("actor_name")]
        public string ActorName { get; set; }

        [JsonProperty("application_id")]
        public long ApplicationId { get; set; }

        [JsonProperty("application_name")]
        public string ApplicationName { get; set; }

        [JsonProperty("date_time_in_timezone")]
        public DateTime DateTimeInTimezone { get; set; }

        [JsonProperty("event_time")]
        public DateTime EventTime { get; set; }

        [JsonProperty("event_type")]
        public AdActivityEventType EventType { get; set; }

        [JsonProperty("extra_data")]
        public string ExtraData { get; set; }

        [JsonProperty("object_id")]
        public long ObjectId { get; set; }

        [JsonProperty("object_name")]
        public string ObjectName { get; set; }

        [JsonProperty("object_type")]
        public string ObjectType { get; set; }

        [JsonProperty("translated_event_type")]
        public string TranslatedEventType { get; set; }
    }
}
