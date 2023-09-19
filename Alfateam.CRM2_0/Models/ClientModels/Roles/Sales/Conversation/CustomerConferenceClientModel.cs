using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Conversation
{
	public class CustomerConferenceClientModel : ClientModel<CustomerConference>
	{
		public CustomerClientModel Customer { get; set; }

		public CustomerConferenceStatus Status { get; set; }


		/// <summary>
		/// Заказы, которые планируются обсуждаться на встрече
		/// </summary>
		public List<OrderClientModel> Orders { get; set; } = new List<OrderClientModel>();


		/// <summary>
		/// Пользователи CRM, которые могут подключиться к конференции
		/// Обязательно должны быть членами конференции директор, топ-менеджер, продажник и сам клиент
		/// Остальные по усмотрению
		/// </summary>
		public List<UserClientModel> Members { get; set; } = new List<UserClientModel>();



		public DateTime PlannedAt { get; set; }
		public DateTime? StartedAt { get; set; }
		public DateTime? EndedAt { get; set; }


		public string? Comment { get; set; }
		public string? ConferenceRecordPath { get; set; }
	}
}
