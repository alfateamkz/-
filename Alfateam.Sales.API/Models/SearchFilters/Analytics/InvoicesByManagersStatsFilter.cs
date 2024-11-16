using Alfateam.Sales.API.Enums.Analytics;

namespace Alfateam.Sales.API.Models.SearchFilters.Analytics
{
    public class InvoicesByManagersStatsFilter : AnalyticsInvoicesFilter
    {
        public InvoiceFilterParameterType ParameterType { get; set; }
        public int CurrencyId { get; set; }
    }
}
