using Alfateam.Core.Attributes.DTO;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.Telephony.API.Models.DTO.General.Security;
using Alfateam.Telephony.Models.General;
using Alfateam.Telephony.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General
{
    public class UserDTO : DTOModelAbs<User>
    {
        public UserRole Role { get; set; }


        public string Position { get; set; }



        [ForClientOnly]
        public DepartmentDTO Department { get; set; }

        [HiddenFromClient]
        public int DepartmentId { get; set; }



        public UserPermissionsDTO Permissions { get; set; }
        public bool IsBlocked { get; set; }
    }
}
