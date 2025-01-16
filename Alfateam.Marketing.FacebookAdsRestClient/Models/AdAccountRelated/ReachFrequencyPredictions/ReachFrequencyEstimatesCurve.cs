using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.ReachFrequencyPredictions
{
    public class ReachFrequencyEstimatesCurve
    {
        [JsonProperty("num_points")]
        public long NumPoints { get; set; }

        [JsonProperty("reach")]
        public object Reach { get; set; } //TODO: check type

        [JsonProperty("viewsraw_reach")]
        public object ViewsrawReach { get; set; } //TODO: check type

        [JsonProperty("budget")]
        public object Budget { get; set; } //TODO: check type

        [JsonProperty("impression")]
        public object Impression { get; set; } //TODO: check type

        [JsonProperty("interpolated_reach")]
        public object InterpolatedReach { get; set; } //TODO: check type

        [JsonProperty("raw_impression")]
        public object RawImpression { get; set; } //TODO: check type
    }
}
