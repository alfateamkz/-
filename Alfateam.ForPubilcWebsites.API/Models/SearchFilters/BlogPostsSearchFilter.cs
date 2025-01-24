using Alfateam.ForPubilcWebsites.API.Abstractions;

namespace Alfateam.ForPubilcWebsites.API.Models.SearchFilters
{
    public class BlogPostsSearchFilter : SearchFilter
    {
        public int? CategoryId { get; set; }
    }
}
