using Alfateam.Messenger.Models.DTO.Abstractions.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Chats
{
    public class ExternalPrivateChatDTO : ExternalMessengerChatDTO
    {
        public string PeerId { get; set; }
        public string OurUserId { get; set; }
    }
}
