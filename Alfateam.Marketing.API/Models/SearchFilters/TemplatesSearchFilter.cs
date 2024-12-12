using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.Models.Enums;

namespace Alfateam.Marketing.API.Models.SearchFilters
{
    public class TemplatesSearchFilter : SearchFilter
    {
        public ContactType? ContactType { get; set; }
    }
}
