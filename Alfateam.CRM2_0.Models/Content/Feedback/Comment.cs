using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Feedback
{
    /// <summary>
    /// Сущность комментария
    /// </summary>
    public class Comment : AbsModel
    {
        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }



        public string Text { get; set; }
        public List<CommentAttachment> Attachments { get; set; } = new List<CommentAttachment>();


        public int Likes { get; set; }
        public List<FeedbackEntry> LikesList { get; set; } = new List<FeedbackEntry>();


        public int Subcomments { get; set; }
        public List<Comment> SubcommentsList { get; set; } = new List<Comment>();
    }
}
