using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Conversation
{
	public class CustomerMeetingClientModel : ClientModel<CustomerMeeting>
	{
		/// <summary>
		/// Клиент, с которым назначена встреча
		/// </summary>
		public CustomerClientModel Customer { get; set; }


		/// <summary>
		/// Адрес встречи с клиентом
		/// </summary>
		public AddressClientModel Address { get; set; }


		/// <summary>
		/// Статус встречи с клиентом
		/// </summary>
		public CustomerMeetingStatus Status { get; set; } = CustomerMeetingStatus.Planned;



		/// <summary>
		/// Заказы, которые планируются обсуждаться на встрече
		/// </summary>
		public List<OrderClientModel> Orders { get; set; } = new List<OrderClientModel>();




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
