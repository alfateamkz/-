using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Plan
{
	public class SalesPlanningClientModel : ClientModel<SalesPlanning>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }



		/// <summary>
		/// Минимальный план продаж для достижения точки безубыточности
		/// </summary>
		public SalesPlanClientModel MinumumPlan { get; set; }
		/// <summary>
		/// Основной план продаж, который необходимо выполнить
		/// </summary>
		public SalesPlanClientModel GeneralPlan { get; set; }
		/// <summary>
		/// Максимальный план продаж, к которому нужно стремиться
		/// </summary>
		public SalesPlanClientModel MaximumPlan { get; set; }
	}
}
