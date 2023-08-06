using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Posts
{
    public class PostCategoryLocalizationEditModel : LocalizationEditModel<PostCategoryLocalization>
    {
        public string Title { get; set; }

        public override bool IsValid()
        {
            bool isValid = true;
            isValid &= !string.IsNullOrEmpty(Title);
            return isValid;
        }

        public override void Fill(PostCategoryLocalization localization)
        {
            localization.Title = Title;
        }
    }
}
