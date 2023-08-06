using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models
{
    public class ShopOrderItemEditModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public double Amount { get; set; }


        public List<ShopOrderItemModifierEditModel> SelectedModifiers { get; set; } = new List<ShopOrderItemModifierEditModel>();
    }
}
