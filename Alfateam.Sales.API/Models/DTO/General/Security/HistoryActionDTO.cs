using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General.Security
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
