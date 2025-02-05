using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.DTOLocalization.Shop
{
    public class ShopProductLocalizationDTO : LocalizationDTOModel<ShopProductLocalization>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        /// <summary>
        /// Если UseLocalizationImages == false, то будут использоваться изображения из основной сущности
        /// </summary>
        public bool UseLocalizationImages { get; set; } = true;
        public ShopProductImageDTO MainImage { get; set; }
        public List<ShopProductImageDTO> Images { get; set; } = new List<ShopProductImageDTO>();
    }
}
