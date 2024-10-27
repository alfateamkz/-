using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.Core.Attributes.DTO;

namespace Alfateam.CertificationCenter.Models.DTO.Cancellation
{
    public class DigitalPOACancellationRequestDTO : CancellationRequestDTO
    {
        [ForClientOnly]
        public AlfateamDigitalPOADTO DigitalPOAToCancel { get; set; }
    }
}
