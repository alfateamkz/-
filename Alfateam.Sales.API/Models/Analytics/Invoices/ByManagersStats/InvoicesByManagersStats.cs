using Alfateam.Sales.API.Enums.Analytics;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Invoices;
using System.Numerics;

namespace Alfateam.Sales.API.Models.Analytics.Invoices.ByManagersStats
{
    public class InvoicesByManagersStats
    {
        public InvoiceFilterParameterType ParameterType { get; set; }
        public Currency Currency { get; set; }


        public List<InvoicesByManagersStatsItem> Managers { get; set; } = new List<InvoicesByManagersStatsItem>();


        public InvoicesByManagersStats Fill(IEnumerable<Invoice> invoices)
        {
            invoices = invoices.Where(o => o.CurrencyId == Currency.Id);

            var groupedInvoicesByManager = invoices.GroupBy(o => o.CreatedBy);
            foreach (var group in groupedInvoicesByManager)
            {
                switch (ParameterType)
                {
                    case InvoiceFilterParameterType.NumberOfInvoices:
                        Managers.Add(new InvoicesByManagersStatsItem
                        {
                            Manager = group.Key,
                            OverdueValue = group.Count(o => o.IsOverdue),
                            PaidValue = group.Count(o => o.PaidInfoId != null),
                            UnpaidValue = group.Count(o => o.PaidInfoId == null),
                            RejectedValue = group.Count(o => o.RejectedInfoId != null),
                        });
                        break;
                    case InvoiceFilterParameterType.SumOfInvoices:
                        Managers.Add(new InvoicesByManagersStatsItem
                        {
                            Manager = group.Key,
                            OverdueValue = group.Where(o => o.IsOverdue).Sum(o => o.TotalSum),
                            PaidValue = group.Where(o => o.PaidInfoId != null).Sum(o => o.TotalSum),
                            UnpaidValue = group.Where(o => o.PaidInfoId == null).Sum(o => o.TotalSum),
                            RejectedValue = group.Where(o => o.RejectedInfoId != null).Sum(o => o.TotalSum),
                        });
                        break;
                }
            }

            return this;
        }
    }
}
