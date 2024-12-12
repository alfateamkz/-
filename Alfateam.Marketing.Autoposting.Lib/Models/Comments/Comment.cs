using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.Comments
{
    public class Comment
    {
        public string? Text { get; set; }
       

        public List<CommentAttachment> Attachments { get; set; } = new List<CommentAttachment>();
        public List<Comment> SubComments { get; set; } = new List<Comment>();


        public int LikesCount { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
