using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.Blogs.Feedbacks.Watches;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.SEO;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs
{
    public class BlogPost : AbsModel
    {
        public string Title { get; set; }
        public List<BlogPostBlock> Blocks { get; set; } = new List<BlogPostBlock>();
        public Metatags Metatags { get; set; }




        public BlogPostStatus Status { get; set; }
        public List<BlogCategory> Categories { get; set; } = new List<BlogCategory>();



        public BlogCommentsStatus CommentsStatus { get; set; }
        public bool PostReactionsEnabled { get; set; }
        public bool CommentReactionsEnabled { get; set; }



        public CommentsCounter CommentsCounter { get; set; }
        public List<ReactionCounter> ReactionCounters { get; set; } = new List<ReactionCounter>();
        public WatchesCounter WatchesCounter { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BlogLanguageZoneId { get; set; }
    }
}
