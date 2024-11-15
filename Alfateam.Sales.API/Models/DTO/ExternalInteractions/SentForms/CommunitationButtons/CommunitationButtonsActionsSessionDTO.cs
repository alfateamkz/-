using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.CommunitationButtons;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms.CommunitationButtons
{
    public class CommunitationButtonsActionsSessionDTO : DTOModelAbs<CommunitationButtonsActionsSession>
    {
        [ForClientOnly]
        public string UserAgent { get; set; }
        [ForClientOnly]
        public string IP { get; set; }


        [ForClientOnly]
        public List<CommunitationButtonsActionDTO> Actions { get; set; } = new List<CommunitationButtonsActionDTO>();
    }
}
