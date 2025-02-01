using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.SystemMessages
{
    public class KickedUserMessage : SystemMessage
    {
        public Peer KickedPeer { get; set; }
        public int KickedPeerId { get; set; }




        public Peer KickedBy { get; set; }
        public int KickedById { get; set; }
    }
}
