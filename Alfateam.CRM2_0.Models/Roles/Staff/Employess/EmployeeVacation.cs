using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Staff.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff.Employess
{
    /// <summary>
    /// Модель отпуска сотрудника
    /// </summary>
    public class EmployeeVacation : AbsModel
    {
        public EmployeeVacationType Type { get; set; } = EmployeeVacationType.NotPaid;

        public DateTime StartDate { get; set; }
        public int Days { get; set; }

        /// <summary>
        /// Оплата за отпуск
        /// </summary>
        public double? Payment { get; set; }

        public string? Comment { get; set; }

    }
}
