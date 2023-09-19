using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneDeadlineInfoCreateModel : CreateModel<OrderMilestoneDeadlineInfo>
	{
		public DateTime NewDealine { get; set; }


		public int ReasonId { get; set; }
		public string Comment { get; set; }
	}
}
