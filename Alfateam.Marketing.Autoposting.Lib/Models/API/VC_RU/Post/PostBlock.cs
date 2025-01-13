using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post
{
    public class PostBlock
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public PostBlockData Data { get; set; }

        [JsonProperty("cover")]
        public bool Cover { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("anchor")]
        public string Anchor { get; set; }
    }
}
