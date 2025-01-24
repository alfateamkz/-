using Alfateam.Administration.Models.Blogs;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs
{
    public class BlogCategoryDTO : DTOModelAbs<BlogCategory>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public string? ImagePath { get; set; }




        [ForClientOnly]
        public BlogCategoryDTO? ParentCategory { get; set; }

        [HiddenFromClient]
        public int? ParentCategoryId { get; set; }
    }
}
