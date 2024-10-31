using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.SystemMessages
{
    public class ChatPhotoChangedMessage : AlfateamMessengerSystemMessage
    {
        public string PhotoPath { get; set; }
    }
}
