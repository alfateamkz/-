using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Funnel
{
	public class SalesFunnelCreateModel : CreateModel<SalesFunnel>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
