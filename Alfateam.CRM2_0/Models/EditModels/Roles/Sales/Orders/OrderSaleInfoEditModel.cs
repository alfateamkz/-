using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Orders
{
	public class OrderSaleInfoEditModel : EditModel<OrderSaleInfo>
	{
		public int? FunnelId { get; set; }
		public int? FunnelStageId { get; set; }
	}
}
