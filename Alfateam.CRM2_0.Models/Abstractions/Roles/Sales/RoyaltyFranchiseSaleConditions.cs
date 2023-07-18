using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Sales
{
    /// <summary>
    /// Базовая модель договоренности по франшизы с роялти
    /// </summary>
    public abstract class RoyaltyFranchiseSaleConditions : FranchiseSaleConditions
    {
        public int AllowedOfficesCount { get; set; }
        public int AllowedEmployeesCount { get; set; }


        /// <summary>
        /// День платежа по франшизе
        /// </summary>
        public int DayOfPayment { get; set; }
    }
}
