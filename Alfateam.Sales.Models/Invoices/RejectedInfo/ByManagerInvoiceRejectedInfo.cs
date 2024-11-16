using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices.RejectedInfo
{
    public class ByManagerInvoiceRejectedInfo : InvoiceRejectedInfo
    {
        public User Manager { get; set; }
        public int ManagerId { get; set; }


        public ByManagerInvoiceRejectedInfoType ReasonType { get; set; }

    }
}
