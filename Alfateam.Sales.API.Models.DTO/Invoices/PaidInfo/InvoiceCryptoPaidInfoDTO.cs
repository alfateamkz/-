using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Enums.PaymentWays;

namespace Alfateam.Sales.API.Models.DTO.Invoices.PaidInfo
{
    public class InvoiceCryptoPaidInfoDTO : InvoicePaidInfoDTO
    {
        public CryptoPaymentWayType Type { get; set; }
        public string FromAccount { get; set; }
        public string Network { get; set; }
    }
}
