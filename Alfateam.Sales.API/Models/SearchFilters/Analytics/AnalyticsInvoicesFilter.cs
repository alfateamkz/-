using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.SearchFilters.Analytics
{
    public class AnalyticsInvoicesFilter
    {
        public ByEmployeesFilter? ByEmployeesFilter { get; set; }
        public DateFilterModel DateFilter { get; set; }
    }
}
