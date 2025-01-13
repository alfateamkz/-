using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post
{
    public class PostCounters
    {
        [JsonProperty("comments")]
        public int Comments { get; set; }

        [JsonProperty("favorites")]
        public int Favorites { get; set; }

        [JsonProperty("reposts")]
        public int Reposts { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("hits")]
        public int Hits { get; set; }

        [JsonProperty("reads")]
        public object Reads { get; set; }
    }
}
