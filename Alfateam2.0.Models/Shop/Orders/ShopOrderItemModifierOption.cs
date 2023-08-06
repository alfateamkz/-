using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Orders
{
    /// <summary>
    /// Сущность опции модификатора в позиции заказ в магазине
    /// </summary>
    public class ShopOrderItemModifierOption : AbsModel
    {
        public ProductModifierItem Option { get; set; }


        //public double Amount { get; set; }
        public double PriceForOne { get; set; }

        [NotMapped]
        public double Sum => /*Amount **/ PriceForOne;

    }
}
