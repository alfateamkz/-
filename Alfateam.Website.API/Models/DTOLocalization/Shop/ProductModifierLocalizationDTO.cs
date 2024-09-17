using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;

namespace Alfateam.Website.API.Models.DTOLocalization.Shop
{
    public class ProductModifierLocalizationDTO : LocalizationDTOModel<ProductModifierLocalization>
    {
        public string Title { get; set; }
    }
}
