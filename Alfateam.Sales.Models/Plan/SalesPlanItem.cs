using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Plan
{
    /// <summary>
    /// Модель пункта плана продаж
    /// </summary>
    public class SalesPlanItem : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public int SalesCount { get; set; }
        public double SumOfSales { get; set; }
        public double AverageCheque { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int SalesPlanId { get; set; }

	}
}
