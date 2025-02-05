using Alfateam.Sales.API.Models.DTO.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Invoices.RejectedInfo
{
    public class ByCustomerInvoiceRejectedInfoDTO : InvoiceRejectedInfoDTO
    {
        public string UserAgent { get; set; }
        public string IP { get; set; }
    }
}
