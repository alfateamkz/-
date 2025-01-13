using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class VideoFormat
    {
        [JsonProperty("embed_html")]
        public IFrameWithSrc EmbedHTML { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("height")]
        public uint Height { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("width")]
        public uint Width { get; set; }
    }
}
