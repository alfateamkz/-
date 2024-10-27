using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.DTO.Posts
{
    public class PostDTO : AvailabilityDTOModel<Post>
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }


        public string Slug => SlugHelper.GetLatynSlug(Title);



        [ForClientOnly]
        public PostCategoryDTO Category { get; set; }
        [ForClientOnly]
        public PostIndustryDTO Industry { get; set; }


        public int CategoryId { get; set; }
        public int IndustryId { get; set; }



    }
}
