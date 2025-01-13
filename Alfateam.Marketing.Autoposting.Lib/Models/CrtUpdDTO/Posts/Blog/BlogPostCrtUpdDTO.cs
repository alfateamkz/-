using Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts.Blog
{
    public class BlogPostCrtUpdDTO : PostCrtUpdDTO
    {
        public string Title { get; set; }
        public List<BlogPostBlockDTO> Block { get; set; } = new List<BlogPostBlockDTO>();
    }
}
