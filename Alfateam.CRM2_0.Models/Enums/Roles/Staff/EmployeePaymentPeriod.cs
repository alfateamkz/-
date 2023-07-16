using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Staff
{
    /// <summary>
    /// Период выплаты сотруднику ЗП/гонорара
    /// </summary>
    public enum EmployeePaymentPeriod
    {
        Monthly = 1, //Раз в месяц
        TwoWeekly = 2, //Раз в две недели
        Weekly = 3, //Раз в неделю
        ByProject = 4 //По завершению проекта
    }
}
