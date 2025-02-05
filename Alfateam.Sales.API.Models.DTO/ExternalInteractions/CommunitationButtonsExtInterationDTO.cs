using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions
{
    public class CommunitationButtonsExtInterationDTO : ExternalInteractionDTO
    {
        public bool IsOnlineChatEnabled { get; set; }
        public List<ContactInfoDTO> Contacts { get; set; } = new List<ContactInfoDTO>();
    }
}
