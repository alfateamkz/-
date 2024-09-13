
namespace Alfateam.Website.API.Models.CreateModels.Shop
{
    public class ShopOrderItemModifierCreateModel
    {
        public int ModifierId { get; set; }
        public List<ShopOrderItemModifierOptionCreateModel> SelectedOptions { get; set; } = new List<ShopOrderItemModifierOptionCreateModel>();
    }
}
