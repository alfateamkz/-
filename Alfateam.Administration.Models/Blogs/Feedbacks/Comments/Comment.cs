using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs.Feedbacks.Comments
{
    public class Comment : AbsModel
    {
        public string CreatedByIdentifier { get; set; }

        public string Text { get; set; }
        public bool IsDeletedWithoutThread { get; set; }
        public List<CommentAttachment> Attachments { get; set; } = new List<CommentAttachment>();





        public List<Comment> Subcomments { get; set; } = new List<Comment>();
        public List<ReactionCounter> ReactionCounters { get; set; } = new List<ReactionCounter>();
    }
}
