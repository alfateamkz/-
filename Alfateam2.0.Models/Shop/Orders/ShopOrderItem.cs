using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Orders
{
    /// <summary>
    /// Сущность позиции заказ в магазине
    /// </summary>
    public class ShopOrderItem : AbsModel
    {
        public ShopProduct Item { get; set; }
        public double Amount { get; set; }
        public Cost PriceForOne { get; set; }
    }
}
