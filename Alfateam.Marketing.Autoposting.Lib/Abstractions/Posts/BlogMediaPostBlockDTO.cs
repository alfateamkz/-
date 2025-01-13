using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts
{
    public abstract class BlogMediaPostBlockDTO : BlogPostBlockDTO
    {
        public string Filepath { get; set; }
    }
}
