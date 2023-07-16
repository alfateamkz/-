using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM.Staff
{
    public enum EmployeeType
    {
        [Description("Фулл тайм")]
        FullTime = 1,
        [Description("Парт тайм")]
        PartTime = 2,
        [Description("Проектная занятость")]
        ProjectEmployment = 3,
        [Description("На проценте")]
        OnPercent = 4,
        [Description("В доле/партнер")]
        InShare = 5,
        [Description("Смешанная занятость")]
        Mixed = 6
    }
}
