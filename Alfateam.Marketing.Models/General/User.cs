using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.General.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.General
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
    }
}
