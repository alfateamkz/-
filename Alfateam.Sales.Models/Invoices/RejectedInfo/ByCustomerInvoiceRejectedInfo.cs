using Alfateam.Sales.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices.RejectedInfo
{
    public class ByCustomerInvoiceRejectedInfo : InvoiceRejectedInfo
    {
        public string UserAgent { get; set; }
        public string IP { get; set; }

    }
}
