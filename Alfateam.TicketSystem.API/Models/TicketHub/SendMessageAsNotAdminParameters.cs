using Alfateam.TicketSystem.API.Enums;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Telegram.Bot.Requests.Abstractions;

namespace Alfateam.TicketSystem.API.Models.TicketHub
{
    public class SendMessageAsNotAdminParameters
    {
        public string Identifier { get; set; }
        public ClientSenderType SenderType { get; set; }
        public string? UserAgent { get; set; }



        public string Domain { get; set; }
        public int CompanyId { get; set; }


        public int TicketId { get; set; }
        public TicketMessageDTO Message { get; set; }
    }
}
