using Alfateam.ForPubilcWebsites.API.Abstractions;

namespace Alfateam.ForPubilcWebsites.API.Models.SearchFilters
{
    public class BlogPostCommentsSearchFilter : SearchFilter
    {
        public int PostId { get; set; }
    }
}
