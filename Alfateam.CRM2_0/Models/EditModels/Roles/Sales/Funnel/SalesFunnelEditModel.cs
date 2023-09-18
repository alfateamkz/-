using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Funnel
{
	public class SalesFunnelEditModel : EditModel<SalesFunnel>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
