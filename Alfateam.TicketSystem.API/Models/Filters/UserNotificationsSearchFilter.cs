using Alfateam.TicketSystem.API.Abstractions;

namespace Alfateam.TicketSystem.API.Models.Filters
{
    public class UserNotificationsSearchFilter : SearchFilter
    {
        public bool? IsRead { get; set; }
    }
}
