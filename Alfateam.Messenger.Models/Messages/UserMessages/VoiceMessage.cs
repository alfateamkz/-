using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.UserMessages
{
    public class VoiceMessage : UserMessage
    {
        public string MessageFilePath { get; set; }
        public DateTime? ListenedAt { get; set; }


        public TimeSpan Duration { get; set; }
        public string Waveform { get; set; }
    }
}
