using Alfateam.EDM.API.Abstractions;
using Alfateam.SharedModels.Abstractions;

namespace Alfateam.EDM.API.Models.Filters.Integrations
{
    public class AlfateamAPIKeysSearchFilter : SearchFilter
    {
        public int ApiKeyId { get; set; }
        public DateFilterModel DateFilter { get; set; }
    }
}
