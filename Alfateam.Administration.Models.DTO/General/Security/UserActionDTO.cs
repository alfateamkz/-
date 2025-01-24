using Alfateam.Administration.Models.General.Security;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.General.Security
{
    public class UserActionDTO : DTOModelAbs<UserAction>
    {
        [ForClientOnly]
        public UserDTO User { get; set; }




        [ForClientOnly]
        public string Title { get; set; }

        [ForClientOnly]
        public string? Description { get; set; }
    }
}
