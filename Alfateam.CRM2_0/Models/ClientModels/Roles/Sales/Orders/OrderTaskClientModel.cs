using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders
{
	public class OrderTaskClientModel : ClientModel<OrderTask>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

		public OrderTaskStatus Status { get; set; }


		/// <summary>
		/// Подзадачи
		/// </summary>
		public List<OrderTaskClientModel> SubTasks { get; set; } = new List<OrderTaskClientModel>();
	}
}
