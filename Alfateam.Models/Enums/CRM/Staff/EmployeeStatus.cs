using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM.Staff
{
    public enum EmployeeStatus
    {

        [Description("Работает")]
        Active = 1,
        [Description("Перерыв")]
        Break = 2,
        [Description("Болеет")]
        Ill = 3,
        [Description("Уволен")]
        Fired = 4
    }
}
