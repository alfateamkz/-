using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM.Staff {
    public enum EmployeeDayStatus {

        [Description("Отработал")]
        Worked = 1,
        [Description("Не работал - уважительная причина")]
        SkippedGoodReason = 2,
        [Description("Не работал - неуважительная причина")]
        SkippedBadReason = 3,
        [Description("Выходной")]
        DayOff = 4
    }
}
