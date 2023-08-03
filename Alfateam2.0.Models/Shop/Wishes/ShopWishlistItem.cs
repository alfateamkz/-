using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Wishes
{
    /// <summary>
    /// Пункт списка желаний пользователя в магазине
    /// </summary>
    public class ShopWishlistItem : AbsModel
    {
        public ShopProduct Product { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
