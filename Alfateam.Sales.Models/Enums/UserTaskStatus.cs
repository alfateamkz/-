using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Enums
{
    public enum UserTaskStatus
    {
        [Description("Активна")]
        Active = 1,
        [Description("Выполнена")]
        Completed = 2,
        [Description("Отменена")]
        Cancelled = 3,
        [Description("Провалена")]
        Failed = 4
    }
}
