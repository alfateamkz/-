using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Invoices
{
    public class InvoiceDTO : DTOModelAbs<Invoice>
    {
        [ForClientOnly]
        public string UniqueURL { get; set; }


        [ForClientOnly]
        public CustomerDTO Customer { get; set; }
        [HiddenFromClient]
        public int CustomerId { get; set; }


        [ForClientOnly]
        public OrderDTO Order { get; set; }
        [HiddenFromClient]
        public int OrderId { get; set; }



        public string Title { get; set; }
        public string HTMLContent { get; set; }



        public string CurrencyCode { get; set; }
        public List<InvoiceItemDTO> Items { get; set; } = new List<InvoiceItemDTO>();
    }
}
