using Alfateam.Sales.API.Models.DTO.Abstractions;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.Conversation
{
    public class CustomerMeetingDTO : CustomerConversationDTO
    {
        [Description("Адрес встречи с клиентом")]
		public string Address { get; set; }

        [Description("Дополнительные вложения(файлы) касательно встречи")]
        public List<CustomerMeetingAttachmentDTO> Attachments { get; set; } = new List<CustomerMeetingAttachmentDTO>();
    }
}
