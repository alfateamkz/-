using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Shop.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Orders
{
    /// <summary>
    /// Сущность модификатора в позиции заказ в магазине
    /// </summary>
    public class ShopOrderItemModifier : AbsModel
    {
        public ProductModifier Modifier { get; set; }
        public int ModifierId { get; set; }
        public List<ShopOrderItemModifierOption> SelectedOptions { get; set; } = new List<ShopOrderItemModifierOption>();
    }
}
