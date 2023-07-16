using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Plan
{
    /// <summary>
    /// Модель планирования продаж
    /// </summary>
    public class SalesPlanning : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



        /// <summary>
        /// Минимальный план продаж для достижения точки безубыточности
        /// </summary>
        public SalesPlan MinumumPlan { get; set; }
        /// <summary>
        /// Основной план продаж, который необходимо выполнить
        /// </summary>
        public SalesPlan GeneralPlan { get; set; }
        /// <summary>
        /// Максимальный план продаж, к которому нужно стремиться
        /// </summary>
        public SalesPlan MaximumPlan { get; set; }
    }
}
