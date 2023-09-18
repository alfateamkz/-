using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Funnel
{
	public class SalesFunnelClientModel : ClientModel<SalesFunnel>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
