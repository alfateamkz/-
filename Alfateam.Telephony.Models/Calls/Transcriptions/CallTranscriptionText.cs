using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Calls.Transcriptions
{
    public class CallTranscriptionText : AbsModel
    {
        public CallTranscriptionCompanion Companion { get; set; }
        public int CompanionId { get; set; }


        public TimeSpan Timecode { get; set; }
        public string Text { get; set; }
    }
}
