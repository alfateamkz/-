using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.ReachFrequencyPredictions
{
    public class ReachFrequencyPredictionPausePeriod
    {
        [JsonProperty("pauseStartDay")]
        public DateTime PauseStartDay { get; set; }

        [JsonProperty("startTimeOffset")]
        public DateTime StartTimeOffset { get; set; }

        [JsonProperty("pauseEndDay")]
        public DateTime PauseEndDay { get; set; }

        [JsonProperty("endTimeOffset")]
        public DateTime EndTimeOffset { get; set; }
    }
}
