using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneDeadlineInfoClientModel : ClientModel<OrderMilestoneDeadlineInfo>
	{
		public DateTime OldDealine { get; set; }
		public DateTime NewDealine { get; set; }


		public DeadlineFailedReasonClientModel Reason { get; set; }
		public string Comment { get; set; }
	}
}
