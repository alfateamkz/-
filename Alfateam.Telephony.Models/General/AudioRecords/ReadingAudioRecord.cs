using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.General.AudioRecords.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.General.AudioRecords
{
    public class ReadingAudioRecord : AudioRecord
    {
        public string Title { get; set; }
        public string Text { get; set; }



        public ReadingVoice ReadingVoice { get; set; }
        public int ReadingVoiceId { get; set; }
    }
}
