using Alfateam.SharedModels.Abstractions;
using Alfateam.Telephony.API.Abstractions;

namespace Alfateam.Telephony.API.Models.SearchFilters.Integrations
{
    public class AlfateamAPIKeysSearchFilter : SearchFilter
    {
        public int ApiKeyId { get; set; }
        public DateFilterModel DateFilter { get; set; }
    }
}
