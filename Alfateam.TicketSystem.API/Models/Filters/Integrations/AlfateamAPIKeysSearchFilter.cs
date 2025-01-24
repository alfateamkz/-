using Alfateam.SharedModels.Abstractions;
using Alfateam.TicketSystem.API.Abstractions;

namespace Alfateam.TicketSystem.API.Models.Filters.Integrations
{
    public class AlfateamAPIKeysSearchFilter : SearchFilter
    {
        public int ApiKeyId { get; set; }
        public DateFilterModel DateFilter { get; set; }
    }
}
