using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.General.Security;
using Alfateam.Messenger.Models.Enums;
using Alfateam.Messenger.Models.General;
using Alfateam.Messenger.Models.General.Security;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General
{
    public class UserDTO : DTOModelAbs<User>
    {
        [ForClientOnly]
        public string UniqueId { get; set; }
        [ForClientOnly]
        public string AlfateamID { get; set; }



        public string Position { get; set; }
        public bool IsBlocked { get; set; }

        [ForClientOnly]
        public DepartmentDTO Department { get; set; }
        public int DepartmentId { get; set; }


        public UserRole Role { get; set; }
        public UserPermissionsDTO Permissions { get; set; }
        public AllowedAccountsAccessDTO AllowedAccountsAccess { get; set; }



        public DateTime LastOnlineDate { get; set; }
    }
}
