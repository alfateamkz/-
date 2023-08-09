using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Shop
{
    public class ShopProductCategoryLocalizationEditModel : LocalizationEditModel<ShopProductCategoryLocalization>
    {
        public string Title { get; set; }

        public int MainLanguageId { get; set; }
    }
}
