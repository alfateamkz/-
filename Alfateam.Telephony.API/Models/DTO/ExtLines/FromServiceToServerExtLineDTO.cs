using Alfateam.Telephony.API.Models.DTO.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExtLines
{
    public class FromServiceToServerExtLineDTO : ExtLineDTO
    {
        public string IP { get; set; }
        public string? SIPDomain { get; set; }

        public short Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
