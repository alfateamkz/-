using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.EditModels.Posts
{
    public class PostCategoryMainEditModel : EditModel<PostCategory>
    {
        public string Title { get; set; }
        public int MainLanguageId { get; set; }

        public override bool IsValid()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= MainLanguageId > 0;

            return isValid;
        }
        public override void Fill(PostCategory item)
        {
            item.Title = Title;
            item.MainLanguageId = MainLanguageId;
        }

    }
}
