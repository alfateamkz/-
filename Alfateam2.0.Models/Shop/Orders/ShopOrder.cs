using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Orders
{
    /// <summary>
    /// Сущность заказа в магазине
    /// </summary>
    public class ShopOrder : AbsModel
    {
        public User CreatedBy { get; set; }
        public Address Address { get; set; }



        public ShopOrderStatus Status { get; set; } = ShopOrderStatus.Basket;
        public List<ShopOrderItem> Items { get; set; } = new List<ShopOrderItem>();
        public string? TrackingURL { get; set; }
        public Promocode? UsedPromocode { get; set; }
        


        public ShopOrderReturn? Return { get; set; }
    }
}
