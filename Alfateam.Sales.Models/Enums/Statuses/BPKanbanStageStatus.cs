using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Enums.Statuses
{
    public enum BPKanbanStageStatus
    {
        NewBP = 1,
        InWork = 2,

        Approved = 8,
        Rejected = 9
    }
}
