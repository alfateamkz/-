using Alfateam.Messenger.Models.DTO.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.External.SystemMessages
{
    public class ExtGroupChatCreatedMessageDTO : ExternalMessengerSystemMessageDTO
    {
        public string? CreatedById { get; set; }
        public string GroupTitle { get; set; }
    }
}
