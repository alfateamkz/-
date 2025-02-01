using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.SystemMessages
{
    public class KickedUserMessageDTO : SystemMessageDTO
    {
        public PeerDTO KickedPeer { get; set; }
        public int KickedPeerId { get; set; }




        public PeerDTO KickedBy { get; set; }
        public int KickedById { get; set; }
    }
}
