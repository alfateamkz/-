using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.API.Models.DTO.Abstractions;
using Alfateam.Telephony.API.Models.DTO.General;

namespace Alfateam.Telephony.API.Models.DTO.Calls.Types
{
    public class OutgoingCallDTO : BaseCallDTO
    {
        [ForClientOnly]
        public UserDTO CallMadeBy { get; set; }


        [ForClientOnly]
        public string To { get; set; }
    }
}
