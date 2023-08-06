using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions.Interfaces;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.EditModels.Posts
{
    public class PostMainEditModel : EditModel
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }

        public int CategoryId { get; set; }
        public int IndustryId { get; set; }


        public int MainLanguageId { get; set; }

        public override bool IsValid()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= !string.IsNullOrEmpty(ImgPath);
            isValid &= !string.IsNullOrEmpty(ShortDescription);
            isValid &= Content != null;
            isValid &= CategoryId > 0;
            isValid &= IndustryId > 0;
            isValid &= MainLanguageId > 0;

            return isValid;
        }

        public void Fill(Post post)
        {
            post.Title = Title;
            post.ImgPath = ImgPath;
            post.ShortDescription = ShortDescription;
            post.Content = Content;

            post.CategoryId = CategoryId;
            post.IndustryId = IndustryId;

            post.MainLanguageId = MainLanguageId;
        }
    }
}
