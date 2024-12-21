using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Segments
{
    public class WithSegmentResponse
    {
        [JsonProperty("segment")]
        public Segment Segment { get; set; }
    }
}
