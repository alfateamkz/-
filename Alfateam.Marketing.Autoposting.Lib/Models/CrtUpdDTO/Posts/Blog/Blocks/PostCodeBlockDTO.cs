using Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts.Blog.Blocks
{
    public class PostCodeBlockDTO : BlogPostBlockDTO
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
