using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.Alfateam.SystemMessages
{
    public class ChatPhotoChangedMessageDTO : AlfateamMessengerSystemMessageDTO
    {
        [ForClientOnly]
        public string PhotoPath { get; set; }
    }
}
