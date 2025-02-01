using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.SystemMessages
{
    public class ChatTitleChangedMessageDTO : SystemMessageDTO
    {
        public string NewTitle { get; set; }
    }
}
