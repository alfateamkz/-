using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.General.Security
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
