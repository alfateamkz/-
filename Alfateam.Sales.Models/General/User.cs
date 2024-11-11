using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class User : AbsModel
    {
        public string AlfateamID { get; set; }
        public UserRole Role { get; set; } = UserRole.Employee;


        public string Position { get; set; }



        public Department Department { get; set; }
        public int DepartmentId { get; set; }



        public UserPermissions Permissions { get; set; }
        public bool IsBlocked { get; set; }




        /// <summary>
        /// Требуемые KPI продаж для сотрудника, если они установлены
        /// </summary>
        public SalesKPI? RequiredKPI { get; set; }
        /// <summary>
        /// Желаемые KPI продаж для сотрудника, если они установлены
        /// </summary>
        public SalesKPI? DesiredKPI { get; set; }










        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }

    }
}
