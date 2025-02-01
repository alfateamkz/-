using Alfateam.Messenger.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Chats
{
    public class PrivateChatDTO : ChatBaseDTO
    {
        public PeerDTO CreatedBy { get; set; }
        public int CreatedById { get; set; }


        public PeerDTO Receiver { get; set; }
        public int ReceiverId { get; set; }
    }
}
