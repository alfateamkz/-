using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Enums.PaymentWays;

namespace Alfateam.Sales.API.Models.DTO.Invoices.PaidInfo
{
    public class InvoiceManualPaidInfoDTO : InvoicePaidInfoDTO
    {
        public ManualPaymentWayType Type { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
