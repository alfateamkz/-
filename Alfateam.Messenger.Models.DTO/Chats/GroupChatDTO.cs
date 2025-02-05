using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Chats
{
    public class GroupChatDTO : ChatBaseDTO
    {
        public string Title { get; set; }

        [ForClientOnly]
        public string? ImagePath { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public List<GroupChatMemberBaseDTO> Members { get; set; } = new List<GroupChatMemberBaseDTO>();
    }
}
