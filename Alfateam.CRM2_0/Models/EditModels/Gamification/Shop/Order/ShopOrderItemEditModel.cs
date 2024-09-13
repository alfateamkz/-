using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.Shop.Order
{
    public class ShopOrderItemEditModel : EditModel<ShopOrderItem>
    {
        public int ItemId { get; set; }


        public double PriceForOne { get; set; }
        public double Amount { get; set; }
    }
}
