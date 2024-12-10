using Alfateam.Telephony.Models.HLR;
using Alfateam.Telephony.Models.HLR.Results;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.HLR.Results
{
    public class HLRTaskIterationResultDTO : DTOModelAbs<HLRTaskIterationResult>
    {
        public HLRTaskIterationDTO Iteration { get; set; }


        public List<HLRTaskIterationResultNumberDTO> Numbers { get; set; } = new List<HLRTaskIterationResultNumberDTO>();
    }
}
