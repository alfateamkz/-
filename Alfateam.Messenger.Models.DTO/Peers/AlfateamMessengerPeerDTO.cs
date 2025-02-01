using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Peers
{
    public class AlfateamMessengerPeerDTO : PeerDTO
    {
        public UserDTO User { get; set; }
        public int UserId { get; set; }
    }
}
