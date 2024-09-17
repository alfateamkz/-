using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;

namespace Alfateam.Website.API.Models.DTOLocalization.Shop
{
    public class ProductModifierItemLocalizationDTO : LocalizationDTOModel<ProductModifierItemLocalization>
    {
        public string Title { get; set; }
    }
}
