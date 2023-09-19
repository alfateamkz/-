using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Conversation
{
	public class CustomerConferenceCreateModel : CreateModel<CustomerConference>
	{
		public int CustomerId { get; set; }


		public CustomerConferenceStatus Status { get; set; } = CustomerConferenceStatus.Planned;


		/// <summary>
		/// Заказы, которые планируются обсуждаться на встрече
		/// </summary>
		public List<int> OrdersIds { get; set; } = new List<int>();


		/// <summary>
		/// Пользователи CRM, которые могут подключиться к конференции
		/// Обязательно должны быть членами конференции директор, топ-менеджер, продажник и сам клиент
		/// Остальные по усмотрению
		/// </summary>
		public List<int> MembersIds { get; set; } = new List<int>();



		public DateTime PlannedAt { get; set; }
		public DateTime? StartedAt { get; set; }
		public DateTime? EndedAt { get; set; }


		public string? Comment { get; set; }
	}
}
