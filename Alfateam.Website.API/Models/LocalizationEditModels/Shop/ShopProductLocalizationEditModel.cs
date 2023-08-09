using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Shop
{
    public class ShopProductLocalizationEditModel : LocalizationEditModel<ShopProductLocalization>
    {
        //TODO: сделать модель

        public string Title { get; set; }
        public string Description { get; set; }


        /// <summary>
        /// Если UseLocalizationImages == false, то будут использоваться изображения из основной сущности
        /// </summary>
        public bool UseLocalizationImages { get; set; } = true;
        public ShopProductImage MainImage { get; set; }
        public List<ShopProductImage> Images { get; set; } = new List<ShopProductImage>();
    }
}
