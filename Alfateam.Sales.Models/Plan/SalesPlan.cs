using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Plan
{
    /// <summary>
    /// Модель плана продаж
    /// </summary>
    public class SalesPlan : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public List<SalesPlanItem> Items { get; set; } = new List<SalesPlanItem>();




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int SalesPlanningId { get; set; }

	}
}
