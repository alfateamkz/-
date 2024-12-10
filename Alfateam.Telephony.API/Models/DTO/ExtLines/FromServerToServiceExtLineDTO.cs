using Alfateam.Telephony.API.Models.DTO.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExtLines
{
    public class FromServerToServiceExtLineDTO : ExtLineDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
