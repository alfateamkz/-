using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Enums.Fields;

namespace Alfateam.Sales.API.Models.DTO.Invoices.Placeholders
{
    public class InvoiceCustomerTemplatePlaceholderDTO : InvoiceTemplatePlaceholderDTO
    {
        public PlaceholderCustomerFieldType Field { get; set; }
    }
}
