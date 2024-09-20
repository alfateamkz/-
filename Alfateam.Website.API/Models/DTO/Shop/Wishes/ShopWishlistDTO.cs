using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Shop.Wishes;

namespace Alfateam.Website.API.Models.DTO.Shop.Wishes
{
    public class ShopWishlistDTO : DTOModel<ShopWishlist>
    {

        [ForClientOnly]
        public UserDTO User { get; set; }
        [ForClientOnly]
        public int UserId { get; set; }

        [ForClientOnly]
        public List<ShopWishlistItemDTO> Items { get; set; } = new List<ShopWishlistItemDTO>();
    }
}
