using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Peers
{
    public class AlfateamMessengerPeer : Peer
    {
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
