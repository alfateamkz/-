using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Integrations.ExtMessenger
{
    public class ExtMessengerUserDTO : DTOModelAbs<ExtMessengerUser>
    {
        public string UniqueId { get; set; }
    }
}
