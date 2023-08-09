using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Orders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alfateam.Website.API.Models.ClientModels.Shop.Orders
{
    public class ShopOrderAdminClientModel : ShopOrderClientModel
    {
        public User CreatedBy { get; set; }


        /// <summary>
        /// Страна, из которой создан заказ
        /// </summary>
        public Country? Country { get; set; }



        public Promocode? UsedPromocode { get; set; }


        /// <summary>
        /// Список всех оплат(неуспешные и одна успешная)
        /// </summary>
        public List<ShopOrderPayment> Payments { get; set; } = new List<ShopOrderPayment>();
    }
}
