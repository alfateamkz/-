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
    /// Модель работника организации
    /// </summary>
    public class Employee : User
    {
        public EmploymentType EmploymentType { get; set; } = EmploymentType.ByProject;
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
        public EmployeePaymentPeriod PaymentPeriod { get; set; } = EmployeePaymentPeriod.ByProject;


        public List<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>();




        public List<EmployeeWorkingDayInfo> WorkingDayInfos { get; set; } = new List<EmployeeWorkingDayInfo>();
        public EmployeeNotificationSettings NotificationSettings { get; set; }


        public List<EmployeeVacation> Vacations { get; set; } = new List<EmployeeVacation>();


    }
}
