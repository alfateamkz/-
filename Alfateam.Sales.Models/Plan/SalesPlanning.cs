using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Plan
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




        public List<SalesPlan> Plans { get; set; } = new List<SalesPlan>();






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }

        public bool IsInPeriod(DateTime value)
		{
			return StartDate <= value && EndDate >= value;
		}
	}
}
