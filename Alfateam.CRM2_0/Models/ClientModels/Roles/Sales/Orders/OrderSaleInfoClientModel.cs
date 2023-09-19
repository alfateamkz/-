using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders
{
	public class OrderSaleInfoClientModel : ClientModel<OrderSaleInfo>
	{
		public SalesFunnelClientModel? Funnel { get; set; }
		public SalesFunnelStageClientModel? FunnelStage { get; set; }




		/// <summary>
		/// Продажник, который внес заказ в систему
		/// </summary>
		public UserClientModel FoundBy { get; set; }
	}
}
