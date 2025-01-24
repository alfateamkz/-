using Alfateam.Telephony.Models.HLR.Numbers;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.HLR.Numbers
{
    public class HLRNumberToCheckDTO : DTOModelAbs<HLRNumberToCheck>
    {
        public string Phone { get; set; }
    }
}
