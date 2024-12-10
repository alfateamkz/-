using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.General;
using Alfateam.Telephony.API.Models.DTO.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.SMS
{
    public class SentSMSDTO : BaseSMSDTO
    {

        [ForClientOnly]
        public User SentBy { get; set; }


        public DateTime SentAt { get; set; }
        public string To { get; set; }
    }
}
