using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Conversation
{
	public class CustomerCallCreateModel : CreateModel<CustomerCall>
	{
		public int CustomerId { get; set; }



		public string Phone { get; set; }
		public CustomerCallStatus Status { get; set; } = CustomerCallStatus.Planned;


		/// <summary>
		/// Заказы, которые планируются обсуждаться на встрече
		/// </summary>
		public List<int> OrderIds { get; set; } = new List<int>();


		public DateTime PlannedAt { get; set; }
		public DateTime? StartedAt { get; set; }
		public DateTime? EndedAt { get; set; }


		public string? Comment { get; set; }
	}
}
