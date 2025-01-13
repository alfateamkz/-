using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData
{
    public class PostListBlockData : PostBlockData
    {
        [JsonProperty("items")]
        public List<string> Items { get; set; } = new List<string>();

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
