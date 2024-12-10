using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.API.Models.DTO.General;
using Alfateam.Telephony.Models.Calls;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Calls
{
    public class CallDTO : DTOModelAbs<Call>
    {

        [ForClientOnly]
        public UserDTO CallMadeBy { get; set; }


        [ForClientOnly]
        public string To { get; set; }
        [ForClientOnly]
        public DateTime StartedAt { get; set; }
        [ForClientOnly]
        public DateTime? EndedAt { get; set; }



        [ForClientOnly]
        public CallRecordDTO? Record { get; set; }
        public string? Comment { get; set; }
    }
}
