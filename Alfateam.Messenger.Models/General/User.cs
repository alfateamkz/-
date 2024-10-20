using Alfateam.Core;
using Alfateam.Messenger.Models.Enums;
using Alfateam.Messenger.Models.General.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General
{
    public class User : AbsModel
    {
        public string UniqueId { get; set; } = Guid.NewGuid().ToString();
        public string AlfateamID { get; set; }



        public string Position { get; set; }
        public bool IsBlocked { get; set; }


        public Department Department { get; set; }
        public int DepartmentId { get; set; }


        public UserRole Role { get; set; } = UserRole.Employee;
        public UserPermissions Permissions { get; set; }
        public AllowedAccountsAccess AllowedAccountsAccess { get; set; }
    }
}
