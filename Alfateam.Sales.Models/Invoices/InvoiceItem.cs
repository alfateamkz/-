using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices
{
    public class InvoiceItem : AbsModel
    {
        public string Title { get; set; }

        public double Amount { get; set; }
        public string MeasureUnit { get; set; }
        public double PriceForOne { get; set; }



        public double DiscountPercent { get; set; }
        public double VATPercent { get; set; }
    }
}
