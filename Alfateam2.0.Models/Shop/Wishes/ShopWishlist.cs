using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Wishes
{
    /// <summary>
    /// Список желаний пользователя в магазине
    /// </summary>
    public class ShopWishlist : AbsModel
    {
        public User User { get; set; }
        public int UserId { get; set; }


        public List<ShopWishlistItem> Items { get; set; } = new List<ShopWishlistItem>();
    }
}
