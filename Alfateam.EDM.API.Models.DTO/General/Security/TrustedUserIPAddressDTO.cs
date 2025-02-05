using Alfateam.EDM.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General.Security
{
    public class TrustedUserIPAddressDTO : DTOModelAbs<TrustedUserIPAddress>
    {
        public string IPAddress { get; set; }
    }
}
