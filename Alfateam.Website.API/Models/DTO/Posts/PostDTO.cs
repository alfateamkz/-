using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.DTO.Posts
{
    public class PostDTO : DTOModel<Post>
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }


        public string Slug => SlugHelper.GetLatynSlug(Title);


        public PostCategoryDTO Category { get; set; }
        public PostIndustryDTO Industry { get; set; }


        public int CategoryId { get; set; }
        public int IndustryId { get; set; }


        public int MainLanguageId { get; set; }
    }
}
