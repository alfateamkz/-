using Alfateam.Marketing.API.Abstractions;
using Alfateam.SharedModels.Abstractions;

namespace Alfateam.Marketing.API.Models.SearchFilters.Integrations
{
    public class AlfateamAPIKeysSearchFilter : SearchFilter
    {
        public int ApiKeyId { get; set; }
        public DateFilterModel DateFilter { get; set; }
    }
}
