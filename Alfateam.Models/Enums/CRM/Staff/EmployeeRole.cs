using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums
{
    public enum EmployeeRole {
        [Description("Руководитель")]
        Boss = 1,
        [Description("Директор")]
        Admin = 2,
        [Description("Проектный менеджер")]
        ProjectManager = 3,
        [Description("Менеджер по продажам")]
        SalesManager = 4,
        [Description("Сотрудник")]
        Employee = 5,
        [Description("Бухгалтер")]
        Accountant = 6
    }
}
