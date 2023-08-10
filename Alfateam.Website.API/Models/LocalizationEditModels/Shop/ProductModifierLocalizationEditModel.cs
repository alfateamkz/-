using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Shop
{
    public class ProductModifierLocalizationEditModel : EditModel<ProductModifierLocalization>
    {
        public string Title { get; set; }
    }
}
