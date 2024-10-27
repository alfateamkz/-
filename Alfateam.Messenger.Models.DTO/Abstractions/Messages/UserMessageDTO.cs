using Alfateam.Messenger.Models.DTO.General;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Messages
{
    public class UserMessageDTO : MessageDTO
    {
        public UserDTO SentBy { get; set; }


        public List<MessageDTO> Forwarded { get; set; } = new List<MessageDTO>();
    }
}
