using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class CoverPhoto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("cover_id")]
        public long CoverId { get; set; }

        [JsonProperty("offset_x")]
        public float OffsetX { get; set; }

        [JsonProperty("offset_y")]
        public float OffsetY { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
