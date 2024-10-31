using Alfateam.Messenger.Models.DTO.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.External.UserMessages
{
    public class ExtVoiceMessageDTO : ExternalMessengerUserMessageDTO
    {
        public string MessageFilePath { get; set; }
        public bool IsListened { get; set; }
        public DateTime? ListenedAt { get; set; }


        public TimeSpan Duration { get; set; }
        public string Waveform { get; set; }
    }
}
