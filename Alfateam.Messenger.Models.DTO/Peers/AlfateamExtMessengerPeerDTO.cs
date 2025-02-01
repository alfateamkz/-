using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Integrations.ExtMessenger;
using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Peers
{
    public class AlfateamExtMessengerPeerDTO : PeerDTO
    {
        public ExtMessengerUserDTO User { get; set; }
        public int UserId { get; set; }
    }
}
