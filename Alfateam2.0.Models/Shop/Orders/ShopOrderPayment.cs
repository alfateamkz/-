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
    /// Сущность платежа по заказу
    /// </summary>
    public class ShopOrderPayment : AbsModel
    {
        public double Sum { get; set; }
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

    


        public DateTime InitiatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }

        public MerchantServiceType MerchantService { get; set; } 
        public string Description { get; set; }
    }
}
