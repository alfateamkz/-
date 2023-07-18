using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Staff.Employees
{
    /// <summary>
    /// Модель типа информации о пропуске рабочего дня
    /// </summary>
    public enum EmployeeWorkingDaySkipReasonType
    {
        Vacation = 1, //Отпуск
        DayOff = 2, //Выходной
        Hooky = 3, //Прогул
        Health = 4, //По здоровью
        Personal = 5, //Личные причины


        Other = 999 //Иная причина
    }
}
