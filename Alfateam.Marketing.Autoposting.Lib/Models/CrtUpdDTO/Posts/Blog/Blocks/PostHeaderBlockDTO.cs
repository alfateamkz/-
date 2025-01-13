using Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts.Blog.Blocks
{
    public class PostHeaderBlockDTO : BlogPostBlockDTO
    {
        public string Text { get; set; }
        public string Style { get; set; }
    }
}
