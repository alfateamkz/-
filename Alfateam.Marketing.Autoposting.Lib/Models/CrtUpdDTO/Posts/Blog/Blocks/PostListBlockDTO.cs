using Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts;
using Alfateam.Marketing.Autoposting.Lib.Enums.Posts.Blocks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts.Blog.Blocks
{
    public class PostListBlockDTO : BlogPostBlockDTO
    {
        public List<string> Items { get; set; } = new List<string>();
        public PostListBlockDTOType Type { get; set; }
    }
}
