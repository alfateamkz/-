using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop.Modifiers;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.ClientModels.Shop.Orders
{
    public class ShopOrderItemModifierClientModel : ClientModel
    {
        public ProductModifierClientModel Modifier { get; set; }
        public List<ShopOrderItemModifierOptionClientModel> SelectedOptions { get; set; } = new List<ShopOrderItemModifierOptionClientModel>();
    }
}
