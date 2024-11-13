using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.SearchFilters
{
    public class InvoicesSearchFilter : SearchFilter
    {
        public int? CustomerId { get; set; }
    }
}
