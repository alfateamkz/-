using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.UserMessages
{
    public class VoiceMessageDTO : UserMessageDTO
    {
        public string MessageFilePath { get; set; }
        public DateTime? ListenedAt { get; set; }


        public TimeSpan Duration { get; set; }
        public string Waveform { get; set; }
    }
}
