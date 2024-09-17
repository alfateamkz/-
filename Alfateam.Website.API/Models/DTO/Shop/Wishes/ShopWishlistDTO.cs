using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Shop.Wishes;

namespace Alfateam.Website.API.Models.DTO.Shop.Wishes
{
    public class ShopWishlistDTO : DTOModel<ShopWishlist>
    {
        public UserDTO User { get; set; }
        public int UserId { get; set; }


        public List<ShopWishlistItemDTO> Items { get; set; } = new List<ShopWishlistItemDTO>();
    }
}
