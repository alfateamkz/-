using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Shop.Order
{
    public class ShopOrderClientModel : ClientModel<ShopOrder>
    {
        public ShopOrderStatus Status { get; set; } 
        public UserClientModel OrderedBy { get; set; }
   


        /// <summary>
        /// Адрес доставки. Необходим, если в заказе есть физические товары
        /// </summary>
        public AddressClientModel? DeliveryAddress { get; set; }
        public string? Comment { get; set; }
    }
}
