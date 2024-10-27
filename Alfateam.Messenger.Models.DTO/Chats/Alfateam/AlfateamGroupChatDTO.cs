using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions.Chats;
using Alfateam.Messenger.Models.DTO.General.GroupChats;
using Alfateam.Messenger.Models.General.GroupChats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Chats.Alfateam
{
    public class AlfateamGroupChatDTO : AlfateamMessengerChatDTO
    {
        [ForClientOnly]
        public string Title { get; set; }
        [ForClientOnly]
        public string? ImagePath { get; set; }


        [ForClientOnly]
        public List<GroupChatMemberDTO> Members { get; set; } = new List<GroupChatMemberDTO>();
    }
}
