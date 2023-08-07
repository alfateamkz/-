using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;

namespace Alfateam.Website.API.Models.EditModels
{
    public class MassMediaPostEditModel : EditModel<MassMediaPost>
    {
        public string ImgPath { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string URL { get; set; }


        public int MainLanguageId { get; set; }


        public override void Fill(MassMediaPost item)
        {
            item.ImgPath = ImgPath;
            item.Title = Title;
            item.ShortDescription = ShortDescription;
            item.URL = URL;

            item.MainLanguageId = MainLanguageId;
        }

        public override bool IsValid()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(ImgPath);
            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= !string.IsNullOrEmpty(ShortDescription);
            isValid &= !string.IsNullOrEmpty(URL);

            isValid &= MainLanguageId > 0;

            return isValid;
        }
    }
}
