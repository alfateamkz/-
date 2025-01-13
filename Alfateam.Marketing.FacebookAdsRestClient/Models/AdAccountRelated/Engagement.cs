using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class Engagement
    {
        [JsonProperty("count")]
        public uint Count { get; set; }

        [JsonProperty("count_string")]
        public string CountString { get; set; }

        [JsonProperty("count_string_with_like")]
        public string CountStringWithLike { get; set; }

        [JsonProperty("count_string_without_like")]
        public string CountStringWithoutLike { get; set; }

        [JsonProperty("social_sentence")]
        public string SocialSentence { get; set; }

        [JsonProperty("social_sentence_with_like")]
        public string SocialSentenceWithLike { get; set; }

        [JsonProperty("social_sentence_without_like")]
        public string SocialSentenceWithoutLike { get; set; }
    }
}
