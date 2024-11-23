using Alfateam.Sales.Models.Invoices;

namespace Alfateam.Sales.API.Models.Analytics.Invoices.SumStats
{
    public class InvoicesSumStats
    {
        public List<CurrencyAmountAndSum> TotalInvoicesSum { get; set; } = new List<CurrencyAmountAndSum>();
        public List<CurrencyAmountAndSum> PaidInvoicesSum { get; set; } = new List<CurrencyAmountAndSum>();
        public List<CurrencyAmountAndSum> UnpaidInvoicesSum { get; set; } = new List<CurrencyAmountAndSum>();

        public static InvoicesSumStats Create(IEnumerable<Invoice> invoices)
        {
            var stats = new InvoicesSumStats();

            var groupedInvoicesByCurrency = invoices.GroupBy(o => o.Currency);
            foreach (var grouped in groupedInvoicesByCurrency)
            {
                stats.TotalInvoicesSum.Add(new CurrencyAmountAndSum
                {
                    Currency = grouped.Key,
                    Sum = grouped.Sum(o => o.Items.Sum(o => o.TotalPrice)),
                    Amount = grouped.Count()
                });
                stats.PaidInvoicesSum.Add(new CurrencyAmountAndSum
                {
                    Currency = grouped.Key,
                    Sum = grouped.Where(o => o.PaidInfoId != null).Sum(o => o.Items.Sum(o => o.TotalPrice)),
                    Amount = grouped.Count()
                });
                stats.UnpaidInvoicesSum.Add(new CurrencyAmountAndSum
                {
                    Currency = grouped.Key,
                    Sum = grouped.Where(o => o.PaidInfoId == null).Sum(o => o.Items.Sum(o => o.TotalPrice)),
                    Amount = grouped.Count()
                });
            }

            return stats;
        }
    }
}
