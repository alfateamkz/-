using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Staff.Employees
{
    /// <summary>
    /// Статус работника
    /// </summary>
    public enum EmployeeStatus
    {
        Active = 1, //Работает
        Break = 2, //Перерыв
        Fired = 3, //Уволен
        Lost = 4, //Пропал
        Dispute = 5, //Спор
        Reserve = 6, //Резерв
    }
}
