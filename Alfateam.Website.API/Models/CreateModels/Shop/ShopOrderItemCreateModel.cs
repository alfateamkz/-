using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.CreateModels.Shop
{
    public class ShopOrderItemCreateModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public double Amount { get; set; }


        public List<ShopOrderItemModifierCreateModel> SelectedModifiers { get; set; } = new List<ShopOrderItemModifierCreateModel>();
    }
}
