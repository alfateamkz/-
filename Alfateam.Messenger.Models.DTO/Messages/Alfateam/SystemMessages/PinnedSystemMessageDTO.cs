using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.Alfateam.SystemMessages
{
    public class PinnedSystemMessageDTO : AlfateamMessengerSystemMessageDTO
    {
        [ForClientOnly]
        public AlfateamMessengerUserMessageDTO Message { get; set; }
    }
}
