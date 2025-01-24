using Alfateam.TicketSystem.Models.DTO.Abstractions;

namespace Alfateam.TicketSystem.API.Models.TicketHub
{
    public class SendMessageAsAdminParameters
    {
        public string SessionGuid { get; set; }
        public string Domain { get; set; }
        public int CompanyId { get; set; }


        public int TicketId { get; set; }
        public TicketMessageDTO Message { get; set; }
    }
}
