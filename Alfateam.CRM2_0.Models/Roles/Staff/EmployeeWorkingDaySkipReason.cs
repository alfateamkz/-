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
    /// Модель информации о пропуске рабочего дня
    /// </summary>
    public class EmployeeWorkingDaySkipReason : AbsModel
    {
        public EmployeeWorkingDaySkipReasonType Type { get; set; } = EmployeeWorkingDaySkipReasonType.Hooky;
        public string? Comment { get; set; }
    }
}
