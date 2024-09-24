using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Shop.Orders;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam.Core.Attributes.DTO;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders
{
    public class ShopOrderItemModifierDTO : DTOModel<ShopOrderItemModifier>
    {
        [ForClientOnly]
        public ProductModifierDTO Modifier { get; set; }
        public int ModifierId { get; set; }

        public List<ShopOrderItemModifierOptionDTO> SelectedOptions { get; set; } = new List<ShopOrderItemModifierOptionDTO>();
    }
}
