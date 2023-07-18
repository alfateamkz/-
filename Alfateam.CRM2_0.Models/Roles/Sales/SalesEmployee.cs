using Alfateam.CRM2_0.Models.Roles.Staff.Employess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales
{
    /// <summary>
    /// Модель работника отдела продаж
    /// </summary>
    public class SalesEmployee : Employee
    {

        /// <summary>
        /// Минимально необходимые ключевые показатели
        /// </summary>
        public SalesKPI RequiredKPI { get; set; }
        /// <summary>
        /// Желаемые ключевые показатели
        /// </summary>
        public SalesKPI DesiredKPI { get; set; }
    }
}
