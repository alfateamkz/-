using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.ReachFrequencyPredictions
{
    public class ReachFrequencyEstimatesPlacementBreakdown
    {
        //TODO: ReachFrequencyEstimatesPlacementBreakdown get structures 

        [JsonProperty("msite")]
        public object MSite { get; set; }

        [JsonProperty("android")]
        public object Android { get; set; }

        [JsonProperty("ios")]
        public object iOS { get; set; }

        [JsonProperty("desktop")]
        public object Desktop { get; set; }

        [JsonProperty("ig_android")]
        public object IGAndroid { get; set; }

        [JsonProperty("ig_ios")]
        public object IGiOS { get; set; }

        [JsonProperty("ig_reels")]
        public object IGReels { get; set; }

        [JsonProperty("ig_story")]
        public object IGStory { get; set; }

        [JsonProperty("explore_home")]
        public object ExploreHome { get; set; }

        [JsonProperty("ig_others")]
        public object IGOthers { get; set; }

        [JsonProperty("audience_network")]
        public object AudienceNetwork { get; set; }

        [JsonProperty("instant_articles")]
        public object InstantArticles { get; set; }

        [JsonProperty("instream_videos")]
        public object InstreamVideos { get; set; }

        [JsonProperty("suggested_videos")]
        public object SuggestedVideos { get; set; }
    }
}
