using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Conversation
{
	public class CustomerCallClientModel : ClientModel<CustomerCall>
	{
		public CustomerClientModel Customer { get; set; }



		public string Phone { get; set; }
		public CustomerCallStatus Status { get; set; }


		/// <summary>
		/// Заказы, которые планируются обсуждаться на встрече
		/// </summary>
		public List<OrderClientModel> Orders { get; set; } = new List<OrderClientModel>();


		public DateTime PlannedAt { get; set; }
		public DateTime? StartedAt { get; set; }
		public DateTime? EndedAt { get; set; }


		public string? Comment { get; set; }
		public string? CallRecordPath { get; set; }
	}
}
