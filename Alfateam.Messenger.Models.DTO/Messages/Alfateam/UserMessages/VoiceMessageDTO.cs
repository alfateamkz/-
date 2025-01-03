﻿using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.Alfateam.UserMessages
{
    public class VoiceMessageDTO : AlfateamMessengerUserMessageDTO
    {
        [ForClientOnly]
        public string MessageFilePath { get; set; }
        [ForClientOnly]
        public DateTime? ListenedAt { get; set; }


        [ForClientOnly]
        public TimeSpan Duration { get; set; }
        [ForClientOnly]
        public string Waveform { get; set; }
    }
}
