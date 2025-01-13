using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData
{
    public class PostCodeBlockData : PostBlockData
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
