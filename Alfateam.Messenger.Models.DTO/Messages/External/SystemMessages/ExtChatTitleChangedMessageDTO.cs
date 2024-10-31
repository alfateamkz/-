using Alfateam.Messenger.Models.DTO.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.External.SystemMessages
{
    public class ExtChatTitleChangedMessageDTO : ExternalMessengerSystemMessageDTO
    {
        public string NewTitle { get; set; }
    }
}
