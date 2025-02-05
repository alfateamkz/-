using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General.Security
{
    public class HistoryActionDTO : DTOModelAbs<HistoryAction>
    {
        [ForClientOnly]
        public UserDTO CreatedBy { get; set; }


        [ForClientOnly]
        public string Title { get; set; }
        [ForClientOnly]
        public string? Description { get; set; }
    }
}
