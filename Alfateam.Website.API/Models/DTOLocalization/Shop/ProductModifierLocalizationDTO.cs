using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;

namespace Alfateam.Website.API.Models.DTOLocalization.Shop
{
    public class ProductModifierLocalizationDTO : DTOModel<ProductModifierLocalization>
    {
        public string Title { get; set; }
    }
}
