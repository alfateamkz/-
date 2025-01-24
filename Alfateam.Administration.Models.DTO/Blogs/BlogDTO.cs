using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.General;
using Alfateam.Administration.Models.DTO.General;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.Blogs
{
    public class BlogDTO : DTOModelAbs<Blog>
    {
        public string Title { get; set; }
        public BlogType Type { get; set; }


        [ForClientOnly]
        public ProductDTO Product { get; set; }

        [HiddenFromClient]
        public int ProductId { get; set; }
    }
}
