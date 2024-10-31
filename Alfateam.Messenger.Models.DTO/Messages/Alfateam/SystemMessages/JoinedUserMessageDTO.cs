using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.DTO.Accounts;
using Alfateam.Messenger.Models.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.Alfateam.SystemMessages
{
    public class JoinedUserMessageDTO : AlfateamMessengerSystemMessageDTO
    {
        [ForClientOnly]
        public AlfateamMessengerAccountDTO User { get; set; }
    }
}
