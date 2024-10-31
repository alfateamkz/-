using Alfateam.Messenger.Models.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.External.UserMessages
{
    public class ExtVoiceMessage : ExternalMessengerUserMessage
    {
        public string MessageFilePath { get; set; }
        public bool IsListened { get; set; }
        public DateTime? ListenedAt { get; set; }


        public TimeSpan Duration { get; set; }
        public string Waveform { get; set; }
    }
}
