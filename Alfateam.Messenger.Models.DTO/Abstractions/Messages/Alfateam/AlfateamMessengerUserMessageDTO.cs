using Alfateam.Messenger.Models.DTO.Accounts;
using Alfateam.Messenger.Models.DTO.General;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam
{
    public class AlfateamMessengerUserMessageDTO : AlfateamMessengerMessageDTO
    {
        public AlfateamMessengerAccountDTO SentBy { get; set; }


        public List<MessageDTO> Forwarded { get; set; } = new List<MessageDTO>();
    }
}
