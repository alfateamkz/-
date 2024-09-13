using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Gamification;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Shop.Order
{
    /// <summary>
    /// Модель заказа в магазине геймификации
    /// </summary>
    public class ShopOrder : AbsModel
    {
        public ShopOrderStatus Status { get; set; } = ShopOrderStatus.Basket;

        public User OrderedBy { get; set; }
        public int OrderedById { get; set; }

        public List<ShopOrderItem> Items { get; set; } = new List<ShopOrderItem>();


        /// <summary>
        /// Адрес доставки. Необходим, если в заказе есть физические товары
        /// </summary>
        public Address? DeliveryAddress { get; set; }
        public string? Comment { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int GamificationModelId { get; set; }

    }
}
