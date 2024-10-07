using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Counterparties
{
    public class EDMCounterpartyDTO : CounterpartyDTO
    {
        [ForClientOnly]
        public EDMSubjectDTO Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
