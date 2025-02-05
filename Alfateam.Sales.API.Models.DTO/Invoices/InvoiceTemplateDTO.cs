using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Invoices
{
    public class InvoiceTemplateDTO : DTOModelAbs<InvoiceTemplate>
    {
        public string Title { get; set; }
        public string HTMLContent { get; set; }



        [ForClientOnly]
        public List<InvoiceTemplatePlaceholderDTO> Placeholders { get; set; } = new List<InvoiceTemplatePlaceholderDTO>();
    }
}
