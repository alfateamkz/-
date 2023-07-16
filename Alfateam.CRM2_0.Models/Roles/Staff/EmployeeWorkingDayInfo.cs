using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff
{
    /// <summary>
    /// Модель информации о рабочем дне сотрудника
    /// Используется, если человек на ЗП или почасовке
    /// </summary>
    public class EmployeeWorkingDayInfo : AbsModel
    {
        public DateTime Date { get; set; }
        public double Hours { get; set; }

        public string? Comment { get; set; }

        /// <summary>
        /// Используется, если человек не работал в этот день
        /// </summary>
        public EmployeeWorkingDaySkipReason? SkipReason { get; set; }
    }
}
