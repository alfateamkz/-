using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.SystemMessages
{
    public class GroupChatCreatedMessageDTO : SystemMessageDTO
    {
        public PeerDTO? CreatedBy { get; set; }
        public int? CreatedById { get; set; }



        public string? GroupTitle { get; set; }
    }
}
