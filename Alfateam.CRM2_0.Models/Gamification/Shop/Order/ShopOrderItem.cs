using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Shop.Order
{
    /// <summary>
    /// Модель позиции заказа
    /// </summary>
    public class ShopOrderItem : AbsModel
    {
        public ShopItem Item { get; set; }
        public int ItemId { get; set; }


        public double PriceForOne { get; set; }
        public double Amount { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ShopOrderId { get; set; }
    }
}
