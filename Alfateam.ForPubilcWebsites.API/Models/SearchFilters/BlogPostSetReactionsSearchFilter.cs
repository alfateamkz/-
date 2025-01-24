using Alfateam.ForPubilcWebsites.API.Abstractions;

namespace Alfateam.ForPubilcWebsites.API.Models.SearchFilters
{
    public class BlogPostSetReactionsSearchFilter : SearchFilter
    {
        public int PostId { get; set; }
        public int ReactionId { get; set; }
    }
}
