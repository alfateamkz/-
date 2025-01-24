using Alfateam.AdminPanelGeneral.API.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.Blogs
{
    public class BlogPostsSearchFilter : SearchFilter
    {
        public int? CategoryId { get; set; }
    }
}
