using Alfateam.Sales.Models.Invoices;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Invoices
{
    public class InvoiceItemDTO : DTOModelAbs<InvoiceItem>
    {
        public string Title { get; set; }

        public double Amount { get; set; }
        public string MeasureUnit { get; set; }
        public double PriceForOne { get; set; }



        public double DiscountPercent { get; set; }
        public double VATPercent { get; set; }
    }
}
