using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Enums.PaymentWays;

namespace Alfateam.Sales.API.Models.DTO.Invoices.PaidInfo
{
    public class InvoiceAcquiringPaidInfoDTO : InvoicePaidInfoDTO
    {
        public AcquiringPaymentWayType Type { get; set; }
        public string FromAccount { get; set; }
    }
}
