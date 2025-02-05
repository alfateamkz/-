using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.DTO.Shop
{
    public class ShopProductImageDTO : DTOModel<ShopProductImage>
    {
        [ForClientOnly]
        public string ImgPath { get; set; }
    }
}
