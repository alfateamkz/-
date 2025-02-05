using Alfateam.Telephony.API.Models.DTO.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Calls.Types
{
    public class IncomingCallDTO : BaseCallDTO
    {
        public string From { get; set; }
    }
}
