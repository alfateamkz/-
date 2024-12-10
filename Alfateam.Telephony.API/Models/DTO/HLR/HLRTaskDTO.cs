using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.HLR;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.HLR
{
    public class HLRTaskDTO : DTOModelAbs<HLRTask>
    {
        public HLRTaskStatus Status { get; set; }
        public List<HLRTaskIterationDTO> Iterations { get; set; } = new List<HLRTaskIterationDTO>();
    }
}
