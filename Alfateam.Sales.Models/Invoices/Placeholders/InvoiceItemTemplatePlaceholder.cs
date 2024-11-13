using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Enums.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices.Placeholders
{
    public class InvoiceItemTemplatePlaceholder : InvoiceTemplatePlaceholder
    {
        public InvoiceItemFieldType Field { get; set; }
    }
}
