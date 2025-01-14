using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdsImageCropsBounds
    {
        [JsonProperty("left")]
        public double Left { get; set; }

        [JsonProperty("top")]
        public double Top { get; set; }

        [JsonProperty("right")]
        public double Right { get; set; }

        [JsonProperty("bottom")]
        public double Bottom { get; set; }
    }
}
