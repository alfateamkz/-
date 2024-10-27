using Alfateam.Messenger.Models.DTO.Abstractions.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Chats
{
    public class ExternalGroupChatDTO : ExternalMessengerChatDTO
    {
        public string? AdminId { get; set; }
    }
}
