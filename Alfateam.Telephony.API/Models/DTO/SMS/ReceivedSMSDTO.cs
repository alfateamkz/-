using Alfateam.Telephony.API.Models.DTO.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.SMS
{
    public class ReceivedSMSDTO : BaseSMSDTO
    {
        public string From { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
