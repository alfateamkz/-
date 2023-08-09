using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.EditModels.Shop
{
    public class ShopOrderItemModifierEditModel
    {
        public int ModifierId { get; set; }
        public List<ShopOrderItemModifierOptionEditModel> SelectedOptions { get; set; } = new List<ShopOrderItemModifierOptionEditModel>();
    }
}
