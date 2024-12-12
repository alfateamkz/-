using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.Posts
{
    public class Post
    {
        public string? Content { get; set; }
        public List<PostAttachment> Attachments { get; set; } = new List<PostAttachment>();




        public int LikesCount { get; set; }
        public int RepostsCount { get; set; }
        public int CommentsCount { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
