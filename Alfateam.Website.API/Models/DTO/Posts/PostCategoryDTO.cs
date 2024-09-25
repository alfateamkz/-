using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.DTO.Posts
{
    public class PostCategoryDTO : AvailabilityDTOModel<PostCategory>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);

        [HiddenFromClient]
        public int MainLanguageId { get; set; }
    }
}
