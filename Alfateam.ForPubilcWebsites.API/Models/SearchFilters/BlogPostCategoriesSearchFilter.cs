using Alfateam.ForPubilcWebsites.API.Abstractions;

namespace Alfateam.ForPubilcWebsites.API.Models.SearchFilters
{
    public class BlogPostCategoriesSearchFilter : SearchFilter
    {
        public int? ParentCategoryId { get; set; }
    }
}
