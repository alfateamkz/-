using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.Core.Attributes.DTO;

namespace Alfateam.CertificationCenter.Models.DTO.Cancellation
{
    public class EDSCancellationRequestDTO : CancellationRequestDTO
    {
        [ForClientOnly]
        public AlfateamEDSDTO EDSToCancel { get; set; }

        [HiddenFromClient]
        public int EDSToCancelId { get; set; }
    }
}
