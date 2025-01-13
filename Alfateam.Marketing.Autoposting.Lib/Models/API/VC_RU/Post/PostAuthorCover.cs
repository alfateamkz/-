using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post
{
    public class PostAuthorCover
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public PostAuthorCoverData Data { get; set; }
    }
}
