using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using Alfateam.Messenger.Models.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.SystemMessages
{
    public class GroupChatCreatedMessageDTO : SystemMessageDTO
    {
        [ForClientOnly]
        public UserDTO CreatedBy { get; set; }
        [ForClientOnly]
        public string GroupTitle { get; set; }
    }
}
