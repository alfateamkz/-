using Alfateam.Messenger.Models.DTO.Abstractions.Chats;
using Alfateam.Messenger.Models.DTO.General;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Chats.Alfateam
{
    public class AlfateamPrivateChatDTO : AlfateamMessengerChatDTO
    {
        public UserDTO Peer { get; set; }
    }
}
