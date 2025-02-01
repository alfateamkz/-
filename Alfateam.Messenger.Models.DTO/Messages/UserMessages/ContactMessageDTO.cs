using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.UserMessages
{
    public class ContactMessageDTO : UserMessageDTO
    {
        public PeerDTO ContactOf { get; set; }
        public int ContactOfId { get; set; }
    }
}
