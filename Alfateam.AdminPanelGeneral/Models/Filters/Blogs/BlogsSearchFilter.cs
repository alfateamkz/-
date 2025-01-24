using Alfateam.Administration.Models.Enums;
using Alfateam.AdminPanelGeneral.API.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.Blogs
{
    public class BlogsSearchFilter : SearchFilter
    {
        public BlogType? BlogType { get; set; }
    }
}
