using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Messages
{
    public class UserMessageDTO : MessageBaseDTO
    {
        public PeerDTO SentBy { get; set; }
        public int SentById { get; set; }

        public List<MessageBaseDTO> ForwardedMessages { get; set; } = new List<MessageBaseDTO>();
    }
}
