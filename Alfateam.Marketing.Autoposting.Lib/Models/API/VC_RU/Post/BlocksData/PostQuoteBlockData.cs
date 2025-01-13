using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData
{
    public class PostQuoteBlockData : PostBlockData
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("subline1")]
        public string Subline1 { get; set; }

        [JsonProperty("subline2")]
        public string Subline2 { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text_size")]
        public string TextSize { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }
    }
}
