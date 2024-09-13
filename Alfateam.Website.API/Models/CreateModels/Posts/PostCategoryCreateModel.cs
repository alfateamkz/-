using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.CreateModels.Posts
{
    public class PostCategoryCreateModel : CreateModel<PostCategory>
    {
        public string Title { get; set; }
        public int MainLanguageId { get; set; }


    }
}
