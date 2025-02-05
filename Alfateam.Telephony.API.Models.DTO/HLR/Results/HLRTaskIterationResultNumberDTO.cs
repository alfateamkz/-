using Alfateam.Telephony.Models.HLR.Results;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.HLR.Results
{
    public class HLRTaskIterationResultNumberDTO : DTOModelAbs<HLRTaskIterationResultNumber>
    {
        public string Phone { get; set; }
        public bool IsActive { get; set; }



        public string? Status { get; set; }
        public string? MCC { get; set; }
        public string? MNC { get; set; }
        public string? OriginalNetworkName { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
