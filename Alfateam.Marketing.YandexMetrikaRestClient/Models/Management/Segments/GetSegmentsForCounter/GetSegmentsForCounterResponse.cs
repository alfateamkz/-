using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Segments.GetSegmentsForCounter
{
    public class GetSegmentsForCounterResponse
    {
        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; } = new List<Segment>();
    }
}
