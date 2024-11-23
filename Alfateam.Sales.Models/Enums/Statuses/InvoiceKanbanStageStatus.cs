using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Enums.Statuses
{
    public enum InvoiceKanbanStageStatus
    {
        NewInvoice = 1,
        InWork = 2,

        Paid = 8,
        Rejected = 9
    }
}
