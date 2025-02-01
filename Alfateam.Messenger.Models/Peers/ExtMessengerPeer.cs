using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Peers
{
    public class ExtMessengerPeer : Peer
    {
        public string ExtPeerId { get; set; }
    }
}
