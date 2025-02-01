using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.SystemMessages
{
    public class PinnedSystemMessageDTO : SystemMessageDTO
    {
        public MessageBaseDTO Message { get; set; }
        public int MessageId { get; set; }
    }
}
