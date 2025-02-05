using Alfateam.Sales.Models.ExternalInteractions.SentForms.CommunitationButtons;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms.CommunitationButtons
{
    public class CommunitationButtonsActionDTO : DTOModelAbs<CommunitationButtonsAction>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
