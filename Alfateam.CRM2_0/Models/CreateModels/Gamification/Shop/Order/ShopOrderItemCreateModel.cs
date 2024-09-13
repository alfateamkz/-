using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Shop.Order
{
    public class ShopOrderItemCreateModel : CreateModel<ShopOrderItem>
    {
        public int ItemId { get; set; }


        public double PriceForOne { get; set; }
        public double Amount { get; set; }
    }
}
