using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Orders
{
    /// <summary>
    /// Сущность, описывающая возврат заказа
    /// </summary>
    public class ShopOrderReturn : AbsModel
    {
        public DateTime ReturnedAt { get; set; }
        public string Reason { get; set; }
    }
}
