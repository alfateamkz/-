using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class LimitOffset
    {
        [JsonProperty("Limit")]
        public long Limit { get; set; }

        [JsonProperty("Offset")]
        public long Offset { get; set; }
    }
}
