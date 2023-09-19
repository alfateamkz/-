using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.CreateModels.General;
using Alfateam.CRM2_0.Models.EditModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Conversation
{
	public class CustomerMeetingEditModel : EditModel<CustomerMeeting>
	{
		/// <summary>
		/// Адрес встречи с клиентом
		/// </summary>
		public AddressEditModel Address { get; set; }


		/// <summary>
		/// Статус встречи с клиентом
		/// </summary>
		public CustomerMeetingStatus Status { get; set; }





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
