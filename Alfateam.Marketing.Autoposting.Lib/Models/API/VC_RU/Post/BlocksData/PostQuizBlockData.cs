using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData
{
    public class PostQuizBlockData : PostBlockData
    {
        [JsonProperty("uid")]
        public string UID { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("tmp_hash")]
        public string TmpHash { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("items")]
        public Dictionary<string, string> Items { get; set; } = new Dictionary<string, string>();

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }

        [JsonProperty("date_created")]
        public int DateCreated { get; set; }
    }
}
