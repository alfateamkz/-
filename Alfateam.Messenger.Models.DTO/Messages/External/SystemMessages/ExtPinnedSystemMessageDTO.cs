using Alfateam.Messenger.Models.DTO.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.External.SystemMessages
{
    public class ExtPinnedSystemMessageDTO : ExternalMessengerSystemMessageDTO
    {
        public string MessageId { get; set; }
    }
}
