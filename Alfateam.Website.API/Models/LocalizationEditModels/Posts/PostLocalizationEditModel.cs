using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Posts
{
    public class PostLocalizationEditModel : LocalizationEditModel
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }

        public override bool IsValid()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= !string.IsNullOrEmpty(ImgPath);
            isValid &= !string.IsNullOrEmpty(ShortDescription);
            isValid &= Content != null;

            return isValid;
        }

        public void Fill(PostLocalization localization)
        {
            localization.Title = Title;
            localization.ImgPath = ImgPath;
            localization.ShortDescription = ShortDescription;
            localization.Content = Content;
        }
    }
}
