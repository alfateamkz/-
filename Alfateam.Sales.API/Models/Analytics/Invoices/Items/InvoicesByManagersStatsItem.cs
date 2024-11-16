using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.Analytics.Invoices.Items
{
    public class InvoicesByManagersStatsItem
    {
        public User Manager { get; set; }


        public double UnpaidValue { get; set; }
        public double PaidValue { get; set; }
        public double OverdueValue { get; set; }
        public double RejectedValue { get; set; }
    }
}
