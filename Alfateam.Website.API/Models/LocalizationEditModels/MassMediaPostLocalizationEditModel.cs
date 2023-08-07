using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items;

namespace Alfateam.Website.API.Models.LocalizationEditModels
{
    public class MassMediaPostLocalizationEditModel : LocalizationEditModel<MassMediaPostLocalization>
    {

        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public override void Fill(MassMediaPostLocalization item)
        {
            item.Title = Title;
            item.ShortDescription = ShortDescription;
        }

        public override bool IsValid()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= !string.IsNullOrEmpty(ShortDescription);

            return isValid;
        }
    }
}
