using Alfateam.Sales.API.Enums.Analytics;

namespace Alfateam.Sales.API.Models.SearchFilters.Analytics
{
    public class AnalyticsInvoicesTopByEmployeesFilter : AnalyticsInvoicesFilter
    {
        public InvoiceStatusType Type { get; set; }
        public InvoiceFilterParameterType ParameterType { get; set; }
        public int CurrencyId { get; set; }
    }
}
