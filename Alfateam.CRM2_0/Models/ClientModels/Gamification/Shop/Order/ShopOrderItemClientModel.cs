using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Shop;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Shop.Order
{
    public class ShopOrderItemClientModel : ClientModel<ShopOrderItem>
    {
        public ShopItemClientModel Item { get; set; }


        public double PriceForOne { get; set; }
        public double Amount { get; set; }
    }
}
