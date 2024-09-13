using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.CreateModels.General;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Shop.Order
{
    public class ShopOrderCreateModel : CreateModel<ShopOrder>
    { 
        /// <summary>
        /// Адрес доставки. Необходим, если в заказе есть физические товары
        /// </summary>
        public AddressCreateModel? DeliveryAddress { get; set; }
        public string? Comment { get; set; }
    }
}
