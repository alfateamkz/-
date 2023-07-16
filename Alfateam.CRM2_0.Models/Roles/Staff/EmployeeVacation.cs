using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff
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

    }
}
