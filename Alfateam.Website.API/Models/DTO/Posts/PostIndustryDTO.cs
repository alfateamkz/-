using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.DTO.Posts
{
    public class PostIndustryDTO : AvailabilityDTOModel<PostIndustry>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);


    }
}
