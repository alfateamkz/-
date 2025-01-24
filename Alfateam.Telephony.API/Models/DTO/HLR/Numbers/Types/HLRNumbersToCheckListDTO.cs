using Alfateam.Telephony.API.Models.DTO.Abstractions;
using Alfateam.Telephony.Models.Enums;

namespace Alfateam.Telephony.API.Models.DTO.HLR.Numbers.Types
{
    public class HLRNumbersToCheckListDTO : HLRNumbersToCheckDTO
    {
        public HLRNumbersToCheckListType Type { get; set; }
        public List<HLRNumberToCheckDTO> Numbers { get; set; } = new List<HLRNumberToCheckDTO>();
    }
}
