using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Funnel
{
	public class SalesFunnelStageEditModel : EditModel<SalesFunnelStage>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

		public SalesFunnelStageType Type { get; set; } 
	}
}
