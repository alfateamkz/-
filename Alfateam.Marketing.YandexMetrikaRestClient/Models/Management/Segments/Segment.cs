using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Segments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Segments
{
    public class Segment
    {
        [JsonProperty("counter_id")]
        public int CounterId { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("expression")]
        public string Expression { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("segment_id")]
        public int SegmentId { get; set; }

        [JsonProperty("segment_source")]
        public string SegmentSource { get; set; }

        [JsonProperty("status")]
        public SegmentStatus Status { get; set; }
    }
}
