using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Wishes;

namespace Alfateam.Website.API.Models.DTO.Shop.Wishes
{
    public class ShopWishlistItemDTO : DTOModel<ShopWishlistItem>
    {
        public ShopProductDTO Product { get; set; }
        public int ProductId { get; set; }


        public DateTime AddedAt { get; set; }
    }
}
