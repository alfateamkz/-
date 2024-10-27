using Alfateam.Messenger.Models.General.Security;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Security
{
    public class UserPermissionsDTO : DTOModelAbs<UserPermissions>
    {
        public bool CanCreateGroups { get; set; }


        public bool CanDeleteMessages { get; set; } 
        public bool CanDeleteChats { get; set; } 
    }
}
