using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing.Referral
{
    /// <summary>
    /// Модель поступления по реферальной программе с привязкой к заказу
    /// </summary>
    public class ReferralEntry : AbsModel
    {
        /// <summary>
        /// Заказ, за привлечение которого идет начисление
        /// </summary>
        public Order Order { get; set; }



        /// <summary>
        /// Процент по реферальной системе
        /// </summary>
        public double Percent { get; set; }
        /// <summary>
        /// Сумма начисления 
        /// </summary>
        public double Sum { get; set; }
    }
}
