using Alfateam.Telephony.Models.HLR.Results;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.HLR.Results
{
    public class HLRTaskIterationResultNumberDTO : DTOModelAbs<HLRTaskIterationResultNumber>
    {
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
