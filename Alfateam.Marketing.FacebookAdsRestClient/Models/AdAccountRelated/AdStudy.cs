using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdStudy
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }

        [JsonProperty("canceled_time")]
        public DateTime CanceledTime { get; set; }

        [JsonProperty("cooldown_start_time")]
        public DateTime CooldownStartTime { get; set; }

        [JsonProperty("created_by")]
        public User CreatedBy { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("observation_end_time")]
        public DateTime ObservationEndTime { get; set; }

        [JsonProperty("results_first_available_date")]
        public DateTime ResultsFirstAvailableDate { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_by")]
        public User UpdatedBy { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
