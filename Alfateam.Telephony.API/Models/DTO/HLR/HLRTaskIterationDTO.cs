using Alfateam.Telephony.Models.HLR;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.HLR
{
    public class HLRTaskIterationDTO : DTOModelAbs<HLRTaskIteration>
    {
        public TimeSpan DelayTime { get; set; }
    }
}
