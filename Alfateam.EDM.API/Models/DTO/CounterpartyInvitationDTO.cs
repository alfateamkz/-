using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO
{
    public class CounterpartyInvitationDTO : DTOModelAbs<CounterpartyInvitation>
    {
        public CounterpartyInvitationStatus Status { get; set; }

        [ForClientOnly]
        public EDMSubjectDTO From { get; set; }
        [ForClientOnly]
        public EDMSubjectDTO To { get; set; }


        [HiddenFromClient]
        public int? ToId { get; set; }

        public string? Comment { get; set; }
    }
}
