using Alfateam.Website.API.Abstractions;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Enums;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.General.Security;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class UserDTO : DTOModelAbs<User>
    {
        public string AlfateamID { get; set; }
        public UserRole Role { get; set; }


        public string Position { get; set; }


        [ForClientOnly]
        public DepartmentDTO Department { get; set; }
        [HiddenFromClient]
        public int DepartmentId { get; set; }



        public UserPermissionsDTO Permissions { get; set; }
        public bool IsBlocked { get; set; }




        /// <summary>
        /// Требуемые KPI продаж для сотрудника, если они установлены
        /// </summary>
        public SalesKPIDTO? RequiredKPI { get; set; }
        /// <summary>
        /// Желаемые KPI продаж для сотрудника, если они установлены
        /// </summary>
        public SalesKPIDTO? DesiredKPI { get; set; }
    }
}
