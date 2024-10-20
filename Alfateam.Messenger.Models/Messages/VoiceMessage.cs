using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages
{
    public class VoiceMessage : Message
    {
        public byte[] Message { get; set; }

        public bool IsListened { get; set; }
        public DateTime? ListenedAt { get; set; }
    }
}
