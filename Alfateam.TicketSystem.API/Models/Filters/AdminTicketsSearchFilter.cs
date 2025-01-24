using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.Models.Enums;

namespace Alfateam.TicketSystem.API.Models.Filters
{
    public class AdminTicketsSearchFilter : SearchFilter
    {
        public TicketStatus? TicketStatus { get; set; }
        public int? CategoryId { get; set; }
        public int? PriorityId { get; set; }
    }
}
