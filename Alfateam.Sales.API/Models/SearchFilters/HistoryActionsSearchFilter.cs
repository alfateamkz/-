using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.SearchFilters
{
    public class HistoryActionsSearchFilter : SearchFilter
    {
        public int? UserId { get; set; }
    }
}
