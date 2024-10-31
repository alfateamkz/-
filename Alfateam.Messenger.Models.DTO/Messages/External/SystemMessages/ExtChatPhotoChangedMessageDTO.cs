using Alfateam.Messenger.Models.Abstractions.Messages.External;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.External.SystemMessages
{
    public class ExtChatPhotoChangedMessageDTO : ExternalMessengerSystemMessageDTO
    {
        public string PhotoPath { get; set; }
    }
}
