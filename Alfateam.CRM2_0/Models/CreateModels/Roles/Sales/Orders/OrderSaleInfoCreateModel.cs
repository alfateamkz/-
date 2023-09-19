using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Orders
{
	public class OrderSaleInfoCreateModel : CreateModel<OrderSaleInfo>
	{
		public int? FunnelId { get; set; }
		public int? FunnelStageId { get; set; }

	}
}
