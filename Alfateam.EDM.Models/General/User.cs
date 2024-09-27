using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using System.ComponentModel.DataAnnotations.Schema;
using Alfateam.EDM.Models.Enums;

namespace Alfateam.EDM.Models.General
{
    public class User : AbsModel
    {
        public string AlfateamID { get; set; }
        public UserRole Role { get; set; } = UserRole.Employee;


        public string Position { get; set; }



        public Department Department { get; set; }
        public int DepartmentId { get; set; }


        public UserPermissions Permissions { get; set; }
        public DocumentsAccess DocumentsAccess { get; set; }
        public EmailNotificationSettings NotificationSettings { get; set; }
        public List<TrustedUserIPAddress> TrustedUserIPs { get; set; } = new List<TrustedUserIPAddress>();







        public bool IsBlocked { get; set; }
    }
}
