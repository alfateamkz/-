using Alfateam.ForPubilcWebsites.API.Abstractions;

namespace Alfateam.ForPubilcWebsites.API.Models.SearchFilters
{
    public class BlogPostCommentSetReactionsSearchFilter : SearchFilter
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int ReactionId { get; set; }
    }
}
