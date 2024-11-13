using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Enums.PaymentWays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices.PaidInfo
{
    public class InvoiceManualPaidInfo : InvoicePaidInfo
    {
        public ManualPaymentWayType Type { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
