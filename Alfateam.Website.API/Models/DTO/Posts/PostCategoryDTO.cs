using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.DTO.Posts
{
    public class PostCategoryDTO : DTOModel<PostCategory>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);

        [HiddenFromClient]
        public int MainLanguageId { get; set; }
    }
}
