using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Enums.Roles.Staff.Employees;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff.Employess
{
    /// <summary>
    /// Модель работника организации
    /// </summary>
    public class Employee : Worker
    {
        public LegalForm LegalForm { get; set; }
        public EmploymentType EmploymentType { get; set; } = EmploymentType.ByProject;
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
        public EmployeePaymentPeriod PaymentPeriod { get; set; } = EmployeePaymentPeriod.ByProject;



        /// <summary>
        /// Испытательный срок (опционально)
        /// </summary>
        public Probation? Probation { get; set; }
        public List<EmployeeVacation> Vacations { get; set; } = new List<EmployeeVacation>();





        public List<EmployeeWorkingDayInfo> WorkingDayInfos { get; set; } = new List<EmployeeWorkingDayInfo>();

        



    }
}
