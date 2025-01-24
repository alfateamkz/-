using Alfateam.Telephony.API.Models.DTO.Abstractions;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.HLR;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.HLR
{
    public class HLRTaskDTO : DTOModelAbs<HLRTask>
    {
        public string Title { get; set; }
        public HLRTaskStatus Status { get; set; }
        public HLRNumbersToCheckDTO NumbersToCheck { get; set; }
        public List<HLRTaskIterationDTO> Iterations { get; set; } = new List<HLRTaskIterationDTO>();
    }
}
