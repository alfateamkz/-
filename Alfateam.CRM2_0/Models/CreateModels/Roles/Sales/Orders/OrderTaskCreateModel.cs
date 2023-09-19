using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Orders
{
	public class OrderTaskCreateModel : CreateModel<OrderTask>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
