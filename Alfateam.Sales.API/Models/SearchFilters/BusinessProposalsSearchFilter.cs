using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.SearchFilters
{
    public class BusinessProposalsSearchFilter : SearchFilter
    {
        public int? PersonContactId { get; set; }
        public int? CompanyId { get; set; }
    }
}
