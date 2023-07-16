using Alfateam.Database.Abstraction;
using Alfateam.Database.Enums.CRM.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Staff {
    public class EmployeeDayInfo : BaseModel {


        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }


        public EmployeeDayStatus DayStatus { get; set; } = EmployeeDayStatus.Worked;
        public double Hours { get; set; }
        public string? Description { get; set; }


        /// <summary>
        /// ЗП за конкретный день. Проставляется автоматически при создании из расчета Employee.HourlyWage * Hours
        /// </summary>
        public double Wage { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

    }
}
