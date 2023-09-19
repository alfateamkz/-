using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.CreateModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Conversation
{
	public class CustomerMeetingCreateModel : CreateModel<CustomerMeeting>
	{
		public int CustomerId { get; set; }


		/// <summary>
		/// Адрес встречи с клиентом
		/// </summary>
		public AddressCreateModel Address { get; set; }


		/// <summary>
		/// Статус встречи с клиентом
		/// </summary>
		public CustomerMeetingStatus Status { get; set; } = CustomerMeetingStatus.Planned;



		/// <summary>
		/// Заказы, которые планируются обсуждаться на встрече
		/// </summary>
		public List<int> OrdersIds { get; set; } = new List<int>();




		/// <summary>
		/// Запланированная дата
		/// </summary>
		public DateTime PlannedAt { get; set; }
		/// <summary>
		/// Дата фактического начала встречи
		/// </summary>
		public DateTime? StartedAt { get; set; }
		/// <summary>
		/// Дата завершения встречи
		/// </summary>
		public DateTime? EndedAt { get; set; }


		/// <summary>
		/// Комментарий касательно встречи
		/// </summary>
		public string? Comment { get; set; }
	}
}
