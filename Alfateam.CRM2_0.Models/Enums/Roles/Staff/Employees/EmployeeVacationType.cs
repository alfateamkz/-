using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Staff.Employees
{
    /// <summary>
    /// Тип отпуска сотрудника
    /// </summary>
    public enum EmployeeVacationType
    {
        Paid = 1, //Оплачиваемый отпуск
        NotPaid = 2, //Отпуск за свой счет  
    }
}
