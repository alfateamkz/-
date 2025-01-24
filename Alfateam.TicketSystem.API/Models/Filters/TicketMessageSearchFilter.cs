using Alfateam.TicketSystem.API.Abstractions;

namespace Alfateam.TicketSystem.API.Models.Filters
{
    public class TicketMessageSearchFilter : SearchFilter
    {
        public int TicketId { get; set; }
    }
}
