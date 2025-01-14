using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeInteractiveComponent
    {
        [JsonProperty("poll_spec")]
        public AdCreativeInteractiveComponentPoll PollSpec { get; set; }

        [JsonProperty("position_spec")]
        public AdCreativeInteractiveComponentPosition PositionSpec { get; set; }

        [JsonProperty("product_tag_spec")]
        public AdCreativeInteractiveComponentProductTag ProductTagSpec { get; set; }

        [JsonProperty("type")]
        public AdCreativeInteractiveComponentType Type { get; set; }
    }
}
