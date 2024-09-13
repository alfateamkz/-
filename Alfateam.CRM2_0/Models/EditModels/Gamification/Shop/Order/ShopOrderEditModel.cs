using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.EditModels.General;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.Shop.Order
{
    public class ShopOrderEditModel : EditModel<ShopOrder>
    {
        /// <summary>
        /// Адрес доставки. Необходим, если в заказе есть физические товары
        /// </summary>
        public AddressEditModel? DeliveryAddress { get; set; }
        public string? Comment { get; set; }
    }
}
