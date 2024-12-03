using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Posts;
using Alfateam.Website.API.Models.DTO.ContentItems;

namespace Alfateam.Website.API.Models.DTO.Posts
{
    public class PostDTO : AvailabilityDTOModel<Post>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public ContentDTO Content { get; set; }

        [ForClientOnly]
        public string Slug => SlugHelper.GetLatynSlug(Title);



        [ForClientOnly]
        public PostCategoryDTO Category { get; set; }
        [ForClientOnly]
        public PostIndustryDTO Industry { get; set; }


        public int CategoryId { get; set; }
        public int IndustryId { get; set; }



    }
}
