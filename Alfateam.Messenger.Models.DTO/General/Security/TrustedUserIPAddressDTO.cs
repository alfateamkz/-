using Alfateam.Messenger.Models.General.Security;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Security
{
    public class TrustedUserIPAddressDTO : DTOModelAbs<TrustedUserIPAddress>
    {
        public string IPAddress { get; set; }
    }
}
