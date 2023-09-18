using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Funnel
{
    /// <summary>
    /// Модель воронки продаж
    /// </summary>
    public class SalesFunnel : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public List<SalesFunnelStage> Stages { get; set; } = new List<SalesFunnelStage>();



		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int SalesDepartmentId { get; set; }
	}
}
