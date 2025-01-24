using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.Blogs.Feedbacks.Watches;
using Alfateam.Administration.Models.DTO.Abstractions;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Watches;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs
{
    public class BlogPostDTO : DTOModelAbs<BlogPost>
    {
        public string Title { get; set; }
        public List<BlogPostBlockDTO> Blocks { get; set; } = new List<BlogPostBlockDTO>();


        public BlogPostStatus Status { get; set; }

        [ForClientOnly]
        public List<BlogCategoryDTO> Categories { get; set; } = new List<BlogCategoryDTO>();

        [DTOFieldBindWith("Categories", typeof(BlogCategory))]
        public List<int> CategoriesIds { get; set; } = new List<int>();


        public BlogCommentsStatus CommentsStatus { get; set; }
        public bool PostReactionsEnabled { get; set; }
        public bool CommentReactionsEnabled { get; set; }





        [ForClientOnly]
        public CommentsCounterDTO CommentsCounter { get; set; }

        [ForClientOnly]
        public List<ReactionCounterDTO> ReactionCounters { get; set; } = new List<ReactionCounterDTO>();

        [ForClientOnly]
        public WatchesCounterDTO WatchesCounter { get; set; }
    }
}
