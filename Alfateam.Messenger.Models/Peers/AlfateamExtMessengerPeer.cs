using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Peers
{
    public class AlfateamExtMessengerPeer : Peer
    {
        public ExtMessengerUser User { get; set; }
        public int UserId { get; set; }



        public override string GetPeerUserId()
        {
            return UserId.ToString();
        }
    }
}
