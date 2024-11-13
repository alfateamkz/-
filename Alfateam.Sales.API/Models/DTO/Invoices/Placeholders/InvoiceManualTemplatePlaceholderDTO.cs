using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Enums.Fields;

namespace Alfateam.Sales.API.Models.DTO.Invoices.Placeholders
{
    public class InvoiceManualTemplatePlaceholderDTO : InvoiceTemplatePlaceholderDTO
    {
        public ManualPlaceholderFieldType Type { get; set; }
    }
}
